using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director.Goals
{
    public class Goal
    {
        public IGroupContext Group { get; }

        private CompositeCondition<GroupCondition> _desiredCondition;

        public Goal(CompositeCondition<GroupCondition> condition)
        {
            _desiredCondition = condition;
        }

        public bool Check() => _desiredCondition.IsSatisfied();
    }
}
