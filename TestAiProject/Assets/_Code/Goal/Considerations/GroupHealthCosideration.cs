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
        var source = GroupsHolder.GetGroup(context.GroupId);
        var enemy = GroupsHolder.GetClosestEnemyGroup(source);

        if (enemy == null) return 0f;

        var enemyHealth = enemy.GetState().CurrentHealth;
        var enemyMaxHealth = enemy.GetState().MaxHealth;
        return 1 - enemyHealth / enemyMaxHealth;
    }
}
