using AiLibrary.Other;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace InteractableGroupsAi.Director.Groups
{
    /// <summary>
    /// Маркировочынй интерфейс для конкретных реализаций Consideration,
    /// Оценивающие какую-то характеристику группы\персонажа получаемую из класса который реализует IContext
    /// </summary>
    public interface IGroupContext
    {
        IGroupState GetState();
        void GetNewGoal();
        Blackboard Memory { get; }
        Goal CurrentGoal { get; }
    }

    public interface IGroupState
    {
        GroupId GroupId { get; }
        float CurrentHealth { get; }
        float MaxHealth { get; }

        float CurrentRest { get; }
        float MaxRest { get; }

        int MembersCount { get; }

        IGroupState CurrentTarget { get; }

        Vector3 CurrentPosition { get; }
        Vector3 TargetPosition { get; }
        Vector3 LastPosition { get; set; }

        void SetTarget(IGroupState target);
        void SetTargetPosition(Vector3 target);
        int GetItemsCount(string name);
        void Exchange(string outItem, string inItem, int count);
    }

    public class DesiredGroupState : IGroupState
    {
        public float CurrentHealth { get; set; }

        public float MaxHealth { get; set; }

        public float CurrentRest { get; set; }

        public float MaxRest { get; set; }

        public int MembersCount { get; set; }

        public IGroupState CurrentTarget { get; set; }

        public Vector3 CurrentPosition { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Vector3 LastPosition { get; set; }

        public GroupId GroupId { get; set; }

        public void SetTarget(IGroupState target) => CurrentTarget = target;
        public void SetTargetPosition(Vector3 target) => TargetPosition = target;
        public int GetItemsCount(string name) => 0;

        public void Exchange(string outItem, string inItem, int count) { }
    }

    public class GroupState : IGroupState
    {
        public GroupId GroupId { get; set; }
        public float CurrentHealth 
        { 
            get
            {
                var health = 0f;
                foreach(var agent in _agents)
                {
                    health += agent.CurrentHealth;
                }
                return health;
            }
            set
            {
                CurrentHealth = value;
            }
        }
        public float MaxHealth
        {
            get
            {
                var health = 0f;
                foreach (var agent in _agents)
                {
                    health += agent.MaxHealth;
                }
                return health;
            }

            set
            {
                MaxHealth = value;
            }
        }

        public float CurrentRest 
        {
            get
            {
                var rest = 0f;
                foreach (var agent in _agents)
                {
                    rest += agent.CurrentRest;
                }
                return rest;
            }

            set
            {
                CurrentRest = value;
            }
        }

        public float MaxRest
        {
            get
            {
                var rest = 0f;
                foreach (var agent in _agents)
                {
                    rest += agent.MaxRest;
                }
                return rest;
            }

            set
            {
                MaxRest = value;
            }
        }

        public int MembersCount => _agents.Count;

        public IGroupState CurrentTarget { get; private set; }

        public Vector3 CurrentPosition
        {
            get
            {
                var allX = 0f;
                var allY = 0f;
                var allZ = 0f;
                foreach (IAgentState agent in _agents)
                {
                    allX += agent.CurrentPosition.X;
                    allY += agent.CurrentPosition.Y;
                    allZ += agent.CurrentPosition.Z;
                }

                return new Vector3(allX / _agents.Count, allY / _agents.Count, allZ / _agents.Count);
            }

            private set
            {
                CurrentPosition = value;
            }
        }
        public Vector3 TargetPosition { get; set; }
        public Vector3 LastPosition { get; set; }

        public IEnumerable<IAgentState> Agents => _agents;
        private List<IAgentState> _agents = new List<IAgentState>();

        public void AddAgent(IAgentState agent) => _agents.Add(agent);

        public void SetTarget(IGroupState target) => CurrentTarget = target;
        public void SetTargetPosition(Vector3 target) => TargetPosition = target;

        public int GetItemsCount(string name)
        {
            int count = 0;
            _agents.ForEach(x => count += x.GetItemsCount(name));
            return count;
        }

        public void Exchange(string outItem, string inItem, int count)
        {
            var neededCount = count;
            var inKey = _agents[0].Items.Keys.Where(x => x.Name == inItem).First();
            var outKey = _agents[0].Items.Keys.Where(x => x.Name == outItem).First();
            _agents[0].Items[inKey] += count;

            foreach(var agent in _agents)
            {
                if (neededCount == 0) 
                    break;

                if (agent.Items.ContainsKey(outKey) == false)
                    continue;

                if (agent.Items[outKey] >= neededCount)
                {
                    agent.Items[outKey] -= neededCount;
                }
                else if (agent.Items[outKey] > 0 && agent.Items[outKey] < neededCount)
                {
                    agent.Items[outKey] = 0;
                }

                neededCount -= agent.Items[outKey];
            }
        }
    }
}
