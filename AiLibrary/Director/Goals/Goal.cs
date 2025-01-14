using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director.Goals
{
    public class Goal
    {
        public IGroupContext Group { get; }

        private CompositeGroupCondition _desiredCondition;

        public Goal(CompositeGroupCondition condition)
        {
            _desiredCondition = condition;
        }

        public bool Check()
        {
            GroupCondition failedCondition = null;
            return _desiredCondition.IsSatisfied(out failedCondition);
        }

        public float GetGoalDelta(AgentAction action) => _desiredCondition.GetDelta(action);
    }
}
