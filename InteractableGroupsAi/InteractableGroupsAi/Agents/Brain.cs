using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public class NullBrain : Brain
    {
        public NullBrain() : base(null)
        {

        }

        public override void Reset()
        {
        }

        public override void Update()
        {
        }
    }

    public abstract class Brain : IUpdatable
    {
        private AiController<IAgentContext> _controller;
        protected Goal CurrentGoal = new NullGoal(new CompositeCondition<GroupCondition>());

        public Brain(AiController<IAgentContext> controller)
        {
            _controller = controller;
        }

        public void SetGoal(Goal goal)
        {
            CurrentGoal = goal;

            if (goal == CurrentGoal)
                return;

            Reset();
        }

        public abstract void Reset();

        public abstract void Update();
    }
}
