using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class RelationsConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        return RelationsHolder.MaxRelations;
    }
}