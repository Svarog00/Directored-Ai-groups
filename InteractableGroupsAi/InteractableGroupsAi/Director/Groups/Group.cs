using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Director.Groups
{
    public class Group : IGroupContext
    {
        private Goal _currentGoal;
        private List<AiController> _agents = [];

        public int Id { get; }

        public void SetGroupGoal(Goal newGoal)
        {
            _currentGoal = newGoal;
        }

        public bool GetGroupState()
        {
            return true;
        }

        public void AddAgent(AiController agent) => _agents.Add(agent);
    }
}
