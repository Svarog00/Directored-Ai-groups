using InteractableGroupsAi.Agents.Conditions;

namespace InteractableGroupsAi.Director.Goals
{
    public class Goal
    {
        private CompositeCondition _desiredCondition;

        public Goal(CompositeCondition condition)
        {
            _desiredCondition = condition;
        }

        public bool Check() => _desiredCondition.IsSatisfied();
    }
}
