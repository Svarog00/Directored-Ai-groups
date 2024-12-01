namespace InteractableGroupsAi.Director.Goals
{
    public class CondideredGoal
    {
        private Goal _goal;
        private GoalScorer _scorer;

        public CondideredGoal(Goal goal, GoalScorer scorer)
        {
            _goal = goal;
            _scorer = scorer;
        }

        public float EvaluateGoal() => _scorer.GetScore();
    }
}
