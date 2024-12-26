using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using UnityEngine;

public class PositionCondition : AgentCondition
{
    private CharacterState _state;
    private Vector3 _position;

    public PositionCondition(CharacterState agentContext, Vector3 targetPosition) : base(agentContext)
    {
        _state = agentContext;
    }

    public override bool Check() => _state.CurrentPosition == _position;
}