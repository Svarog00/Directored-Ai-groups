using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public static GroupId CurrentGroupId = new(0);

    [SerializeField] private List<BucketScript> _buckets = new List<BucketScript>();
    [SerializeField] private AgentController _characterController;
    [SerializeField] private GroupView _groupView;

    private UtilityDirector _aiDirector;

    // Start is called before the first frame update
    void Start()
    {
        _aiDirector = new UtilityDirector();

        _buckets.ForEach(x => _aiDirector.AddBucket(x.Bucket));

        _aiDirector.RegisterGroup(_groupView.Model);

        var controller = new AiController<IAgentState>(_characterController.State);
        var brain = new GobBrain(controller);

        _characterController.SetController(controller);
        _groupView.AddAgent(_characterController.Controller);
    }

    // Update is called once per frame
    void Update()
    {
        _aiDirector.Update();
    }
}
