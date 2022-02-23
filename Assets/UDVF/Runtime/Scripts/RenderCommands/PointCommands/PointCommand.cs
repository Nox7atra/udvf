using UnityEngine;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands.PointCommands
{
    public abstract class PointCommand : ChartRenderCommand
    {
        protected Vector2 _Position;
        protected float _Size;
        protected Color _Color;

        public PointCommand(Vector2 pos, float size, Color color, int sortingOrder)
        {
            _Position = pos;
            _Size = size;
            _Color = color;
            _SortingOrder = sortingOrder;
        }
    }
}