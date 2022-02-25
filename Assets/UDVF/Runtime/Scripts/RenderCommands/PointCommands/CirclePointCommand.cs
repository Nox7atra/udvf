using UDVF.Runtime.Scripts.Helpers;
using UDVF.Runtime.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands.PointCommands
{
    public class CirclePointCommand : PointCommand
    {
        public CirclePointCommand(Vector2 pos, float size, Color color, int sortingOrder) : base(pos, size, color, sortingOrder)
        {
        }

        public override void Render(VertexHelper vh)
        {
            base.Render(vh);
            MeshGenerator.RenderCircle(vh, _Position, _Size, _Color);
        }
    }
}