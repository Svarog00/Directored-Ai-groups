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
        private List<Group> _offlineGroups = [];

        private readonly float _minimunScore = 0f;

        public override void Update()
        {
            UpdateActive();
            UpdateOffline();
        }

        public void AddBucket(Bucket bucket)
        {
            _buckets.Add(bucket);
        }

        public void RegisterGroup(Group group)
        {
            _activeGroups.Add(group);
        }

        public void MoveToOffline(Group group)
        {
            var activeGroup = _activeGroups.Find(x => group.GroupId.Equals(x.GroupId));
            if (activeGroup == null) return;

            _offlineGroups.Add(activeGroup);
        }

        private void UpdateActive()
        {
            GenerateGoals(_activeGroups);
        }

        private void UpdateOffline()
        {
            //Check offline groups and choose what to do them
            //Get their states, through scrorers and aggregators choose goal
            //Set goal
            //GenerateGoals(_offlineGroups);
            //Emulate outcome
        }

        /// <summary>
        /// Checks online groups and choose what to do them
        /// Get their states, through scrorers and aggregators choose goal
        /// Set goal
        /// </summary>
        /// <param name="groups"></param>
        private void GenerateGoals(List<Group> groups)
        {
            foreach (var group in groups)
            {
                Bucket bestBucket = _buckets.First();
                float floor = _minimunScore;
                foreach (var bucket in _buckets)
                {
                    var score = bucket.EvaluateBucket(group);

                    if (score > floor)
                    {
                        bestBucket = bucket;
                        floor = score;
                    }

                }

                SetGroupGoal(bestBucket.EvaluateGoals(group).Goal, group);
            }
        }

        private void SetGroupGoal(Goal goal, Group group)
        {
            if (goal == group.CurrentGoal) return;
            
            group.SetGroupGoal(goal);
        }
    }
}
