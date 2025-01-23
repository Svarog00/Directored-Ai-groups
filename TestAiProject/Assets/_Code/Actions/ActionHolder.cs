using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using System.Collections.Generic;

public static class ActionHolder
{
    public static List<AgentAction> GetActions(CharacterState state, AgentController controller)
    {
        var list = new List<AgentAction>
        {
            MoveToAction(state, controller),
            RestAction(state)
        };

        return list;
    }

    public static MoveToAction MoveToAction(CharacterState state, AgentController controller)
    {
        var moveAction = new MoveToAction(state, controller, new ComppositeAgentCondition());
        return moveAction;
    }

    public static RestAction RestAction(IAgentState state)
    {
        var restAction = new RestAction(new ComppositeAgentCondition());
        restAction.Init(state);
        return restAction;
    }
}