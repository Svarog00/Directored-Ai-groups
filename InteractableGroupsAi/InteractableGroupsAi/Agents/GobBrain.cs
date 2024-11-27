namespace InteractableGroupsAi.Agents
{
    public class GobBrain : Brain
    {
        private AgentAction _currentAction;
        private Queue<AgentAction> _plannedActions;
        private List<AgentAction> _availableActions;

        public override void Update()
        {
            _currentAction.Update();
        }

        public void SetAvailableActions(List<AgentAction> availableActions) 
        {
            _availableActions = availableActions;
        }

        private void ChooseCurrentAction()
        {
            _currentAction = _availableActions[0];
            _currentAction.OnBegin();
        }

        private void ToNextAction()
        {
            _currentAction.OnEnd();
        }
    }
}
