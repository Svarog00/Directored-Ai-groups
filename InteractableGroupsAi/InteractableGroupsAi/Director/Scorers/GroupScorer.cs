﻿using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director
{
    public interface IScorer
    {
        float GetScore();
    }

    public abstract class GroupScorer : IScorer
    {
        private IGroupContext _context;
        private List<Consideration> _considerations;

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
