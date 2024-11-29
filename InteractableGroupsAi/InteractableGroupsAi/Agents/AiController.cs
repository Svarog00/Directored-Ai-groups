using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Memory;

namespace InteractableGroupsAi.Agents
{
    public class AiController
    {
        private Brain _brain;
        private Blackboard _blackboard;

        public AiController(Brain brain)
        {
            _brain = brain;
            _blackboard = new Blackboard();
        }

        public void Update()
        {
            _brain.Update();
        }

        public bool GetCharacterState()
        {
            return true;
        }

        public void SetCurrentGoal(Goal newGoal)
        {
            _brain.SetGoal(newGoal);
        }
    }
}
