using AiLibrary.Other;
using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Buckets;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class AgentsList
{
    public List<AgentController> Characters = new();
}

public class Entry : MonoBehaviour
{
    public static GroupId CurrentGroupId = new(0);

    [SerializeField] private List<AgentsList> _characters;
    [SerializeField] private List<GroupView> _groupView;
    [SerializeField] private int _groupCount = 3;

    private UtilityDirector _aiDirector;

    // Start is called before the first frame update
    void Awake()
    {
        AiLogger.SetLogger(new UnityLogger());
        _aiDirector = new UtilityDirector();

        int agentId = 0;
        for (int i = 0; i < _groupCount; i++)
        {
            var group = new Group(Entry.CurrentGroupId.Next());
            var bucket = new Bucket(1, GoalHolder.GoalScorer(group.GetState()));

            bucket.AddGoal(GoalHolder.RestGoal(group));
            bucket.AddGoal(GoalHolder.MoveToLocation(group));
            bucket.AddGoal(GoalHolder.DestroyGroupGoal(group));
            bucket.AddGoal(GoalHolder.DestroyGroupGoal(group));

            group.AddBucket(bucket);

            _aiDirector.RegisterGroup(group);
            GroupsHolder.Add(group);

            foreach (var character in _characters[i].Characters)
            {
                character.Init(group.GroupId, agentId++);

                var controller = new AiController<IAgentState>(character.State);

                var brain = new GobBrain(controller);
                controller.SetBrain(brain);

                brain.SetAvailableActions(ActionHolder.GetActions(character.State, character));

                character.SetController(controller);
                group.AddAgent(character.Controller);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _aiDirector.Update();
    }
}
