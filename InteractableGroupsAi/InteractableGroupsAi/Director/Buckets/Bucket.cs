using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Director.Buckets
{
    public class Bucket
    {
        private float _weight;
        private List<PossibleGoal> _goals;
        private BucketScorer _scorer;

        public float Weight => _weight;

        public Bucket(float weight, BucketScorer scorer)
        {
            _weight = weight;
            _scorer = scorer;
        }

        public float EvaluateBucket()
        {
            return _scorer.GetScore(this);
        }

        public void AddGoal(PossibleGoal goal)
        {
            _goals.Add(goal);
        }
    }
}
