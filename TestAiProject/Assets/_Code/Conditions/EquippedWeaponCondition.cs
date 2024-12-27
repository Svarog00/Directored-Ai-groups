using InteractableGroupsAi;

public class EquippedWeaponCondition : AgentCondition
{
    private CharacterState _characterState;

    public EquippedWeaponCondition(CharacterState characterState) : base(characterState) 
    {
        _characterState = characterState;
    }

    public override bool Check()
    {
        return _characterState.CurrentHand is Weapon;
    }
}
