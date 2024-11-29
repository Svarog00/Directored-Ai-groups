using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Director
{
    public abstract class GoalScorer
    {
        public abstract float GetScore(Goal goal);
    }

    public abstract class BucketScorer
    {
        public abstract float GetScore(Bucket goal);
    }
}
