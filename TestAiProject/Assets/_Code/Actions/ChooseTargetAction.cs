using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
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
        var minDistance = float.MaxValue;
        var enemyGroup = GetEnemyGroup();

        foreach (var character in characters)
        {
            if (character.GroupId.Equals(_state.GroupId) || character.GroupId.Equals(enemyGroup.GroupId) == false)
                continue;

            var distance = Vector3.Distance(character.CurrentPosition, _state.CurrentPosition);

            if (distance < minDistance)
            {
                _target = character;
                minDistance = distance;
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

    private IGroupState GetEnemyGroup()
    {
        var group = GroupsHolder.GetGroup(_state.GroupId);
        return group.State.CurrentTarget;
    }
}