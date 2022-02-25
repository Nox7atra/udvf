using UDVF.Runtime.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Helpers
{
    public static class MeshGenerator
    {
        public static void RenderLine(VertexHelper vh, Vector2 start, Vector2 end, float size, Color color)
        {
            var uvVectorLeft = new Vector2(0, size);
            var uvVectorRight= new Vector2(1, size);
            var vertexOffset = vh.currentVertCount;
            var normal = new Vector2(end.y - start.y, start.x - end.x).normalized;
            vh.AddVert(start + normal * size, color, uvVectorRight);
            vh.AddVert(start - normal * size, color, uvVectorLeft);
            vh.AddVert(end - normal * size, color, uvVectorLeft);
            vh.AddVert(end + normal * size, color, uvVectorRight);
            vh.AddTriangle(vertexOffset, vertexOffset + 1, vertexOffset + 2);
            vh.AddTriangle(vertexOffset + 2, vertexOffset + 3, vertexOffset);
        }

        public static void RenderCircle(VertexHelper vh, Vector2 pos, float size, Color color)
        {
            var vertexCenter = vh.currentVertCount;
            var uvCenter = new Vector2(0.5f, size);
            var uvEdge = new Vector2(0, size);
            
            vh.AddVert(pos, color, uvCenter);
            vh.AddVert(MathUtils.GetPointOnCircle(pos, size,0), color, uvEdge);
            for (int i = 1; i <= Constants.CirclesPointsSegmentCount; i++)
            {
                var vertexOffset = vh.currentVertCount - 1;
                var angle = i / (float)Constants.CirclesPointsSegmentCount * 360;
                vh.AddVert(MathUtils.GetPointOnCircle(pos, size,angle), color, uvEdge);
                vh.AddTriangle(vertexCenter, vertexOffset, vertexOffset + 1);
            }

        }

        public static void RenderSquare(VertexHelper vh, Vector2 pos, float size, Color color)
        {
            var vertexCenter = vh.currentVertCount;
            var uvCenter = new Vector2(0.5f, size);
            var uvEdge = new Vector2(0, size);
      
            vh.AddVert(pos, color, uvCenter);
            vh.AddVert(new Vector3(pos.x - size, pos.y - size), color, uvEdge);
            vh.AddVert(new Vector3(pos.x + size, pos.y - size), color, uvEdge);
            vh.AddVert(new Vector3(pos.x + size, pos.y + size), color, uvEdge);
            vh.AddVert(new Vector3(pos.x - size, pos.y + size), color, uvEdge);
            vh.AddTriangle(vertexCenter, vertexCenter + 1, vertexCenter + 2);
            vh.AddTriangle(vertexCenter, vertexCenter + 2, vertexCenter + 3);
            vh.AddTriangle(vertexCenter, vertexCenter + 3, vertexCenter + 4);
            vh.AddTriangle(vertexCenter, vertexCenter + 4, vertexCenter + 1);
        }

        public static void RenderTriangle(VertexHelper vh, Vector2 pos, float size, Color color)
        {
            var vertexCenter = vh.currentVertCount;
            var uvCenter = new Vector2(0.5f, size);
            var uvEdge = new Vector2(0, size);
            
            vh.AddVert(pos, color, uvCenter);
            vh.AddVert(pos + Vector2.right * size + Vector2.up *size / 2, color, uvEdge);
            vh.AddVert(pos + Vector2.left * size + Vector2.up *size /2, color, uvEdge);
            vh.AddVert(pos + Vector2.down * size, color, uvEdge);
            vh.AddTriangle(vertexCenter, vertexCenter + 1, vertexCenter + 2);
            vh.AddTriangle(vertexCenter, vertexCenter + 2, vertexCenter + 3);
            vh.AddTriangle(vertexCenter, vertexCenter + 3, vertexCenter + 1);
        }
    }
}