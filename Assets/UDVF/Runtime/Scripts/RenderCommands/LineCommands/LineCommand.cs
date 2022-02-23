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
            var vertexOffset = vh.currentVertCount;
            var normal = new Vector2(_End.y - _Start.y, _Start.x - _End.x).normalized;
            vh.AddVert(_Start + normal * _Size, _Color, Vector2.zero);
            vh.AddVert(_Start - normal * _Size, _Color, Vector2.up);
            vh.AddVert(_End - normal * _Size, _Color, Vector2.one);
            vh.AddVert(_End + normal * _Size, _Color, Vector2.right);
            vh.AddTriangle(vertexOffset, vertexOffset + 1, vertexOffset + 2);
            vh.AddTriangle(vertexOffset + 2, vertexOffset + 3, vertexOffset);
        }
    }
}