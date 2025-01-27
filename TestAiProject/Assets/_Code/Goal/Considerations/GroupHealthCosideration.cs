using AiLibrary.Other;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class GroupToEnemyHealthConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        var source = GroupsHolder.GetGroup(context.GroupId);
        var enemy = GroupsHolder.GetClosestEnemyGroup(source);

        if (enemy == null) return 0f;

        var enemyHealth = enemy.GetState().CurrentHealth;
        var enemyMaxHealth = enemy.GetState().MaxHealth;

        var outputEnemy = enemyHealth / enemyMaxHealth;
        var outputSource = context.CurrentHealth / context.MaxHealth;
        var output = outputSource / outputEnemy;
        return 1 - output;
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

        var outputEnemy = enemyHealth / enemyMaxHealth;
        var outputSource = context.CurrentHealth / context.MaxHealth;
        var output =  outputSource / outputEnemy;
        return output;
    }
}
