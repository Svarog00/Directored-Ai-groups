using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;

namespace InteractableGroupsAi.Director
{

    public class UtilityDirector : Director
    {
        

        private List<Bucket> _buckets;
        private List<Group> _activeGroups;
        private List<IUpdatable> _offlineGroups;

        public override void Update()
        {
            UpdateActive();
            UpdateOffline();
        }

        private void UpdateActive()
        {
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
