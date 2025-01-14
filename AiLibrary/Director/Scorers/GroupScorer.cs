using InteractableGroupsAi.Director.Groups;
using System.Collections.Generic;

namespace InteractableGroupsAi.Director
{
    public interface IScorer
    {
        float GetScore();
    }

    /// <summary>
    /// Для каждого бакета\гоала имеется этот класс с разным списком консидерейшенов, 
    /// В которых оценивается стат группы для выбора наилучшего для текущей ситуации
    /// </summary>
    public abstract class GroupScorer : IScorer
    {
        private IGroupContext _context;
        private List<Consideration> _considerations = new List<Consideration>();

        public GroupScorer(IGroupContext context)
        {
            _context = context;
        }

        public void AddConsideration(Consideration consideration) => _considerations.Add(consideration);

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
