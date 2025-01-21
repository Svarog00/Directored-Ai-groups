using InteractableGroupsAi;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;
using System.Collections.Generic;
using UnityEngine;

public static class GoalHolder
{
    public static MoveToLocationGoal MoveToLocation(IGroupContext group)
    {
        var moveToCondition = new CompositeGroupCondition();
        var desiredState = new DesiredGroupState();
        desiredState.CurrentPosition = new System.Numerics.Vector3(1, 1, 1);

        moveToCondition.AddCondition(new LocationGroupCondition(desiredState));

        return new MoveToLocationGoal(moveToCondition, group);
    }

    public static GroupScorer GoalScorer(IGroupState model) => new GroupScorer(model);
}

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