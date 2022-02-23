using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands.PointCommands
{
    public class TrianglePointCommand : PointCommand
    {
        public TrianglePointCommand(Vector2 pos, float size, Color color) : base(pos, size, color)
        {
        }

        public override void Render(VertexHelper vh)
        {
            var vertexOffset = vh.currentVertCount;
            vh.AddVert(_Position + Vector2.right * _Size + Vector2.up *_Size / 2, _Color, Vector2.zero);
            vh.AddVert(_Position + Vector2.left * _Size + Vector2.up *_Size /2, _Color, Vector2.zero);
            vh.AddVert(_Position + Vector2.down *_Size, _Color, Vector2.zero);
            vh.AddTriangle(vertexOffset, vertexOffset + 1, vertexOffset + 2);
        }
    }
}