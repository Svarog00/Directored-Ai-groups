using InteractableGroupsAi.Agents.Conditions;

namespace InteractableGroupsAi.Director.Goals
{
    public class Goal
    {
        private CompositeCondition _condition;

        public bool Check() => _condition.IsSatisfied();
    }
}
