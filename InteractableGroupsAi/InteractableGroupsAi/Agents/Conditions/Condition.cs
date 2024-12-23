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
        public virtual bool Check()
        {
            return true;
        }
    }

    public abstract class AgentCondition : Condition
    {
        public IAgentContext AgentContext => AgentContextInternal;

        protected IAgentContext AgentContextInternal { get; private set; }

        public AgentCondition(IAgentContext agentContext)
        {
            AgentContextInternal = agentContext;
        }
    }

    public abstract class GroupCondition
    {
        public IGroupContext GroupContext => GroupContextInternal;

        protected IGroupContext GroupContextInternal { get; private set; }

        public GroupCondition(IGroupContext groupContext)
        {
            GroupContextInternal = groupContext;
        }
    }
}
