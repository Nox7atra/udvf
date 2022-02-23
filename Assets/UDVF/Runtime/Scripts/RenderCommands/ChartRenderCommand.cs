using UDVF.Runtime.Scripts.Charts.RenderCommands.PointCommands;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.RenderCommands
{
    public abstract class ChartRenderCommand
    {
        public int SortingOrder;
        public abstract void Render(VertexHelper vh);

        public static ChartRenderCommand Create(ChartPointCommandType type, Vector2 pos, float size, Color color)
        {
            switch (type)
            {
                default:
                case ChartPointCommandType.Square:
                    return new SquarePointCommand(pos, size, color) { SortingOrder = Constants.PointsSoringOrder};
                case ChartPointCommandType.Circle:
                    return new CirclePointCommand(pos, size, color) {SortingOrder = Constants.PointsSoringOrder};
                case ChartPointCommandType.Triangle:
                    return new TrianglePointCommand(pos, size, color) {SortingOrder = Constants.PointsSoringOrder};
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
