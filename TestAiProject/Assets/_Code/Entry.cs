using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AgentsList : List<AgentController>
{
    [SerializeField] private List<AgentController> _characters = new();
}

public class Entry : MonoBehaviour
{
    public static GroupId CurrentGroupId = new(0);

    [SerializeField] private List<AgentsList> _characters;
    [SerializeField] private List<GroupView> _groupView;

    private UtilityDirector _aiDirector;

    // Start is called before the first frame update
    void Awake()
    {
        _aiDirector = new UtilityDirector();

        int i = 0;
        int agentId = 0;
        foreach(var group in _groupView)
        {
            var bucket = new Bucket(1, GoalHolder.GoalScorer(group.Model.GetState()));

            bucket.AddGoal(
                   new CondideredGoal(
                        GoalHolder.MoveToLocation(),
                        GoalHolder.GoalScorer(group.Model.GetState())));

            _aiDirector.AddBucket(bucket);

            _aiDirector.RegisterGroup(group.Model);

            //_buckets.ForEach(x => _aiDirector.AddBucket(x.Bucket));
            foreach (var character in _characters[i])
            {
                character.State.SetAgentId(agentId++);
                character.State.SetGroupId(group.Model.GroupId);
                character.Init();

                var controller = new AiController<IAgentState>(character.State);

                var brain = new GobBrain(controller);
                controller.SetBrain(brain);

                var action = new RestAction(new ComppositeAgentCondition());
                action.Init(character.State);
                brain.SetAvailableActions(new List<AgentAction> { action });

                character.SetController(controller);
                character.Controller.GetCharacterState().SetGroupId(group.Model.GroupId);
                group.AddAgent(character.Controller);
            }
            i++;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        _aiDirector.Update();
    }
}
