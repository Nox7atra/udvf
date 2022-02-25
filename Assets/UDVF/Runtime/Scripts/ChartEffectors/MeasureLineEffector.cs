using System;
using System.Collections.Generic;
using UDVF.Runtime.Scripts.Charts;
using UDVF.Runtime.Scripts.Charts.CoordinateCharts;
using UDVF.Runtime.Scripts.Charts.RenderCommands;
using UDVF.Runtime.Scripts.Charts.RenderCommands.LineCommands;
using UnityEngine;

namespace UDVF.Runtime.Scripts.ChartEffectors
{
    [RequireComponent(typeof(CoordinateChartRenderer))]
    public class MeasureLineEffector : ChartEffector
    {
        private const float _LineOffset = 1000;
        [SerializeField] private float _Size = 1;
        [SerializeField] private Color _Color = Color.grey;
        [SerializeField] private int _SoringOrder = -1;
        [SerializeField, Range(5f, 100)] private float _Step = 5f;
        public override List<ChartRenderCommand> GenerateRenderCommands(ChartBaseRenderer chartBaseRenderer)
        {
            var result = new List<ChartRenderCommand>();
            int count = (int) (_LineOffset / _Step);
            result.Add(new LineCommand(new Vector2(-_LineOffset, 0),
                new Vector2(_LineOffset, 0),
                _Size * 2,
                _Color,
                _SoringOrder
            ));
            result.Add(new LineCommand(new Vector2(0, -_LineOffset),
                new Vector2(0, _LineOffset),
                _Size * 2,
                _Color,
                _SoringOrder
            ) );
            for (int i = 0; i < count; i++)
            {
                result.Add(new LineCommand(
                    new Vector2(-_LineOffset, (i - count / 2 )*_Step),
                    new Vector2(_LineOffset, (i - count / 2 )*_Step),
                    _Size,
                    _Color,
                    _SoringOrder
                ) );
            }
            return result;
        }
        
    }
}