using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using UnityEngine;

public static class BucketHolder
{
    public static Bucket ExploreBucket(IGroupContext group)
    {
        var scorer = GoalHolder.GoalScorer(group.GetState());
        scorer.AddConsideration(new CurrentLocationPointOfInterestConsideration());
        scorer.AddConsideration(new NoNeedForRestConsideration());

        var explorationBucket = new Bucket(0.5f, scorer);
        return explorationBucket;
    }

    public static Bucket FightBucket(IGroupContext group)
    {
        var scorer = GoalHolder.GoalScorer(group.GetState());
        scorer.AddConsideration(new ClosestGroupEnemyRelationConsideration());
        scorer.AddConsideration(new EnemyGroupHealthConsideration());
        scorer.AddConsideration(new DistanceToEnemyGroupConsideration());
        scorer.AddConsideration(new InDangerConsideration());

        var fightBucket = new Bucket(0.9f, scorer);

        return fightBucket;
    }

    public static Bucket SocialBucket(IGroupContext group)
    {
        var scorer = GoalHolder.GoalScorer(group.GetState());
        scorer.AddConsideration(new ClosestGroupRelationConsideration());
        scorer.AddConsideration(new DistanceToFriendlyGroup());
        scorer.AddConsideration(new NotInDangerConsideration());

        var socialsBucket = new Bucket(0.7f, scorer);

        return socialsBucket;
    }
}
