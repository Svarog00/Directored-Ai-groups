using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director
{
    public interface IScorer
    {
        float GetScore();
    }

    public abstract class Consideration
    {
        public abstract float GetScore(IGroupContext context);
    }

    public abstract class GroupScorer : IScorer
    {
        private IGroupContext _context;
        private List<Consideration> _considerations;

        public virtual float GetScore()
        {
            var result = 1f;

            foreach(var consideration in _considerations)
            {
                float score = consideration.GetScore(_context);

                result *= score;
            }

            return result;
        }
    }
}
