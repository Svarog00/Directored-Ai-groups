using InteractableGroupsAi.Other;
using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/WeaponInstance", order = 1)]
public class WeaponSo : ItemSo
{
    [SerializeField] private Weapon _weapon;
}

[Serializable]
public class Weapon : Item
{
    [SerializeField] private float _damage;

    public float Damage => _damage;
}