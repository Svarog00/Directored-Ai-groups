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

    private UtilityDirector _aiDirector;

    private static List<GroupView> _groups;

    // Start is called before the first frame update
    void Awake()
    {
        _aiDirector = new UtilityDirector();

        int i = 0;
        int agentId = 0;
        foreach(var group in _groupView)
        {
            group.Init();
            var bucket = new Bucket(1, GoalHolder.GoalScorer(group.Model.GetState()));

            bucket.AddGoal(
                   new CondideredGoal(
                        GoalHolder.MoveToLocation(group.Model),
                        GoalHolder.GoalScorer(group.Model.GetState())));

            group.Model.AddBucket(bucket);

            _aiDirector.RegisterGroup(group.Model);

            foreach (var character in _characters[i].Characters)
            {
                character.Init(group.Model.GroupId, agentId++);

                var controller = new AiController<IAgentState>(character.State);

                var brain = new GobBrain(controller);
                controller.SetBrain(brain);

                brain.SetAvailableActions(ActionHolder.GetActions(character.State, character));

                character.SetController(controller);
                group.AddAgent(character.Controller);
            }
            i++;
        }

        _groups = _groupView;
    }

    // Update is called once per frame
    void Update()
    {
        _aiDirector.Update();
    }

    public static Group FindGroup(GroupId id)
    {
        return _groups.Select(x => x.Model).Where(x => x.GroupId.Equals(id)).FirstOrDefault();
    }
}
