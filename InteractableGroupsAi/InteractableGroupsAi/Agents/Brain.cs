using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public abstract class Brain : IUpdatable
    {
        private Goal _currentGoal;

        public abstract void Update();
        public void SetGoal(Goal newGoal)
        {
            _currentGoal = newGoal;
        }
    }
}
