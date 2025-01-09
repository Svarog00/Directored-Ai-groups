using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Memory;

namespace InteractableGroupsAi.Director.Groups
{
    public class Group : IGroupContext
    {
        public Goal CurrentGoal => _currentGoal;

        public GroupId GroupId { get; private set; }

        private Goal _currentGoal = new NullGoal();
        private List<AiController<IAgentState>> _agents = [];
        private Blackboard _blackboard;

        public int Id { get; }

        public Group(GroupId groupId)
        {
            GroupId = groupId;
            _blackboard = new Blackboard();
        }

        public void SetGroupGoal(Goal newGoal)

        {
            _currentGoal = newGoal;
            _agents.ForEach(x => x.SetCurrentGoal(_currentGoal));
        }

        public IGroupState GetState()
        {
            return null;
        }

        public bool IsGoalReached() => _currentGoal.Check();

        public void AddAgent(AiController<IAgentState> agent)
        {
            agent.SetGroupId(GroupId);
            _agents.Add(agent);
        }
    }
}
