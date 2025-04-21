using AiLibrary.Other;
using InteractableGroupsAi.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Relation : IEquatable<Relation>
{
    [SerializeField] private int _one;
    [SerializeField] private int _two;
    [SerializeField] private int _value;

    public GroupId One => new GroupId(_one);
    public GroupId Two => new GroupId(_two);
    public int Value => _value;

    public Relation(int one, int two, int value = 0)
    {
        _one = one;
        _two = two;
        _value = value;
    }

    public bool Equals(Relation other)
    {
        if (other == null) return false;

        return One.Id.Equals(other.One.Id) && Two.Id.Equals(other.Two.Id)
            || One.Id.Equals(other.Two.Id) && Two.Id.Equals(other.One.Id);
    }

    public override string ToString() => $"{_one} and {_two} is {_value}";
}

public static class RelationsHolder
{
    public const int MaxRelations = 1000;
    public const int LowestRelations = -1000;

    private static List<Relation> _relations = new();

    public static int GetRelations(GroupId one, GroupId two)
    {
        var relation = _relations.FirstOrDefault(x => x.Equals(new Relation(one.Id, two.Id)));
        if (relation == null) return 0;

        return relation.Value;
    }

    public static void AddRelations(GroupId one, GroupId two, int value) => _relations.Add(new Relation(one.Id, two.Id, value));
    public static void AddRelations(int one, int two, int value) => _relations.Add(new Relation(one, two, value));
    public static void Set(List<Relation> relations) => _relations = relations;
}
