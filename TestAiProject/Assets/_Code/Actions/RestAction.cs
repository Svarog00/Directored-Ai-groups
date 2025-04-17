using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using UnityEngine;

public class RestAction : AgentAction
{
    private IAgentState _agentState;
    private float _restForTick = 0.1f;

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
        return _restForTick;
    }

    public override IAgentState GetNewState()
    {
        return null;
    }

    public override void OnBegin()
    {

    }

    public override void OnEnd()
    {

    }

    public override void TryExecute()
    {

    }

    public override void Update()
    {
        _agentState.SetRest(_agentState.CurrentRest + _restForTick * 10 * Time.deltaTime);
    }
}
