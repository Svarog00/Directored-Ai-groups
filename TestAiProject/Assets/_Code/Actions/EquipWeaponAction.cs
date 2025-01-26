using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi;

public class EquipWeaponAction : AgentAction
{
    private readonly IAgentState _state;
    private readonly IAgentState _target;


    public EquipWeaponAction(IAgentState state, ComppositeAgentCondition condition) : base(condition)
    {
        _state = state;
        _target = state.CurrentTarget;
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
        newState.CurrentHand = new Weapon();
        return newState;
    }

    public override void OnBegin()
    {
        var weapon = _state.Items.Find(x => x is Weapon);

        _state.CurrentHand = weapon;

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