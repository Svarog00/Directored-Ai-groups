using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director;
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
