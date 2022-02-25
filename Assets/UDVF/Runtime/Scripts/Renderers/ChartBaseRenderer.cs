using System.Collections.Generic;
using System.Linq;
using UDVF.Runtime.Scripts.ChartEffectors;
using UDVF.Runtime.Scripts.Charts.RenderCommands;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts
{
   [ExecuteInEditMode]
   [RequireComponent(typeof(CanvasRenderer))]
   public abstract class ChartBaseRenderer : MaskableGraphic
   {
      protected Vector3[] _CornersArray = new Vector3[4];
      protected List<ChartRenderCommand> _RenderBuffer 
         = new List<ChartRenderCommand>();
      public void UpdateData()
      {
         SetAllDirty();
      }
      protected override void OnPopulateMesh(VertexHelper vh)
      {
         rectTransform.GetLocalCorners(_CornersArray);
         vh.Clear();
         _RenderBuffer.Clear();
         ProcessBuffer();
         ProcessEffectors();
         Render(vh);
      }

      protected virtual void Render(VertexHelper vh)
      {
         var commands = _RenderBuffer.OrderBy(command => command.SortingOrder);
         foreach (var command in commands)
         {
            command.SetTransformCoordsFunc(GetRealChartPos);
            command.Render(vh);
         }
      }
      private void ProcessEffectors()
      {
         var effectors = GetComponents<ChartEffector>();
         if (effectors.Length > 0)
         {
            foreach (ChartEffector chartEffector in effectors)
            {
               _RenderBuffer.AddRange(chartEffector.GenerateRenderCommands(this));
            }
         }
      }

      protected abstract void ProcessBuffer();
      public virtual Vector2 GetRealChartPos(Vector2 pos)
      {
         return new Vector2(
            Mathf.LerpUnclamped(_CornersArray[0].x, _CornersArray[2].x, pos.x),
            Mathf.LerpUnclamped(_CornersArray[0].y, _CornersArray[2].y, pos.y)
         );
      }
      protected override void OnValidate()
      {
         base.OnValidate();
         SetVerticesDirty();
      }
   }
}
