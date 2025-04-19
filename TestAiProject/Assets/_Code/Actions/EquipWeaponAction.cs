using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi;
using AiLibrary.Other;

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
        return 0.01f;
    }

    public override IAgentState GetNewState()
    {
        var newState = new CharacterState();
        newState.CurrentHand = new Weapon(0, "Weapon", 1);
        return newState;
    }

    public override void OnBegin()
    {
        var weapon = FindWeapon();

        if (weapon == null)
        {
            AiLogger.Error($"{this} failed");
            OnFailed?.Invoke();
        }

        _state.Equip(weapon);

        OnCompleted?.Invoke();
    }

    private Weapon FindWeapon()
    {
        foreach (var key in _state.Items.Keys)
        {
            if (key is Weapon)
            {
                return key as Weapon;
            }
        }

        return null;
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