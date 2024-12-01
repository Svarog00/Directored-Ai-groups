using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Director.Buckets
{
    public class Bucket
    {

        private float _weight;
        private List<CondideredGoal> _goals;
        private BucketScorer _scorer;

        public IEnumerable<CondideredGoal> Goals => _goals;
        public float Weight => _weight;

        public Bucket(float weight, BucketScorer scorer)
        {
            _weight = weight;
            _scorer = scorer;
        }

        public float EvaluateBucket()
        {
            return _scorer.GetScore();
        }

        public void AddGoal(CondideredGoal goal)
        {
            _goals.Add(goal);
        }
    }
}
