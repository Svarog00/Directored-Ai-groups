using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public static GroupId CurrentGroupId = new(0);

    [SerializeField] private List<AgentController> _characterControllers;
    [SerializeField] private GroupView _groupView;

    private UtilityDirector _aiDirector;

    // Start is called before the first frame update
    void Awake()
    {
        _aiDirector = new UtilityDirector();

        var bucket = new Bucket(1, GoalHolder.GoalScorer(_groupView.Model.GetState()));

        bucket.AddGoal(
               new CondideredGoal(
                    GoalHolder.MoveToLocation(),
                    GoalHolder.GoalScorer(_groupView.Model.GetState())));

        _aiDirector.AddBucket(bucket);

        _aiDirector.RegisterGroup(_groupView.Model);

        //_buckets.ForEach(x => _aiDirector.AddBucket(x.Bucket));

        int i = 0;
        foreach(var character in _characterControllers)
        {
            character.Init();
            character.State.SetAgentId(i++);
            var controller = new AiController<IAgentState>(character.State);

            var brain = new GobBrain(controller);
            controller.SetBrain(brain);

            var action = new RestAction(new ComppositeAgentCondition());
            action.Init(character.State);
            brain.SetAvailableActions(new List<AgentAction> { action });

            character.SetController(controller);
            character.Controller.GetCharacterState().SetGroupId(new GroupId(0));
            _groupView.AddAgent(character.Controller);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _aiDirector.Update();
    }
}
