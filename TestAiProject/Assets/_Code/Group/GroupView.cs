using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Groups;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupView : MonoBehaviour
{
    private Group _model;

    public Group Model => _model;

    public void Init()
    {
        _model = new Group(Entry.CurrentGroupId.Next());
    }

    public void AddAgent(AiController<IAgentState> character)
    {
        Debug.Log($"Add to {_model.GroupId.Id} agent {character.State.AgentId}");
        _model.AddAgent(character);
    }
}
