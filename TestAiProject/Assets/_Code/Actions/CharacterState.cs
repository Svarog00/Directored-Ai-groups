using InteractableGroupsAi.Agents;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : ScriptableObject, IAgentContext
{
    [field: SerializeField] public float MaxHealth { get; }
    [field: SerializeField] public float MaxRest { get; }
    
    public GroupId GroupId { get; private set; }
    public Vector3 CurrentPosition { get; private set; }
    public float CurrentHealth { get; private set; }
    public float CurrentRest { get; private set; }
    public CharacterState CurrentTarget { get; private set; }
    public List<Item> Items { get; private set; }

    public void SetGroupId(GroupId id) => GroupId = id;
    public void SetHealth(float health) => CurrentHealth = health;
    public void SetRest(float rest) => CurrentRest = rest;
    public void SetPosition(Vector3 position) => CurrentPosition = position;
    public void SetTarget(CharacterState target) => CurrentTarget = target;
    public void SetItems(List<Item> items) => Items = items;
}
