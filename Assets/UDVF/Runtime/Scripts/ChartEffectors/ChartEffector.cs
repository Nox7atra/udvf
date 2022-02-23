using System;
using System.Collections.Generic;
using UDVF.Runtime.Scripts.Charts;
using UDVF.Runtime.Scripts.Charts.RenderCommands;
using UnityEngine;

namespace UDVF.Runtime.Scripts.ChartEffectors
{
    [RequireComponent(typeof(ChartBase))]
    public abstract class ChartEffector : MonoBehaviour
    {
        private void OnValidate()
        {
            var chart = GetComponent<ChartBase>();
            chart.UpdateData();
        }

        public abstract List<ChartRenderCommand> GenerateRenderCommands(ChartBase chartBase);
    }
}
