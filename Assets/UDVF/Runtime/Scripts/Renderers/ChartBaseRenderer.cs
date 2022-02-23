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
      [Space(30)]
      [SerializeField] protected ChartPointCommandType _chartPointType;

      protected Vector3[] _CornersArray = new Vector3[4];
      protected List<ChartRenderCommand> _RenderBuffer 
         = new List<ChartRenderCommand>();
      public void UpdateData()
      {
         SetVerticesDirty();
      }
      protected override void OnPopulateMesh(VertexHelper vh)
      {
         rectTransform.GetLocalCorners(_CornersArray);
         vh.Clear();
         _RenderBuffer.Clear();
         ProcessBuffer();
         ProcessEffectors();
         var commands = _RenderBuffer.OrderBy(command => command.SortingOrder);
         foreach (var command in commands)
         {
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
      public virtual Vector2 GetRealChartPos(Vector2 normalizedPos)
      {
         return new Vector2(
            Mathf.LerpUnclamped(_CornersArray[0].x, _CornersArray[2].x, normalizedPos.x),
            Mathf.LerpUnclamped(_CornersArray[0].y, _CornersArray[2].y, normalizedPos.y)
         );
      }
      protected override void OnValidate()
      {
         base.OnValidate();
         SetVerticesDirty();
      }
   }
}
