using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Memory;

namespace InteractableGroupsAi.Agents
{
    public class AiController<T> where T : IAgentState
    {
        private Brain _brain = new NullBrain();
        private Blackboard _blackboard;
        private T _character;
        private List<Sensor> _perceptionSensors;

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

        public void AddSensor(Sensor sensor)
        {
            _perceptionSensors.Add(sensor);
            sensor.OnAgentDetected += OnAgentDetected;
            sensor.OnAgentLost += OnAgentLost;
        }

        public void OnAgentDetected(IAgentState agentContext)
        {
            
        }

        public void OnAgentLost(IAgentState agentContext)
        {

        }

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
