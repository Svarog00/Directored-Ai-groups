using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class MoveToRandomLocationGoal : Goal
{
    public MoveToRandomLocationGoal(CompositeGroupCondition condition, IGroupContext group) : base(condition)
    {
        SetGroupContext(group);
    }

    public override void Accept()
    {
        var targetVector = new System.Numerics.Vector3(Random.value, Random.value, 0);
        Debug.Log($"Accept {nameof(MoveToRandomLocationGoal)}");
        Group.GetState().SetTargetPosition(targetVector);
        var state = Group.GetState() as GroupState;
        foreach (var item in state.Agents)
        {
            item.SetTargetPosition(targetVector);
        }
    }
}
