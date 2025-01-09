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

    public override bool Check() => _state.CurrentPosition == new System.Numerics.Vector3(_position.x, _position.y, _position.z);

    public override bool CheckState(IAgentState context)
    {
        throw new System.NotImplementedException();
    }
}