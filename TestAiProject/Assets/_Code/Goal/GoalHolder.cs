using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;

public static class GoalHolder
{
    public static ConsideredGoal RestGoal(IGroupContext group)
    {
        var restCondition = new CompositeGroupCondition();
        var desiredState = new DesiredGroupState();

        var goal = new RestGoal(restCondition);

        var scorer = GoalScorer(group.GetState());
        scorer.AddConsideration(new NeedRestConsideration());

        return new ConsideredGoal(goal, scorer);
    }

    public static ConsideredGoal MoveToLocation(IGroupContext group)
    {
        var moveToCondition = new CompositeGroupCondition();

        moveToCondition.AddCondition(new LocationGroupCondition(group.GetState()));
        var goal = new MoveToNearestLocationGoal(moveToCondition, group);

        var scorer = GoalScorer(group.GetState());
        scorer.AddConsideration(new CurrentLocationPointOfInterestConsideration());
        scorer.AddConsideration(new NoNeedForRestConsideration());

        return new ConsideredGoal(goal, scorer);
    }

    public static ConsideredGoal FleeGoal(IGroupContext group)
    {
        var moveToCondition = new CompositeGroupCondition();

        moveToCondition.AddCondition(new LocationGroupCondition(group.GetState()));
        var goal = new FleeGoal(moveToCondition, group);

        var scorer = GoalScorer(group.GetState());
        scorer.AddConsideration(new GroupToEnemyHealthConsideration());
        scorer.AddConsideration(new InDangerConsideration());

        return new ConsideredGoal(goal, scorer);
    }

    public static ConsideredGoal DestroyGroupGoal(IGroupContext group)
    {
        var condition = new CompositeGroupCondition();
        var desiredState = new DesiredGroupState();
        desiredState.CurrentHealth = 0f;

        condition.AddCondition(new EnemyGroupHealthCondition(desiredState));
        var goal = new DestroyGroupGoal(condition, group);

        var scorer = GoalScorer(group.GetState());
        scorer.AddConsideration(new ClosestGroupEnemyRelationConsideration());
        scorer.AddConsideration(new EnemyGroupHealthConsideration());
        scorer.AddConsideration(new DistanceToEnemyGroupConsideration());
        scorer.AddConsideration(new InDangerConsideration());

        return new ConsideredGoal(goal, scorer);
    }

    public static ConsideredGoal AskMedkitGoal(IGroupContext group)
    {
        var condition = new CompositeGroupCondition();
        var goal = new ExchangeItemsGoal(condition, group, "Medkit");

        var scorer = GoalScorer(group.GetState());
        scorer.AddConsideration(new NeedHealConsideration());
        scorer.AddConsideration(new ClosestGroupRelationConsideration());
        scorer.AddConsideration(new NotInDangerConsideration());
        scorer.AddConsideration(new NeedItemConsideration("Medkit"));

        return new ConsideredGoal(goal, scorer);
    }

    public static ConsideredGoal AskFoodGoal(IGroupContext group)
    {
        var condition = new CompositeGroupCondition();
        var goal = new ExchangeItemsGoal(condition, group, "Snack");

        var scorer = GoalScorer(group.GetState());
        scorer.AddConsideration(new ClosestGroupRelationConsideration());
        scorer.AddConsideration(new NotInDangerConsideration());
        scorer.AddConsideration(new NeedRestConsideration());
        scorer.AddConsideration(new NeedItemConsideration("Snack"));

        return new ConsideredGoal(goal, scorer);
    }

    public static GroupScorer GoalScorer(IGroupState state) => new GroupScorer(state);
}
