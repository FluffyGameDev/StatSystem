using FluffyGamedev.Stats.Data;
using FluffyGamedev.Stats.Runtime;
using NUnit.Framework;
using UnityEngine;

public class StatContainerInstance_UnitTests
{
    [Test]
    public void StatContainerInstance_Tests()
    {
        StatDescriptor statDescriptorA = ScriptableObject.CreateInstance<StatDescriptor>();
        StatDescriptor statDescriptorB = ScriptableObject.CreateInstance<StatDescriptor>();
        StatDescriptor statDescriptorC = ScriptableObject.CreateInstance<StatDescriptor>();
        StatDescriptor statDescriptorD = ScriptableObject.CreateInstance<StatDescriptor>();

        StatContainerDescriptor statContainerDescriptor = ScriptableObject.CreateInstance<StatContainerDescriptor>();
        statContainerDescriptor.stats.Add(statDescriptorA);
        statContainerDescriptor.stats.Add(statDescriptorB);
        statContainerDescriptor.stats.Add(statDescriptorC);

        StatContainerInstance statContainer = new(statContainerDescriptor);
        Assert.AreEqual(statContainer.statCount, 3);
        Assert.IsNotNull(statContainer.GetStat(statDescriptorA));
        Assert.IsNotNull(statContainer.GetStat(statDescriptorB));
        Assert.IsNotNull(statContainer.GetStat(statDescriptorC));
        Assert.IsNull(statContainer.GetStat(statDescriptorD));
    }
}
