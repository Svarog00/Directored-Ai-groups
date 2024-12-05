using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public class GobBrain : Brain
    {
        private Goal _currentGoal;

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

        public void SetGoal(Goal newGoal)
        {
            _currentGoal = newGoal;
        }

        private void ChooseNewAction()
        {
            var highestScore = 0f;
            AgentAction choosenAction = _availableActions.First();
            foreach (var action in _availableActions)
            {
                var score = action.Score(_currentGoal);

                if (score > highestScore)
                {
                    highestScore = score;
                    choosenAction = action;
                }
            }

            SetAction(choosenAction);
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
