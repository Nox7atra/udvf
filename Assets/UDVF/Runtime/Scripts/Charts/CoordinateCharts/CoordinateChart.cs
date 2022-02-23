using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UDVF.Runtime.Scripts.Charts.CoordinateCharts
{
    public abstract class CoordinateChart : ChartBase, IDragHandler, IScrollHandler
    {        
        [SerializeField] private float _MinZoom = 0.2f;
        [SerializeField] private float _MaxZoom = 15;
        [SerializeField] private float _DragSensitivity = 0.1f;
        [SerializeField] private float _ScrollSensitivity = 5;
        [SerializeField] private float _CurrentZoom = 0.9f;
        [SerializeField] private Vector2 _Offset;
        
        protected IEnumerable<Vector2> _data;
        protected Vector2 _Min;
        protected Vector2 _Max;
        public void LoadData(IEnumerable<Vector2> data)
        {
            _data = data.OrderBy(v=> v.x);
            CalculateBounds(data);
            UpdateData();
        }
        
        protected override void ProcessBuffer()
        {
            if (_data == null) return;
            foreach (var v in _data)
            {
                DrawElement(GetRealChartPos(CalcNormal(v)));
            }
        }

        private void CalculateBounds(IEnumerable<Vector2> data)
        {
            _Min = new Vector2(data.Min(v=>v.x), data.Min(v=>v.y));
            _Max = new Vector2(data.Max(v=>v.x), data.Max(v=>v.y));
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
        
        
        protected abstract void DrawElement(Vector2 pos);
    }
}
