using UDVF.Runtime.Scripts.Charts.RenderCommands.LineCommands;
using UnityEngine;
using UnityEngine.UI;

namespace UDVF.Runtime.Scripts.Charts.CoordinateCharts
{
    public class LineChart : PointChart
    {
        [SerializeField] private Color _LineColor = Color.blue;
        [SerializeField] private float _LineSize = 2;

        protected override void ProcessBuffer()
        {
            if (_data == null) return;
            base.ProcessBuffer();
            Vector2? next = null;
            foreach (var current in _data)
            {
                if (next.HasValue)
                {
                    var nextNormalized = CalcNormal(next.Value);
                    _RenderBuffer.Add(
                        new LineCommand(
                            GetRealChartPos(CalcNormal(current)), 
                            GetRealChartPos(nextNormalized),
                            _LineSize,
                            _LineColor) 
                            {SortingOrder = Constants.LineSortingOrder});
                }
                next = current;
            }
        }
    }
}