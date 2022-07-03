using FluffyGamedev.Stats.Data;
using System.Collections.Generic;

namespace FluffyGamedev.Stats.Runtime
{
    public class StatContainerInstance
    {
        private Dictionary<StatDescriptor, StatInstance> m_Stats;

        public int statCount => m_Stats.Count;

        public StatContainerInstance(StatContainerDescriptor descriptor)
        {
            m_Stats = new(descriptor.stats.Count);
            foreach (StatDescriptor statDescriptor in descriptor.stats)
            {
                m_Stats[statDescriptor] = new StatInstance(statDescriptor);
            }
        }

        public StatInstance GetStat(StatDescriptor statDescriptor)
        {
            StatInstance stat;
            m_Stats.TryGetValue(statDescriptor, out stat);
            return stat;
        }
    }
}
