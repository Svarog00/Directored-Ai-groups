using InteractableGroupsAi.Agents.Conditions;

namespace InteractableGroupsAi.Director.Goals
{
    public class PossibleGoal
    {
        private Goal _goal;
        private GoalScorer _scorer;

        public float EvaluateGoal() => _scorer.GetScore(_goal);
    }

    public class Goal
    {
        private CompositeCondition _condition;

        public bool Check() => _condition.IsSatisfied();
    }
}
