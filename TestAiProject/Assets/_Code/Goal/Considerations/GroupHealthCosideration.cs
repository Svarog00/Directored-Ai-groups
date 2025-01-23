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
        if (context.CurrentTarget == null) return 0f;

        var enemyHealth = context.CurrentTarget.CurrentHealth;
        var enemyMaxHealth = context.CurrentTarget.MaxHealth;
        return 1 - enemyHealth / enemyMaxHealth;
    }
}
