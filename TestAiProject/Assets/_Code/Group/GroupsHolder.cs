using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Groups;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public static class GroupsHolder
{
    private static List<Group> _groups = new List<Group>();

    public static IEnumerable<Group> Groups => _groups;

    public static void Add(Group group) => _groups.Add(group);
    public static void Delete(Group group) => _groups.Remove(group);
    public static Group GetGroup(GroupId id) => _groups.Find(x => x.Id.Equals(id)); 
    public static Group GetGroup(int id) => GetGroup(new GroupId(id)); 

    public static Group GetClosestGroup(IGroupContext source)
    {
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
        var groups = _groups.Where(x => RelationsHolder.GetRelations(source.GetState().GroupId, x.GroupId) < 0);
        if (groups.Any() == false) return null;

        var minDistance = float.MaxValue;
        var output = groups.First();
        foreach (var group in groups)
        {
            var distance = Vector3.Distance(group.GetState().CurrentPosition, source.GetState().CurrentPosition);
            if (distance < minDistance)
            {
                output = group;
                minDistance = distance;
            }
        }

        return output;
    }
}