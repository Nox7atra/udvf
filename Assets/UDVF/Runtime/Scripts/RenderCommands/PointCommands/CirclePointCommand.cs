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
 
            var vertexCenter = vh.currentVertCount;
            vh.AddVert(_Position, _Color, Vector4.zero);
            vh.AddVert(MathUtils.GetPointOnCircle(_Position, _Size,0), _Color, Vector4.zero);
            for (int i = 1; i <= Constants.CirclesPointsSegmentCount; i++)
            {
                var vertexOffset = vh.currentVertCount - 1;
                var angle = i / (float)Constants.CirclesPointsSegmentCount * 360;
                vh.AddVert(MathUtils.GetPointOnCircle(_Position, _Size,angle), _Color, Vector4.zero);
                vh.AddTriangle(vertexCenter, vertexOffset, vertexOffset + 1);
            }
        }
    }
}