using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Other;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class CharacterState : ScriptableObject, IAgentState
{
    [field: SerializeField] public float MaxHealth { get; }
    [field: SerializeField] public float MaxRest { get; }
    
    public GroupId GroupId { get; private set; }
    public System.Numerics.Vector3 CurrentPosition { get; private set; }
    public float CurrentHealth { get; private set; }
    public float CurrentRest { get; private set; }
    public IAgentState CurrentTarget { get; private set; }
    public Item CurrentHand { get; private set; }
    public List<Item> Items { get; private set; }

    public void SetGroupId(GroupId id) => GroupId = id;
    public void SetHealth(float health) => CurrentHealth = health;
    public void SetRest(float rest) => CurrentRest = rest;
    public void SetPosition(System.Numerics.Vector3 position) => CurrentPosition = position;
    public void SetTarget(IAgentState target) => CurrentTarget = target;
    public void SetItems(List<Item> items) => Items = items;
    public void Equip(Item item) => CurrentHand = item;

    public void SetPosition(UnityEngine.Vector3 position) => CurrentPosition = new System.Numerics.Vector3(position.x, position.y, position.z);
}
