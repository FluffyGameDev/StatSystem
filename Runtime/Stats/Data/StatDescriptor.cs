using UnityEngine;

namespace FluffyGamedev.Stats.Data
{
    [CreateAssetMenu]
    public class StatDescriptor : ScriptableObject
    {
        [SerializeField]
        private float m_DefaultBaseValue;

        public float defaultBaseValue
        {
            get { return m_DefaultBaseValue; }
#if UNITY_INCLUDE_TESTS
            set { m_DefaultBaseValue = value; }
#endif
        }
    }
}
