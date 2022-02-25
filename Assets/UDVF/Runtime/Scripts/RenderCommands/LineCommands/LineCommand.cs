using UDVF.Runtime.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands.LineCommands
{
    public class LineCommand : ChartRenderCommand
    {
        protected Vector2 _Start;
        protected Vector2 _End;
        protected float _Size;
        protected Color _Color;

        public LineCommand(Vector2 p1, Vector2 p2, float lineSize, Color lineColor, int sortingOrder)
        {
            _Start = p1;
            _End = p2;
            _Size = lineSize;
            _Color = lineColor;
            _SortingOrder = sortingOrder;
        }

        public override void Render(VertexHelper vh)
        {
            _Start = _TransformCoords.Invoke(_Start);
            _End = _TransformCoords.Invoke(_End);
            MeshGenerator.RenderLine(vh, _Start, _End, _Size, _Color);
        }
    }
}