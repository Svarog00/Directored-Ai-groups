using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class ClosestEnemyGroupConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {


        return RelationsHolder.MaxRelations;
    }
}