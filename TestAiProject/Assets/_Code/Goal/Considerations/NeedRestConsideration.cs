using AiLibrary.Other;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class NeedRestConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        return context.CurrentRest / context.MaxRest;
    }
}
