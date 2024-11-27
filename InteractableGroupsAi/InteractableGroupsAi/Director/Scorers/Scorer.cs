using InteractableGroupsAi.Director.Goals;

namespace InteractableGroupsAi.Director
{
    public abstract class Scorer
    {
        private Func<float> _scoreFunction;

        public abstract float GetScore(Goal goal);
    }
}
