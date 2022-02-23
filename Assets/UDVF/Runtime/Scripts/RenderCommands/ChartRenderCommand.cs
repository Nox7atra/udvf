using UDVF.Runtime.Scripts.Charts.RenderCommands.PointCommands;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands
{
    public abstract class ChartRenderCommand
    {
        protected int _SortingOrder;
        public int SortingOrder => _SortingOrder;
        public abstract void Render(VertexHelper vh);

        public static ChartRenderCommand Create(ChartPointCommandType type, Vector2 pos, float size, Color color, int sortingOrder)
        {
            switch (type)
            {
                default:
                case ChartPointCommandType.Square:
                    return new SquarePointCommand(pos, size, color, sortingOrder);
                case ChartPointCommandType.Circle:
                    return new CirclePointCommand(pos, size, color, sortingOrder);
                case ChartPointCommandType.Triangle:
                    return new TrianglePointCommand(pos, size, color, sortingOrder);
            }
        }
    }

    public enum ChartPointCommandType
    {
        Square = 0,
        Circle = 1,
        Triangle = 2
    }
}
