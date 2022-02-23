using UDVF.Runtime.Scripts.Charts.RenderCommands.LineCommands;
using UnityEngine;
namespace UDVF.Runtime.Scripts.Charts.CoordinateCharts
{
    public class BarChart : CoordinateChart
    {
        [SerializeField] private float _BarSize = 5;
        [SerializeField] private Color _BarColor = Color.yellow;
        protected override void DrawElement(Vector2 pos)
        {
            var p1 = GetRealChartPos(new Vector2(0, 0));
            p1.x = pos.x;
            _RenderBuffer.Add(new LineCommand(
                p1,
                pos,
                _BarSize,
                _BarColor) {SortingOrder = Constants.PointsSoringOrder});
        }
    }
}