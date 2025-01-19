using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class CurrentLocationConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        return 1f;
    }
}
