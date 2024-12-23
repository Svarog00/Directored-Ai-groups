using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public class GobBrain : Brain
    {
        private AgentAction _currentAction;
        private List<AgentAction> _availableActions = [];

        private Queue<AgentAction> _plannedActions = [];

        public GobBrain(AiController controller) : base(controller)
        {

        }

        public override void Update()
        {
            _currentAction.Update();
        }

        public void SetAvailableActions(List<AgentAction> availableActions) 
        {
            _availableActions = availableActions;
        }

        private void ChooseNewAction()
        {
            var highestScore = 0f;
            AgentAction choosenAction = _availableActions.First();
            foreach (var action in _availableActions)
            {
                var score = action.Score(CurrentGoal);

                if (score > highestScore)
                {
                    highestScore = score;
                    choosenAction = action;
                }

                if (action.CanExecute() == false)
                {
                    FindActionToSatisfy(action);
                }
            }

            SetAction(choosenAction);
        }

        private void FindActionToSatisfy(AgentAction actionToExecute)
        {
            foreach(var action in _availableActions)
            {
                if (action == actionToExecute) continue;

                
            }
        }

        private void SetAction(AgentAction action)
        {
            _currentAction = action;
            _currentAction.OnCompleted += ToNextAction;
            _currentAction.OnFailed += ChooseNewAction;
        }

        private void ToNextAction()
        {
            _currentAction.OnEnd();
            
            if (_plannedActions.Count <= 0)
            {
                ChooseNewAction();
                return;
            }

            _currentAction = _plannedActions.Dequeue();
        }
    }
}
