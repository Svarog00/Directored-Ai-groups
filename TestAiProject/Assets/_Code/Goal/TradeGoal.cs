using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;

public class TradeGoal : Goal
{
    public TradeGoal(CompositeGroupCondition condition) : base(condition)
    {

    }

    public override void Accept()
    {
        //Execute trade operation if its okay
    }
}