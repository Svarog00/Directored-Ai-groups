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
            RestAction(state),
            ChooseTargetAction(state),
            EquippedWeaponAction(state),
            AttackAction(state),
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

    public static AttackAction AttackAction(IAgentState state)
    {
        var condition = new ComppositeAgentCondition();
        condition.AddCondition(new HasTargetCondition(state));
        condition.AddCondition(new EquippedWeaponCondition(state));

        var attack = new AttackAction(state, condition);

        return attack;
    }

    public static ChooseTargetAction ChooseTargetAction(IAgentState state)
    {
        var condition = new ComppositeAgentCondition();

        var choose = new ChooseTargetAction(state, condition);

        return choose;
    }

    public static EquipWeaponAction EquippedWeaponAction(IAgentState state)
    {
        var condition = new ComppositeAgentCondition();

        var choose = new EquipWeaponAction(state, condition);

        return choose;
    }
}