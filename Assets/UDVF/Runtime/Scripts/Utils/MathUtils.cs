using UnityEngine;

namespace UDVF.Runtime.Scripts.Utils
{
    public static class MathUtils
    {
        public static Vector2 GetPointOnCircle(Vector2 center, float radius, float angle)
        {
            return new Vector2(
                center.x + radius * Mathf.Cos(angle),
                center.y + radius * Mathf.Sin(angle)
            );
        }
    }
}