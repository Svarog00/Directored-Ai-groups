using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using UnityEngine;

public static class GoalHolder
{
    public static ConsideredGoal RestGoal(IGroupContext group)
    {
        var moveToCondition = new CompositeGroupCondition();
        var desiredState = new DesiredGroupState();
        
        var goal = new RestGoal(moveToCondition);

        var scorer = GoalScorer(group.GetState());

        return new ConsideredGoal(goal, scorer);
    }

    public static ConsideredGoal MoveToLocation(IGroupContext group)
    {
        var moveToCondition = new CompositeGroupCondition();
        var desiredState = new DesiredGroupState();
        desiredState.CurrentPosition = new System.Numerics.Vector3(1, 1, 1);

        moveToCondition.AddCondition(new LocationGroupCondition(desiredState));
        var goal = new MoveToRandomLocationGoal(moveToCondition, group);

        var scorer = GoalScorer(group.GetState());
        scorer.AddConsideration(new CurrentLocationConsideration());
        scorer.AddConsideration(new NeedRestConsideration());

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
        scorer.AddConsideration(new GroupHealthConsideration());
        scorer.AddConsideration(new EnemyGroupHealthConsideration());

        return new ConsideredGoal(goal, scorer);
    }

    public static GroupScorer GoalScorer(IGroupState model) => new GroupScorer(model);
}
