using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class GroupHealthConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        return context.CurrentHealth / context.MaxHealth;
    }
}

public class EnemyGroupHealthConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        var enemyHealth = context.CurrentTarget.GetState().CurrentHealth;
        var enemyMaxHealth = context.CurrentTarget.GetState().MaxHealth;
        return 1 - enemyHealth / enemyMaxHealth;
    }
}
