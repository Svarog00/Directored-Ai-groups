using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Memory;
using System.Numerics;

namespace InteractableGroupsAi.Agents
{
    public class AiController<T> where T : IAgentState
    {
        private Brain _brain = new NullBrain();
        private Blackboard _blackboard;
        private T _character;
        private List<IPerceptionSensor> _perceptionSensors;

        public Blackboard Memory => _blackboard;

        public AiController(T character)
        {
            _character = character;
            _blackboard = new Blackboard();
            _perceptionSensors = [];
        }

        public void SetBrain(Brain brain)
        {
            _brain = brain;
        }

        public void AddSensor(IPerceptionSensor sensor)
        {
            _perceptionSensors.Add(sensor);
            sensor.OnAgentDetected += OnAgentDetected;
            sensor.OnAgentMoved += OnTargetMoved;
            sensor.OnAgentLost += OnAgentLost;
        }

        public void WriteIntoBlackBoard<Y>(string key, Y item) => _blackboard.AddValue(new BlackboardKey(key), item);
        public void RemoveFromBlackBoard(string key) => _blackboard.Remove(new BlackboardKey(key));

        public void OnAgentDetected(IAgentState agentContext)
        {
            _blackboard.AddValue(new BlackboardKey($"{agentContext.AgentId}_position"), agentContext.CurrentPosition);
            _blackboard.AddValue(new BlackboardKey(agentContext.AgentId.ToString()), agentContext);
        }

        public void OnAgentLost(IAgentState agentContext)
        {
            _blackboard.AddValue(new BlackboardKey($"{agentContext.AgentId}_position"), agentContext.CurrentPosition);
            _blackboard.Remove(new BlackboardKey($"{agentContext.AgentId}"));
        }

        public void OnTargetMoved(IAgentState agentContext) 
            => _blackboard.AddValue(new BlackboardKey($"{agentContext.AgentId}_position"), agentContext.CurrentPosition);

        public void Update()
        {
            _brain.Update();
            _perceptionSensors.ForEach(x => x.Update());
        }

        public IAgentState GetCharacterState()
        {
            return _character;
        }

        public void SetGroupId(GroupId groupId) => _character.SetGroupId(groupId);

        public void SetCurrentGoal(Goal newGoal) => _brain.SetGoal(newGoal);
    }
}
