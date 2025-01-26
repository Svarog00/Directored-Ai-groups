using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;

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
        var weapon = _state.CurrentHand as Weapon;

        return goal.GetGoalDelta(this);
    }

    public override IAgentState GetNewState()
    {
        if (_target == null) return null;

        var weapon = _state.CurrentHand as Weapon;
        _target.SetHealth(_target.CurrentHealth - weapon.Damage);
        return _target;
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
        _target.SetHealth(_target.CurrentHealth - weapon.Damage);
    }
}