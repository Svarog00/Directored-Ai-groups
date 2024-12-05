using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public abstract class Brain : IUpdatable
    {
        private AiController _controller;

        public Brain(AiController controller)
        {
            _controller = controller;
        }

        public abstract void Update();
    }
}
