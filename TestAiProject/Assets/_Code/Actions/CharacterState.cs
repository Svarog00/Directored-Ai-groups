using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Other;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using AiLibrary.Other;
using System;

[Serializable]
public class CharacterState : IAgentState
{
    [field: SerializeField] public float MaxHealth { get; set; }
    [field: SerializeField] public float MaxRest { get; set; }
    
    public GroupId GroupId { get; private set; }
    public int AgentId { get; private set; }
    public System.Numerics.Vector3 CurrentPosition { get; private set; }
    [field: SerializeField] public float CurrentHealth { get; private set; }
    [field: SerializeField] public float CurrentRest { get; private set; }
    public IAgentState CurrentTarget { get; private set; }
    public Item CurrentHand { get; private set; }
    public List<Item> Items { get; private set; }
    public System.Numerics.Vector3 TargetPosition { get; private set; }

    public void SetAgentId(int id) => AgentId = id;
    public void SetGroupId(GroupId id) => GroupId = id;
    public void SetHealth(float health) => CurrentHealth = health;
    public void SetRest(float rest) => CurrentRest = rest;
    public void SetPosition(System.Numerics.Vector3 position) => CurrentPosition = position;
    public void SetTargetPosition(System.Numerics.Vector3 position)
    {
        AiLogger.Log($"Agent {AgentId} must go to {position}");
        TargetPosition = position;
    }

    public void SetTarget(IAgentState target) => CurrentTarget = target;
    public void SetItems(List<Item> items) => Items = items;
    public void Equip(Item item) => CurrentHand = item;

    public void SetPosition(UnityEngine.Vector3 position) => CurrentPosition = new System.Numerics.Vector3(position.x, position.y, position.z);
}
