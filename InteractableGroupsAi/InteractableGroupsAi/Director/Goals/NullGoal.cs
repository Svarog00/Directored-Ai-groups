using InteractableGroupsAi.Agents.Conditions;

namespace InteractableGroupsAi.Director.Goals
{
    public class NullGoal : Goal
    {
        public NullGoal() : base (new NullCompositeCondiiton())
        {

        }

        public NullGoal(CompositeCondition condition) : base(condition)
        {
        }
    }
}
