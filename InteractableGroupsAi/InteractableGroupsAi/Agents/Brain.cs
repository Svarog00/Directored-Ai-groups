using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public abstract class Brain : IUpdatable
    {
        private AiController _controller;
        protected Goal CurrentGoal = new NullGoal(new NullCompositeCondiiton());

        public Brain(AiController controller)
        {
            _controller = controller;
        }

        public void SetGoal(Goal goal)
        {
            CurrentGoal = goal;
        }

        public abstract void Update();
    }
}
