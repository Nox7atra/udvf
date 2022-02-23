using System;
using System.Collections.Generic;
using UDVF.Runtime.Scripts.Charts;
using UDVF.Runtime.Scripts.Charts.RenderCommands;
using UnityEngine;

namespace UDVF.Runtime.Scripts.ChartEffectors
{
    [RequireComponent(typeof(ChartBaseRenderer))]
    public abstract class ChartEffector : MonoBehaviour
    {
        private void OnValidate()
        {
            var chart = GetComponent<ChartBaseRenderer>();
            chart.UpdateData();
        }

        public abstract List<ChartRenderCommand> GenerateRenderCommands(ChartBaseRenderer chartBaseRenderer);
    }
}
