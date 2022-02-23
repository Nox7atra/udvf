using UDVF.Runtime.Scripts.Charts.RenderCommands;
using UnityEngine;

namespace UDVF.Runtime.Scripts.Charts.CoordinateCharts
{
    public class PointChart : CoordinateChart
    {
        [SerializeField] private float _PointSize = 5;
        [SerializeField] private Color _PointColor = Color.yellow;
        protected override void DrawElement(Vector2 pos)
        {
            _RenderBuffer.Add(ChartRenderCommand.Create(_chartPointType, pos, _PointSize, _PointColor));
        }
    }
}
