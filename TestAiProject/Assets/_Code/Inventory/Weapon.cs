using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/WeaponInstance", order = 1)]
public class Weapon : Item
{
    [SerializeField] private float _damage;

    public float Damage => _damage;
}