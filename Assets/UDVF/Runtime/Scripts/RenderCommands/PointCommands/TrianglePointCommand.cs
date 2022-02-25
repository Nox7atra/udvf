using UDVF.Runtime.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands.PointCommands
{
    public class TrianglePointCommand : PointCommand
    {
        public TrianglePointCommand(Vector2 pos, float size, Color color, int sortingOrder) : base(pos, size, color, sortingOrder)
        {
        }

        public override void Render(VertexHelper vh)
        {
            base.Render(vh);
            MeshGenerator.RenderTriangle(vh, _Position, _Size, _Color);
        }
    }
}