using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director.Buckets
{
    public class Bucket
    {
        private float _weight;
        private List<CondideredGoal> _availableGoals = [];
        private GroupScorer _scorer;
        private float _minimunScore = 0f;

        public IEnumerable<CondideredGoal> Goals => _availableGoals;
        public float Weight => _weight;

        public Bucket(float weight, GroupScorer scorer)
        {
            _weight = weight;
            _scorer = scorer;
        }

        public float EvaluateBucket(IGroupContext context)
        {
            return _scorer.GetScore() * _weight;
        }

        public void AddGoal(CondideredGoal goal)
        {
            _availableGoals.Add(goal);
        }

        public CondideredGoal EvaluateGoals(IGroupContext context)
        {
            CondideredGoal possibleGoal = _availableGoals.First();
            float floor = _minimunScore;
            foreach (var goal in _availableGoals)
            {
                /*
                 * TODO: Change to evaluating the best bucket in current context, 
                 * and picking the best goal from the bucket 
                 */
                var score = goal.EvaluateGoal();

                if (score > floor)
                {
                    possibleGoal = goal;
                    floor = score;
                }
            }

            return possibleGoal;
        }
    }
}
