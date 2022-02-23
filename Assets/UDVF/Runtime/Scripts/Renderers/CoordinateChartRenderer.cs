using System;
using System.Collections.Generic;
using System.Linq;
using UDVF.Runtime.Scripts.Charts.RenderCommands;
using UDVF.Runtime.Scripts.Charts.RenderCommands.LineCommands;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UDVF.Runtime.Scripts.Charts.CoordinateCharts
{
    public class CoordinateChartRenderer : ChartBaseRenderer, IDragHandler, IScrollHandler
    {        
        [SerializeField] private float _MinZoom = 0.2f;
        [SerializeField] private float _MaxZoom = 15;
        [SerializeField] private float _DragSensitivity = 0.1f;
        [SerializeField] private float _ScrollSensitivity = 5;
        [SerializeField] private float _CurrentZoom = 0.9f;
        [SerializeField] private Vector2 _Offset;
        
        protected List<CoordinateChartData> _Charts = new List<CoordinateChartData>();
        protected Vector2 _Min;
        protected Vector2 _Max;

        public void Clear()
        {
            _Charts.Clear();
        }
        public void LoadData(CoordinateChartData data)
        {
            _Charts.Add(data);
            UpdateData();
        }

        private void CalculateBounds()
        {
            float minX = Single.MaxValue;
            float minY = Single.MaxValue;
            float maxX = Single.MinValue;
            float maxY = Single.MinValue;
            foreach (var chartData in _Charts)
            {
                var value = chartData.Points.Min(v => v.x);
                if (minX < value)
                {
                    minX = value;
                }
                value = chartData.Points.Min(v => v.y);
                if (minY < value)
                {
                    minY = value;
                }
                value = chartData.Points.Max(v => v.x);
                if (maxX < value)
                {
                    maxX = value;
                }
                value = chartData.Points.Max(v => v.y);
                if (maxY < value)
                {
                    maxY = value;
                }
            }

            _Min = new Vector2(minX, minY);
            _Min = new Vector2(maxX, maxY);
        }
        protected override void ProcessBuffer()
        {
            if (_Charts == null) return;
            CalculateBounds();
            for (var i = 0; i < _Charts.Count; i++)
            {
                var chartData = _Charts[i];
                Vector2? next = null;
                foreach (var coordData in chartData.Points)
                {
                    _RenderBuffer.Add(ChartRenderCommand.Create(
                        chartData.Type,
                        GetRealChartPos(CalcNormal(coordData)),
                        chartData.Style.Size,
                        chartData.Style.Color,
                        Constants.PointsSoringOrder + i * Constants.LayerStep));
                    if (chartData.IsLinesConnected)
                    {
                        if (next.HasValue)
                        {
                            _RenderBuffer.Add(new LineCommand(
                                GetRealChartPos(CalcNormal(coordData)),
                                GetRealChartPos(CalcNormal(next.Value)),
                                chartData.Style.LineSize,
                                chartData.Style.LineColor,
                                Constants.LineSortingOrder + i * Constants.LayerStep
                            ));
                        }

                        next = coordData;
                    }
                }
            }
        }
        
        protected Vector2 CalcNormal(Vector2 value)
        {
            var result = new Vector2();
            for (int i = 0; i < 2; i++)
            {
                result[i] = (value[i] - _Min[i]) / (_Max[i] - _Min[i]);
            }
            return result;
        }

        public override Vector2 GetRealChartPos(Vector2 normalizedPos)
        {
            normalizedPos = new Vector2(
                normalizedPos.x* _CurrentZoom + (1 -_CurrentZoom) / 2 + _Offset.x,
                normalizedPos.y* _CurrentZoom + (1 -_CurrentZoom) / 2 + _Offset.y
                );
            return base.GetRealChartPos(normalizedPos);
        }

        private void SetScale(float scale)
        {
            _CurrentZoom = Mathf.Clamp(scale, _MinZoom, _MaxZoom);
            SetOffset(_Offset);
            UpdateData();
        }

        private void SetOffset(Vector2 offset)
        {
            var min = -0.5f * _CurrentZoom;
            var max = 0.5f * _CurrentZoom;
            _Offset = new Vector2(
                Mathf.Clamp(offset.x,  min, max),
                Mathf.Clamp(offset.y, min, max)
            );
            UpdateData();
        }

        public void OnDrag(PointerEventData eventData)
        {
            var delta = _DragSensitivity * eventData.delta * Time.deltaTime;
            SetOffset(new Vector2(
                _Offset.x + delta.x,
                _Offset.y + delta.y
                ));
        }

        public void OnScroll(PointerEventData eventData)
        {
            SetScale(_CurrentZoom + _ScrollSensitivity * eventData.scrollDelta.y * Time.deltaTime);
        }
    }
}
