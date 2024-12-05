using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director
{

    public class UtilityDirector : Director
    {
        private List<Bucket> _buckets = [];
        private List<Group> _activeGroups = [];
        private List<IUpdatable> _offlineGroups = [];

        private readonly float _minimunScore = 0f;

        public override void Update()
        {
            UpdateActive();
            UpdateOffline();
        }

        public void RegisterGroup(Group group)
        {
            _activeGroups.Add(group);
        }

        private void UpdateActive()
        {
            foreach (var group in _activeGroups)
            {
                Bucket possibleBucket = null;
                float floor = _minimunScore;
                foreach (var bucket in _buckets)
                {
                    /*
                     * TODO: Change to evaluating the best bucket in current context, 
                     * and picking the best goal from the bucket 
                     */
                    var score = bucket.EvaluateBucket(group);

                    if (score > floor)
                    {
                        possibleBucket = bucket;
                        floor = score;
                    }

                }
                SetGroupGoal(possibleBucket.EvaluateGoals(group).Goal, group);
            }

            //Checks online groups and choose what to do them
            //Get their states, through scrorers and aggregators choose goal
            //Set goal
        }

        private void UpdateOffline()
        {
            //Check offline groups and choose what to do them
            //Get their states, through scrorers and aggregators choose goal
            //Set goal
        }

        private void SetGroupGoal(Goal goal, Group group)
        {
            group.SetGroupGoal(goal);
        }
    }
}
