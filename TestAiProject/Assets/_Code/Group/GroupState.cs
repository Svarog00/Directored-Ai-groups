using InteractableGroupsAi.Director.Groups;

public class GroupState : IGroupState
{
    public float CurrentHealth { get; private set; }

    public float MaxHealth { get; private set; }

    public float CurrentRest { get; private set; }

    public float MaxRest { get; private set; }

    public IGroupContext CurrentTarget { get; private set; }

    public GroupState(float currentHealth, float maxHealth, float currentRest, float maxRest)
    {
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        CurrentRest = currentRest;
        MaxRest = maxRest;
    }

    public void SetTarget(IGroupContext target) => CurrentTarget = target;
}