using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi
{
    public abstract class AgentAction
    {
        private CompositeCondition _condition;

        public Action OnCompleted { get; set; }
        public Action OnFailed { get; set; }

        public AgentAction(CompositeCondition condition)
        {
            _condition = condition;
        }

        public bool CanExecute() => _condition.IsSatisfied();
        public abstract float Score(Goal goal);

        public abstract void Update();
        public abstract void Execute();

        public abstract void OnBegin();
        public abstract void OnEnd();
        public abstract void ForceEnd();
    }
}
