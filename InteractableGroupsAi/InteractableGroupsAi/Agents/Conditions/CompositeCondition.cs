namespace InteractableGroupsAi.Agents.Conditions
{
    public class CompositeCondition<T> where T : Condition
    {
        protected List<T> Conditions = [];

        public void AddConditions(List<T> conditions)
        {
            conditions.ForEach(AddCondition);
        }

        public void AddCondition(T condition)
        {
            Conditions.Add(condition);
        }

        public bool IsSatisfied()
        {
            foreach (var condition in Conditions)
            {
                if (condition.Check() == false) return false;
            }

            return true;
        }
    }

    public class CompositeGroupCondition : CompositeCondition<GroupCondition>
    {
        public float GetDelta(AgentAction action)
        {
            var delta = 0f;
            foreach(var condition in Conditions)
            {
                delta += condition.GetConditionDelta(action);
            }
            
            return delta;
        }
    }

    public class ComppositeAgentCondition : CompositeCondition<AgentCondition>
    {
        public bool TrySatisfyConditions(AgentAction action)
        {
            foreach (var condition in Conditions)
            {
                if (condition.TrySatisfyCondition(action) == false) return false;
            }

            return true;
        }
    }
}
