using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director
{
    public interface IScorer
    {
        float GetScore();
    }

    public abstract class GoalScorer : IScorer
    {
        private IGroupContext _context;

        public abstract float GetScore();
    }

    public abstract class BucketScorer : IScorer
    {
        private IGroupContext _context;

        public abstract float GetScore();
    }
}
