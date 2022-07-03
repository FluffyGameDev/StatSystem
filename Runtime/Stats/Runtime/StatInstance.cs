using FluffyGamedev.Stats.Data;
using System;
using System.Collections.Generic;

namespace FluffyGamedev.Stats.Runtime
{
    public class StatInstance
    {
        private List<StatModifier> m_Modifiers = new();
        private float m_BaseValue;
        private float m_StatValue;


        public event Action<float> onValueChanged;
        public float statValue => m_StatValue;

        public float baseValue
        {
            get { return m_BaseValue; }
            set
            {
                if (m_BaseValue != value)
                {
                    m_BaseValue = value;
                    ComputeModifiedValue();
                }
            }
        }

        public StatInstance(StatDescriptor statDescriptor)
        {
            m_BaseValue = statDescriptor.defaultBaseValue;
            m_StatValue = m_BaseValue;
        }

        public void AddModifier(StatModifier modifier)
        {
            m_Modifiers.Add(modifier);
            ComputeModifiedValue();
        }

        public void RemoveModifier(StatModifier modifier)
        {
            m_Modifiers.Remove(modifier);
            ComputeModifiedValue();
        }


        private void ComputeModifiedValue()
        {
            float oldValue = m_StatValue;
            m_StatValue = m_BaseValue;
            foreach (StatModifier modifier in m_Modifiers)
            {
                m_StatValue = modifier.ComputeModification(m_StatValue);
            }

            if (m_StatValue != oldValue)
            {
                onValueChanged?.Invoke(m_StatValue);
            }
        }
    }
}
