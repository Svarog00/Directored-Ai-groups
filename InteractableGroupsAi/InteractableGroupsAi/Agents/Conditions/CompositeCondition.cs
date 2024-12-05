namespace InteractableGroupsAi.Agents.Conditions
{
    public class NullCompositeCondiiton : CompositeCondition
    {

    }

    public class CompositeCondition
    {
        private List<Condition> _conditions = [];

        public bool IsSatisfied()
        {
            foreach (var condition in _conditions)
            {
                if (condition.Check() == false) return false;
            }

            return true;
        }
    }
}
