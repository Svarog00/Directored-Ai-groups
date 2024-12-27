using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director.Goals
{
    public class Goal
    {
        public IGroupContext Group { get; }

        private CompositeCondition _desiredCondition;

        public Goal(CompositeCondition condition)
        {
            _desiredCondition = condition;
        }

        public bool Check() => _desiredCondition.IsSatisfied();
    }
}
