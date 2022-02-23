using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands.PointCommands
{
    public class SquarePointCommand : PointCommand
    {
        public override void Render(VertexHelper vh)
        {
            var vertexOffset = vh.currentVertCount;
            vh.AddVert(new Vector3(_Position.x - _Size, _Position.y - _Size), _Color, Vector2.zero);
            vh.AddVert(new Vector3(_Position.x + _Size, _Position.y - _Size), _Color, Vector2.zero);
            vh.AddVert(new Vector3(_Position.x + _Size, _Position.y + _Size), _Color, Vector2.zero);
            vh.AddVert(new Vector3(_Position.x - _Size, _Position.y + _Size), _Color, Vector2.zero);
            vh.AddTriangle(vertexOffset, vertexOffset + 1, vertexOffset + 2);
            vh.AddTriangle(vertexOffset + 2, vertexOffset + 3, vertexOffset);
        }

        public SquarePointCommand(Vector2 pos, float size, Color color) : base(pos, size, color)
        {
        }
    }
}