using InteractableGroupsAi.Agents;
using InteractableGroupsAi.Director.Groups;
using System.Collections.Generic;

public static class GroupsHolder
{
    private static List<Group> _groups = new List<Group>();

    public static void Add(Group group) => _groups.Add(group);
    public static void Delete(Group group) => _groups.Remove(group);
    public static Group GetGroup(GroupId id) => _groups.Find(x => x.Id.Equals(id)); 
    public static Group GetGroup(int id) => GetGroup(new GroupId(id)); 
}