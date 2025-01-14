using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public static GroupId CurrentGroupId = new(0);

    [SerializeField] private List<AgentController> _characterController;

    private UtilityDirector _aiDirector;

    // Start is called before the first frame update
    void Awake()
    {
        _aiDirector = new UtilityDirector();

        //_buckets.ForEach(x => _aiDirector.AddBucket(x.Bucket));

        //_aiDirector.RegisterGroup(_groupView.Model);

        foreach(var character in _characterController)
        {
            character.Init();
            var controller = new AiController<IAgentState>(character.State);

            /*var brain = new GobBrain(controller);
            controller.SetBrain(brain);*/

            character.SetController(controller);
            character.Controller.GetCharacterState().SetGroupId(new GroupId(0));
        }
        //_groupView.AddAgent(_characterController.Controller);
    }

    // Update is called once per frame
    void Update()
    {
        _aiDirector.Update();
    }
}
