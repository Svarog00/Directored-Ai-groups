using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using InteractableGroupsAi.Memory;
using System.Numerics;

public class ChooseTargetAction : AgentAction
{
    private readonly IAgentState _state;

    private IAgentState _target;

    public ChooseTargetAction(IAgentState state, ComppositeAgentCondition condition) : base(condition)
    {
        _state = state;
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
        var minDistance = float.MaxValue;
        var enemyGroup = GetEnemyGroup();

        foreach (var character in enemyGroup.Agents)
        {
            var distance = Vector3.Distance(character.State.CurrentPosition, _state.CurrentPosition);

            if (distance < minDistance)
            {
                _target = character.State;
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

    private Group GetEnemyGroup()
    {
        var group = GroupsHolder.GetGroup(_state.GroupId);
        return group;
    }
}