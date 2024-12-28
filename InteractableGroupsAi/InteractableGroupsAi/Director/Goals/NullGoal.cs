using InteractableGroupsAi.Agents.Conditions;

namespace InteractableGroupsAi.Director.Goals
{
    public class NullGoal : Goal
    {
        public NullGoal() : base (new CompositeCondition<GroupCondition>())
        {

        }

        public NullGoal(CompositeCondition<GroupCondition> condition) : base(condition)
        {
        }
    }
}
