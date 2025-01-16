using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using UnityEngine;

public class RestAction : AgentAction
{
    private IAgentState _agentState;

    public RestAction(ComppositeAgentCondition condition) : base(condition)
    {
    }

    public void Init(IAgentState agentState)
    {
        _agentState = agentState;
    }

    public override void ForceEnd()
    {

    }

    public override float GetGoalChange(Goal goal)
    {
        return 0.5f;
    }

    public override IAgentState GetNewState()
    {
        return null;
    }

    public override void OnBegin()
    {
        Debug.Log("Start resting action  on " + _agentState.AgentId);
    }

    public override void OnEnd()
    {

    }

    public override void TryExecute()
    {

    }

    public override void Update()
    {

    }
}
