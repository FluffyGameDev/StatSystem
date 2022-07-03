using FluffyGamedev.Stats.Data;
using FluffyGamedev.Stats.Runtime;
using NUnit.Framework;
using UnityEngine;

public class StatInstance_UnitTests
{
    [SerializeField]
    private StatDescriptor m_StatDescriptor;

    [Test]
    public void StatInstance_Tests()
    {
        StatDescriptor statDescriptor = ScriptableObject.CreateInstance<StatDescriptor>();
        statDescriptor.defaultBaseValue = 100;
        StatInstance stat = new(statDescriptor);

        Assert.AreEqual(stat.baseValue, statDescriptor.defaultBaseValue);
        Assert.AreEqual(stat.statValue, stat.baseValue);

        bool hasValueChanged = false;
        stat.onValueChanged += _ => hasValueChanged = true;

        StatModifier addModifier = new(StatModifier.ModifierType.Addition, 10);
        StatModifier mulModifier = new(StatModifier.ModifierType.Multiplication, 2);

        stat.AddModifier(addModifier);
        Assert.IsTrue(hasValueChanged);
        Assert.AreEqual(stat.statValue, 110);
        hasValueChanged = false;

        stat.AddModifier(mulModifier);
        Assert.IsTrue(hasValueChanged);
        Assert.AreEqual(stat.statValue, 220);
        hasValueChanged = false;

        stat.baseValue = 200;
        Assert.IsTrue(hasValueChanged);
        Assert.AreEqual(stat.statValue, 420);
        hasValueChanged = false;

        stat.RemoveModifier(addModifier);
        Assert.IsTrue(hasValueChanged);
        Assert.AreEqual(stat.statValue, 400);
        hasValueChanged = false;
    }
}
