using AiLibrary.Other;
using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackAction : AgentAction
{
    private readonly IAgentState _state;
    private readonly IAgentState _target;


    public AttackAction(IAgentState state, ComppositeAgentCondition condition) : base(condition)
    {
        _state = state;
        _target = state.CurrentTarget;
    }

    public override void ForceEnd()
    {

    }

    public override float GetGoalChange(Goal goal)
    {
        return goal.GetGoalDelta(this);
    }

    public override IAgentState GetNewState()
    {
        var group = GroupsHolder.GetGroup(_state.GroupId);
        var enemyGroup = GroupsHolder.GetClosestEnemyGroup(group);

        var weapon = _state.Items.Find(x => x is Weapon) as Weapon;
        var damage = weapon == null ? 0 : weapon.Damage;
        var newState = new CharacterState();
        newState.SetPosition(group.State.TargetPosition);
        newState.SetHealth(enemyGroup.State.CurrentHealth - damage);
        return newState;
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
        var weapon = _state.CurrentHand as Weapon;
        var target = _state.CurrentTarget;

        AiLogger.Error($"before {target.CurrentHealth} {target.GroupId}-{target.AgentId}");
        if (target == null || weapon == null)
        {
            return;
        }
        target.SetHealth(target.CurrentHealth - weapon.Damage * Time.deltaTime);

        if (target.CurrentHealth <= 0)
        {
            _state.SetTarget(null);
            OnCompleted?.Invoke();
        }
    }
}