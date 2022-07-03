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
        private UnityEvent<float> m_Event;

        private StatContainerInstance m_StatContainer = null;

        private void Start()
        {
            //TODO
        }

        private void OnDisable()
        {
            //TODO
        }
    }
}
