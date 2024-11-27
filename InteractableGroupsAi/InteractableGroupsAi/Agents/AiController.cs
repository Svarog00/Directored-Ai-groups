using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public class AiController
    {
        private Brain _brain;

        public void SetBrain(Brain brain)
        {
            _brain = brain;
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
