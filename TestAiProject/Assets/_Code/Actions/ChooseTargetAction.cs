using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Memory;
using System.Numerics;

public class ChooseTargetAction : AgentAction, IAgentStateable
{
    public CharacterState State => _state;

    private readonly CharacterState _state;
    private readonly AgentController _controller;

    private IAgentState _target;

    public ChooseTargetAction(CharacterState state, ComppositeAgentCondition condition, AgentController controller) : base(condition)
    {
        _state = state;
        _controller = controller;
    }

    public override void ForceEnd()
    {
    }

    public override float GetGoalChange(Goal goal)
    {
        return 1f;
    }

    public override IAgentState GetNewState()
    {
        var newState = new CharacterState();
        newState.SetTarget(_target);
        return newState;
    }

    public override void OnBegin()
    {
        var characters = _controller.Controller.Memory.GetAllOfType<IAgentState>();
        var maxDistance = float.MinValue;

        foreach (var character in characters)
        {
            if (character.GroupId.Equals(_state.GroupId))
                continue;

            var distance = Vector3.Distance(character.CurrentPosition, _state.CurrentPosition);

            if (distance > maxDistance)
            {
                _target = character;
                maxDistance = distance;
            }
        }

        OnCompleted?.Invoke();
    }

    public override void OnEnd()
    {
    }

    public override void TryExecute()
    {
    }

    public override void Update()
    {
    }
}