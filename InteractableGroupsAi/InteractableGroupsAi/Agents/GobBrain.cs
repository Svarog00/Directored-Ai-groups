using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Agents
{
    public class GobBrain : Brain
    {
        private const int DeepBorder = 5;

        private AgentAction _currentAction;
        private List<AgentAction> _availableActions = [];

        private Queue<AgentAction> _plannedActions = [];

        private float _prevHighestScore = 0f;
        private AgentAction _prevBestAction;

        public GobBrain(AiController<IAgentContext> controller) : base(controller)
        {
            _currentAction = _availableActions.First();
            _prevBestAction = _currentAction;
            _prevHighestScore = 0f;
        }

        public override void Reset()
        {
            _plannedActions.Clear();
            ChooseNewAction();
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
                var score = action.GetGoalChange(CurrentGoal);

                if (score > highestScore)
                {
                    highestScore = score;
                    choosenAction = action;
                }

                if (action.CanExecute() == false)
                {
                    /// <summary>
                    /// TODO: Сделать выбор действия для удволетворения условия или сбросить выбор на предыдущее лучшее действие 
                    /// в случае выхода за предел глубины 
                    /// </summary>
                    var resolvingAction = FindActionToSatisfy(action);
                    if (resolvingAction == null)
                    {
                        highestScore = _prevHighestScore;
                        choosenAction = _prevBestAction;
                        continue;
                    }
                    else
                    {
                        _plannedActions.Clear();
                        _plannedActions.Enqueue(resolvingAction);
                    }
                }
            }

            _plannedActions.Enqueue(choosenAction);
            SetAction(choosenAction);
        }

        private AgentAction FindActionToSatisfy(AgentAction actionToExecute)
        {
            foreach (var action in _availableActions)
            {
                if (action == actionToExecute) continue;

                if (actionToExecute.TrySatisfyConditions(action))
                    return action;   
            }

            return null;
        }

        private void SetAction(AgentAction action)
        {
            _currentAction = action;
            _currentAction.OnCompleted += ToNextAction;
            _currentAction.OnFailed += ChooseNewAction;

            _currentAction.OnBegin();
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
            SetAction(_currentAction);
        }
    }
}
