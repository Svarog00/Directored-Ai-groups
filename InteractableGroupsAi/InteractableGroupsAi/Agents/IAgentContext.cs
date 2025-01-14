using InteractableGroupsAi.Other;
using System.Numerics;

namespace InteractableGroupsAi.Agents
{

    public interface IAgentState
    {
        public float CurrentHealth { get; }
        public float MaxHealth { get; }

        public float CurrentRest { get; }
        public float MaxRest { get; }

        public GroupId GroupId { get; }
        public int AgentId { get; }
        public Vector3 CurrentPosition { get; }

        public IAgentState CurrentTarget { get; }
        public Item CurrentHand { get; }
        public List<Item> Items { get; }

        void SetGroupId(GroupId id);
        void SetHealth(float health);
        void SetRest(float rest);
        void SetPosition(Vector3 position);
        void SetTarget(IAgentState target);
        void SetItems(List<Item> items);
        void Equip(Item item);
    }
}
