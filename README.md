# StatsSystem
System that allows user to create and edit stats.

## Installation
- Copy the link to this git repository.
- Open the *Package Manager* in Unity.
- Add this repository as a dependency.

## System Basics
StatDescriptor is a Scriptable Object used to define a specific stat. Consider it like a enum value. For example, creating a "Strength" or "HealthMax" StatDescriptor.
StatContainerDescriptor is a similar concept, but for a List of StatDescriptors that apply to a game object. For example, a "Player" StatContainerDescriptor could have "Strength", "HealthMax" and "Reputation" while an "Enemy" could have only "Strength" and "HealthMax"

StatsHolder is a monobehavior that holds the relevant stats for that game object. It uses a StatContainerDescriptor to make a StatContainerInstance. That uses the list of StatDescriptors from the StatContainerDescriptor to create StatInstances.
StatContainerInstance and StatInstance are implementations of the StatContainerDescriptor and StatDescriptor. StatInstance saves the current stat value and StatContainerInstance stores the list of those StatInstances.

StatListener is a monobehavior that connects to a specific StatInstance on a specific StatHolder and triggers an UnityEvent<float> when that stat is changed.

Essentially: Use StatDecriptor to make a new stat type. Use StatContainerDescriptor to make a new list of stats a game object has. Use StatsHolder to contain and reference stats to a specific game object. Use StatListener to respond to stat changes.

## Using Stats
Each stat cannot be modified on its own: a monobehavior component needs to be created to handle one or more stats. 

For example, a Health Component:
-uses Health and HealthMax StatDescriptors
-links to a StatHolder on the gameobject
-values are stored on float m_HPStat and m_HPMax and StatListeners listen to those values
-public methods DamageEntity(float damageAmount) and HealEntity(float healAmount) add or subtract damage from a private float m_SustainedDamage. This is how health is affected.
-whenever a stat or the damage changes, the current hp is calculated. StatListeners are automatically triggered. Additional events could be triggered.

For example, a Text Displaying a Stat's value
-Copying StatListener, but converts the response from a stat's response from float to string
-in the inspector, link the text object's "text" property to the dynamic response from StatListener

## Modifiers
TODO