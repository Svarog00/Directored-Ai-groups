namespace InteractableGroupsAi.Agents
{

    public interface IAgentContext
    {
        public float CurrentHealth { get; }
        public float MaxHealth { get; }

        public float CurrentRest { get; }
        public float MaxRest { get; }

        public GroupId GroupId { get; }

        void SetGroupId(GroupId id);
    }
}
