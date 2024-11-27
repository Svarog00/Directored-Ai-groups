using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Director.Buckets
{
    public class Bucket
    {
        private float _weight;
        private List<Goal> _goals;

        public float Weight => _weight;

        public Bucket(float weight)
        {
            _weight = weight;
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }
    }
}
