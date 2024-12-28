using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi
{
    /// <summary>
    /// Каждый кондишн получает на вход необходимый ему контекст (GroupState, CharacterState) 
    /// И в чек проверяет то что нужно
    /// Например HealthGreaterCondition
    /// Получает CharacterState и проверяет хп
    /// </summary>
    public abstract class Condition
    {
        public abstract bool Check();
    }

    public class NullCondition : Condition
    {
        public override bool Check() => true;
    }

    public abstract class AgentCondition : Condition
    {
        public IAgentContext AgentContext => AgentContextInternal;

        protected IAgentContext AgentContextInternal { get; private set; }

        public AgentCondition(IAgentContext agentContext)
        {
            AgentContextInternal = agentContext;
        }

        public abstract bool TrySatisfyCondition(AgentAction action);

    }

    public abstract class GroupCondition : Condition
    {
        public IGroupContext GroupContext => GroupContextInternal;

        protected IGroupContext GroupContextInternal { get; private set; }

        public GroupCondition(IGroupContext groupContext)
        {
            GroupContextInternal = groupContext;
        }

        public abstract float GetConditionDelta(AgentAction action);
    }
}
