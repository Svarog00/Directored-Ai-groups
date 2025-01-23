using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class NeedRestConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        return 1 - context.CurrentRest / context.MaxRest;
    }
}
