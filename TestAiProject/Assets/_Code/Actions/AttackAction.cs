using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;

public class AttackAction : AgentAction, IAgentStateable
{
    public CharacterState State => _state;

    private readonly CharacterState _state;
    private readonly CharacterState _target;
    private readonly AgentController _controller;


    public AttackAction(CharacterState state, AgentController characterController, ComppositeAgentCondition condition, CharacterState target) : base(condition)
    {
        _state = state;
        _target = target;
        _controller = characterController;
    }

    public override void ForceEnd()
    {

    }

    public override float GetGoalChange(Goal goal)
    {
        var weapon = _controller.State.CurrentHand as Weapon;

        return goal.GetGoalDelta(this);
    }

    public override IAgentState GetNewState()
    {
        var weapon = _controller.State.CurrentHand as Weapon;
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

    }
}