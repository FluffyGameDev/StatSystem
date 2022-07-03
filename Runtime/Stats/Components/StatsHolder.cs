using FluffyGamedev.Stats.Data;
using FluffyGamedev.Stats.Runtime;
using UnityEngine;

namespace FluffyGamedev.Stats.Components
{
    public class StatsHolder : MonoBehaviour
    {
        [SerializeField]
        private StatContainerDescriptor m_StatContainerDescriptor;

        private StatContainerInstance m_StatContainer = null;
        public StatContainerInstance statContainer => m_StatContainer;

        private void Awake()
        {
            m_StatContainer = new(m_StatContainerDescriptor);
        }
    }
}
