using InteractableGroupsAi.Agents;
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

        public bool TrySatisfyConditions(AgentAction anotherAction)
        {
            
            return _condition.IsSatisfied();
        }

        /// <summary>
        /// Для оценки акшн проходит по кондишенам Гоала, меняет их и дельту аггрегирует в выход.
        /// </summary>
        /// <param name="goal"></param>
        /// <returns>Если Акшн не может никак изменить цель, то возвращается 0, 
        /// в противном случае аггрегированные изменения кондишенов.</returns>
        public abstract float GetGoalChange(Goal goal);

        public abstract void Update();

        public abstract void TryExecute(IAgentContext context);

        public abstract void OnBegin();
        public abstract void OnEnd();
        public abstract void ForceEnd();
    }
}
