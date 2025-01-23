using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;

public class AttackAction : AgentAction, IAgentStateable
{
    public CharacterState State => _state;

    private readonly CharacterState _state;
    private readonly IAgentState _target;


    public AttackAction(CharacterState state, ComppositeAgentCondition condition, CharacterState target) : base(condition)
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
        var weapon = _state.CurrentHand as Weapon;
        _target.SetHealth(_target.CurrentHealth - weapon.Damage);
        return _target;
    }

    public override void OnBegin()
    {
        var weapon = _state.CurrentHand as Weapon;
        _target.SetHealth(_target.CurrentHealth - weapon.Damage);
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