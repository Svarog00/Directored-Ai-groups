using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using UnityEngine;

public class CharacterState : IAgentContext
{
    public Vector3 CurrentPosition { get; }

    public void SetGroupId(GroupId id)
    {

    }
}

public class MoveToAction : AgentAction
{
    private CharacterState _characterState;
    private Vector3 _targetPosition;

    public MoveToAction(CharacterState state, Vector3 position, CompositeCondition condition) : base(condition)
    {
        _characterState = state;
        _targetPosition = position;
    }

    public override void ForceEnd()
    {

    }

    public override float GetGoalChange(Goal goal)
    {
        return 0f;
    }

    public override void OnBegin()
    {
    }

    public override void OnEnd()
    {

    }

    public override void TryExecute()
    {

    }

    public override void Update()
    {
        if (_characterState.CurrentPosition == _targetPosition)
        {
            OnCompleted?.Invoke();
        }
    }
}