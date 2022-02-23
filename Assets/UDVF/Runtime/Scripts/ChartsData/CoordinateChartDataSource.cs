using System;
using System.Collections.Generic;
using UDVF.Runtime.Scripts.Charts.RenderCommands;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UDVF.Runtime.Scripts.Charts.CoordinateCharts
{
    [CreateAssetMenu]
    public class CoordinateChartDataSO : ScriptableObject
    {
        [SerializeField] private int _DataMinGenerate = 10;
        [SerializeField] private int _DataMaxGenerate = 25;
        public CoordinateChartData Source;
        
        public void GenerateRandomData()
        {
            var count = Random.Range(_DataMinGenerate, _DataMaxGenerate);
            Source.Points = new List<Vector2>(count);
            for (int i = 0; i < count; i++)
            {
                Source.Points.Add(new Vector2(Random.Range(0, 100f), Random.Range(0, 100f)));
            }
            Source.Points.Sort((v1, v2) => v1.x > v2.x ? 1 : -1);
        }
    }
    [Serializable]
    public class CoordinateChartData
    {
        public List<Vector2> Points;
        public bool IsLinesConnected;
        public CoordinateChartStyle Style;
        public ChartPointCommandType Type;
    }
    [Serializable]
    public class CoordinateChartStyle
    {
        public float Size = 5;
        public Color Color = Color.yellow;
        public float LineSize = 3;
        public Color LineColor = Color.green;
    }
}