using System.Collections.Generic;
using UnityEngine;

namespace FluffyGamedev.Stats.Data
{
    [CreateAssetMenu]
    public class StatContainerDescriptor : ScriptableObject
    {
        [SerializeField]
        private List<StatDescriptor> m_Stats = new();
        public List<StatDescriptor> stats => m_Stats;
    }
}
