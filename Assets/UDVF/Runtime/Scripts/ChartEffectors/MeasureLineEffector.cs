using System;
using System.Collections.Generic;
using UDVF.Runtime.Scripts.Charts;
using UDVF.Runtime.Scripts.Charts.CoordinateCharts;
using UDVF.Runtime.Scripts.Charts.RenderCommands;
using UDVF.Runtime.Scripts.Charts.RenderCommands.LineCommands;
using UnityEngine;

namespace UDVF.Runtime.Scripts.ChartEffectors
{
    [RequireComponent(typeof(CoordinateChart))]
    public class MeasureLineEffector : ChartEffector
    {
        private const float _LineOffset = 3;
        [SerializeField] private float _Size = 1;
        [SerializeField] private Color _Color = Color.grey;
        [SerializeField] private int _SoringOrder = -1;
        [SerializeField, Range(0.05f, 0.5f)] private float _Step = 0.1f;
        public override List<ChartRenderCommand> GenerateRenderCommands(ChartBase chartBase)
        {
            var result = new List<ChartRenderCommand>();
            int count = (int) (_LineOffset / _Step);
            result.Add(new LineCommand(
                chartBase.GetRealChartPos(new Vector2(-_LineOffset, 0)),
                chartBase.GetRealChartPos(new Vector2(_LineOffset, 0)),
                _Size * 2,
                _Color
            ) {SortingOrder = _SoringOrder});
            result.Add(new LineCommand(
                chartBase.GetRealChartPos(new Vector2(0, -_LineOffset)),
                chartBase.GetRealChartPos(new Vector2(0, _LineOffset)),
                _Size * 2,
                _Color
            ) {SortingOrder = _SoringOrder});
            for (int i = 0; i < count; i++)
            {
                result.Add(new LineCommand(
                    chartBase.GetRealChartPos(new Vector2(-_LineOffset, (i - count / 2 )*_Step)),
                    chartBase.GetRealChartPos(new Vector2(_LineOffset, (i - count / 2 )*_Step)),
                    _Size,
                    _Color
                ) {SortingOrder = _SoringOrder});
            }
            return result;
        }
        
    }
}