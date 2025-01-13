using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Groups;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupView : MonoBehaviour
{
    private Group _groupModel;

    public Group Model => _groupModel;

    // Start is called before the first frame update
    void Awake()
    {
        _groupModel = new Group(Entry.CurrentGroupId.Next());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAgent(AiController<IAgentState> character)
    {
        _groupModel.AddAgent(character);
    }
}
