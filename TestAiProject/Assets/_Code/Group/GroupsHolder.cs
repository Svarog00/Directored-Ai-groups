using AiLibrary.Other;
using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public static class GroupsHolder
{
    private static List<Group> _groups = new List<Group>();

    public static IEnumerable<Group> Groups => _groups;

    public static void Add(Group group) => _groups.Add(group);
    public static void Delete(Group group) => _groups.Remove(group);
    public static Group GetGroup(GroupId id)
    {
        foreach (Group group in _groups)
        {
            if (group.GroupId.Id == id.Id)
                return group;
        }

        return null;
    }

    public static Group GetGroup(int id) => GetGroup(new GroupId(id));

    public static Group GetClosestGroup(IGroupContext source) => GetClosestGroup(source, _ => true);

    private static Group GetClosestGroup(IGroupContext source, Func<Group, bool> predicate)
    {
        var groups = _groups.Where(x => RelationsHolder.GetRelations(source.GetState().GroupId, x.GroupId) < 0);
        if (groups.Any() == false) return null;

        var minDistance = float.MaxValue;
        var group = _groups.First();
        foreach(var variant in _groups)
        {
            if (variant == source) continue;

            var distance = Vector3.Distance(variant.GetState().CurrentPosition, source.GetState().CurrentPosition);
            if (distance < minDistance)
            {
                group = variant;
                minDistance = distance;
            }
        }
        
        if (group == source) return null;
        return group;
    }

    public static Group GetClosestEnemyGroup(IGroupContext source) 
    {
        return GetClosestGroup(source, x => RelationsHolder.GetRelations(source.GetState().GroupId, x.GroupId) < 0);
    }

    public static Group GetClosestFriendlyGroup(IGroupContext source)
    {
        return GetClosestGroup(source, x => RelationsHolder.GetRelations(source.GetState().GroupId, x.GroupId) >= 0);
    }
}