using System;
using System.Collections.Generic;
using UDVF.Runtime.Scripts.Charts.CoordinateCharts;
using UnityEngine;

namespace UDVF.Runtime.Scripts.DataLoaders
{
    [RequireComponent(typeof(CoordinateChartRenderer))]
    public class CoordinateDataLoader : MonoBehaviour
    {
        [SerializeField] private List<CoordinateChartDataSO> _charts;

        private void OnValidate()
        {
            var chartRenderer = GetComponent<CoordinateChartRenderer>();
            chartRenderer.Clear();
            foreach (var chartDataSo in _charts)
            {
                chartRenderer.LoadData(chartDataSo.Source);
            }
        }
        [ContextMenu("Generate Random Data")]
        private void GenerateRandomData()
        {
            foreach (var chartDataSo in _charts)
            {
                chartDataSo.GenerateRandomData();
            }
        }
    }
}