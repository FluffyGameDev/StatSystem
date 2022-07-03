using FluffyGamedev.Stats.Data;
using FluffyGamedev.Stats.Runtime;
using UnityEngine;
using UnityEngine.Events;

namespace FluffyGamedev.Stats.Components
{
    public class StatListener : MonoBehaviour
    {
        [SerializeField]
        private StatDescriptor m_WatchedStat;
        [SerializeField]
        private StatsHolder m_WatchedStatHolder;
        [SerializeField]
        private UnityEvent<float> m_Event;

        private void Start()
        {
            m_WatchedStatHolder.statContainer.GetStat(m_WatchedStat).onValueChanged += m_Event.Invoke;
        }

        private void OnDisable()
        {
            m_WatchedStatHolder.statContainer.GetStat(m_WatchedStat).onValueChanged -= m_Event.Invoke;
        }
    }
}
