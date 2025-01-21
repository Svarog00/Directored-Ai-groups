using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class MoveToLocationGoal : Goal
{
    public MoveToLocationGoal(CompositeGroupCondition condition, IGroupContext group) : base(condition)
    {
        SetGroupContext(group);
    }

    public override void Accept()
    {
        var targetVector = Vector3.up;
        Debug.Log($"Accept {nameof(MoveToLocationGoal)}");
        var state = Group.GetState() as GroupState;
        foreach (var item in state.Agents)
        {
            item.SetTargetPosition(new System.Numerics.Vector3(targetVector.x, targetVector.y, targetVector.z));
        }
    }

}
