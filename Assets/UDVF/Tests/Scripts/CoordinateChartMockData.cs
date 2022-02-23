using System;
using System.Collections.Generic;
using System.Linq;
using UDVF.Runtime.Scripts.Charts.CoordinateCharts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UDVF.Tests.Scripts
{
    [RequireComponent(typeof(CoordinateChart))]
    public class CoordinateChartMockData : MonoBehaviour
    {
        [SerializeField] private int _DataMinGenerate = 10;
        [SerializeField] private int _DataMaxGenerate = 25;
        [SerializeField] private List<Vector2> _TestData;
        private void OnValidate()
        {
            GenerateRandomData();
        }

        [ContextMenu("Generate Random Data")]
        private void GenerateRandomData()
        {
            var count = Random.Range(_DataMinGenerate, _DataMaxGenerate);
            _TestData = new List<Vector2>(count);
            for (int i = 0; i < count; i++)
            {
                _TestData.Add(new Vector2(Random.Range(0, 100f), Random.Range(0, 100f)));
            }
            _TestData.Sort((v1, v2) => v1.x > v2.x ? 1 : -1);
            var chart = GetComponent<CoordinateChart>();
            chart.LoadData(_TestData);
        }
    }
}
