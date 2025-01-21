using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InteractableGroupsAi.Director.Groups
{
    public class Group : IGroupContext
    {
        public IEnumerable<Bucket> Buckets => _buckets;

        public Goal CurrentGoal => _currentGoal;
        public Blackboard Memory => _blackboard;
        public GroupId GroupId { get; private set; }

        private Goal _currentGoal = new NullGoal();
        private List<AiController<IAgentState>> _agents = new List<AiController<IAgentState>>();
        private Blackboard _blackboard;

        private List<Bucket> _buckets = new List<Bucket>();

        public int Id { get; }

        public Group(GroupId groupId)
        {
            GroupId = groupId;
            _blackboard = new Blackboard();
        }

        public void SetGroupGoal(Goal newGoal)
        {
            _currentGoal = newGoal;
            _currentGoal.Accept();
            _agents.ForEach(x => x.SetCurrentGoal(_currentGoal));
        }

        public IGroupState GetState() => new GroupState(_agents.Select(x => x.State).ToList());

        public void AddBucket(Bucket bucket)
        {
            _buckets.Add(bucket);
        }

        public void AddAgent(AiController<IAgentState> agent)
        {
            agent.SetGroupId(GroupId);
            agent.AgentDetected += SecureAgent;
            agent.AgentLost += SecureAgent;

            _agents.Add(agent);
        }

        private void SecureAgent(IAgentState agent)
        {
            int count = 0;
            _blackboard.AddValue($"{agent.GroupId}_count", count);
            _blackboard.AddValue($"{agent.GroupId}", count);
        }

        private void ForegetAgent(IAgentState agent)
        {

        }
    }
}
