using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using UnityEngine;

public class MoveToAction : AgentAction, IAgentStateable
{
    public CharacterState State => _characterState;

    private CharacterState _characterState;
    private AgentController _characterController;
    private Vector3 _targetPosition;

    public MoveToAction(CharacterState state, AgentController characterController, ComppositeAgentCondition condition) : base(condition)
    {
        _characterState = state;
        _characterController = characterController;
    }

    public override void ForceEnd()
    {
        _characterController.StopMove();    
    }

    public override float GetGoalChange(Goal goal)
    {
        return goal.GetGoalDelta(this);
    }

    public override void OnBegin()
    {
        _targetPosition = new Vector3(_characterState.TargetPosition.X, _characterState.TargetPosition.Y, _characterState.TargetPosition.Z);
        _characterController.MoveTo(_targetPosition);
    }

    public override void OnEnd()
    {
        _characterController.StopMove();
    }

    public override void TryExecute()
    {

    }

    public override void Update()
    {
        var distance = 
            System.Numerics.Vector3.Distance(_characterState.CurrentPosition, new System.Numerics.Vector3(_targetPosition.x, _targetPosition.y, _targetPosition.z));
        if (distance <= 0.1f)
        {
            OnCompleted?.Invoke();
        }
    }

    public override IAgentState GetNewState()
    {
        var state = new CharacterState();
        state.SetPosition(_targetPosition);
        return state;
    }
}