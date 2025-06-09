using AiLibrary.Other;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;
using InteractableGroupsAi.Other;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public class AgentsList
{
    public List<AgentController> Characters = new();
}

public class Entry : MonoBehaviour
{
    public static GroupId CurrentGroupId = new(0);

    [SerializeField] private LineRendererInstance _linePrefab;

    [SerializeField] private Text _text;
    [SerializeField] private Text _stats;
    
    [SerializeField] private Transform _lowRandomBorder;
    [SerializeField] private Transform _highRandomBorder;

    [SerializeField] private Transform[] _groupRoots;

    [SerializeField] private List<Relation> _relations = new List<Relation>();
    [SerializeField] private List<AgentsList> _characters;
    [SerializeField] private int _groupCount = 3;
    [SerializeField] private float _directorUpdateTime = 3f;

    [Space]
    [SerializeField] private List<Transform> _points = new();

    private UtilityDirector _aiDirector;
    private float _currentUpdateTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        GroupsHolder.SetLineRendererPrefab(_linePrefab);
        AiLogger.SetLogger(new UnityLogger());
        _aiDirector = new UtilityDirector();

        int agentId = 0;
        for (int i = 0; i < _characters.Count; i++)
        {
            _groupRoots[i].position = new Vector2(
                Random.Range(_lowRandomBorder.position.x, _highRandomBorder.position.x),
                Random.Range(_lowRandomBorder.position.y, _highRandomBorder.position.y));

            var group = new Group(CurrentGroupId.Next());

            var fightBucket = BucketHolder.FightBucket(group);
            var explorationBucket = BucketHolder.ExploreBucket(group);
            var socialsBucket = BucketHolder.SocialBucket(group);

            fightBucket.AddGoal(GoalHolder.DestroyGroupGoal(group));
            fightBucket.AddGoal(GoalHolder.FleeGoal(group));

            explorationBucket.AddGoal(GoalHolder.MoveToLocation(group));
            explorationBucket.AddGoal(GoalHolder.RestGoal(group));

            socialsBucket.AddGoal(GoalHolder.AskMedkitGoal(group));
            socialsBucket.AddGoal(GoalHolder.AskFoodGoal(group));

            group.AddBucket(explorationBucket);
            group.AddBucket(fightBucket);
            group.AddBucket(socialsBucket);


            _aiDirector.RegisterGroup(group);
            GroupsHolder.Add(group);

            foreach (var character in _characters[i].Characters)
            {
                int snacksCount = Random.Range(0, 2);
                int medkitCount = Random.Range(0, 2);

                character.Init(group.GroupId, agentId++);
                character.State.SetItems(new Dictionary<Item, int>()
                {
                    { new Item(0, "Snack"), snacksCount },
                    { new Item(1, "Medkit"), medkitCount },
                    { new Weapon(2, "Gun", 5), 1 },
                });

                character.SetHealth(Random.Range(10, 101));
                character.SetRest(Random.Range(10, 101));

                var controller = new AiController<IAgentState>(character.State);

                var brain = new GobBrain(controller);
                controller.SetBrain(brain);

                brain.SetAvailableActions(ActionHolder.GetActions(character.State, character));

                character.SetController(controller);
                group.AddAgent(character.Controller);
            }
        }

        foreach (var point in _points)
        {
            var vec = new System.Numerics.Vector3(point.position.x, point.position.y, point.position.z);
            PointsHolder.Add(vec);
        }

        RelationsHolder.Set(_relations);
    }

    // Update is called once per frame
    void Update()
    {
        _currentUpdateTime -= Time.deltaTime;
        if (_currentUpdateTime <= 0f)
        {
            GroupsHolder.DeleteLines();
            _currentUpdateTime = _directorUpdateTime;
            _aiDirector.Update();
        }

        ShowGroupsGoals();
        ShowGroupsStats();
    }

    private void ShowGroupsStats()
    {
        var sb = new StringBuilder();
        foreach (var group in _aiDirector.Groups)
        {
            sb.AppendLine($"Group {group.GroupId.Id}: HP: {group.State.CurrentHealth:0} | Rest: {group.State.CurrentRest:0}");
        }

        _stats.text = sb.ToString();
    }

    private void ShowGroupsGoals()
    {
        var sb = new StringBuilder();
        foreach (var group in _aiDirector.Groups)
        {
            if (group.State.CurrentHealth == 0) continue;
            sb.AppendLine($"Group {group.GroupId.Id}: {group.CurrentGoal}");
        }

        _text.text = sb.ToString();
    }
}
