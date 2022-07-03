using System;

namespace FluffyGamedev.Stats.Data
{
    [Serializable]
    public class StatModifier
    {
        public enum ModifierType
        {
            Addition,
            Multiplication
        }

        private float m_ModifierValue;
        public float modifierValue => m_ModifierValue;

        private ModifierType m_Type;
        public ModifierType type => m_Type;

        public float ComputeModification(float inputValue)
        {
            return m_Type switch
            {
                ModifierType.Addition => inputValue + m_ModifierValue,
                ModifierType.Multiplication => inputValue * m_ModifierValue,
                _ => inputValue
            };
        }

        public StatModifier()
        {
        }

        public StatModifier(ModifierType type, float value)
        {
            m_Type = type;
            m_ModifierValue = value;
        }
    }
}
