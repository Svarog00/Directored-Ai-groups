using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class NoNeedForRestConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        return context.CurrentRest / context.MaxRest;
    }
}
