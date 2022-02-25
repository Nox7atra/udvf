using UDVF.Runtime.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands.PointCommands
{
    public class SquarePointCommand : PointCommand
    {
        public override void Render(VertexHelper vh)
        {
            base.Render(vh);
            MeshGenerator.RenderSquare(vh, _Position, _Size, _Color);
        }

        public SquarePointCommand(Vector2 pos, float size, Color color, int sortingOrder) : base(pos, size, color, sortingOrder)
        {
        }
    }
}