using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public abstract class Brain : IUpdatable
    {
        private AiController _controller;
        private Goal _currentGoal;

        public Brain(AiController controller)
        {
            _controller = controller;
        }

        public abstract void Update();

        public void SetGoal(Goal newGoal)
        {
            _currentGoal = newGoal;
        }
    }
}
