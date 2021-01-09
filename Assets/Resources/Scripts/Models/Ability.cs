using UnityEngine;


public class Ability
{
    public float Range { get; set; }
    public float CoolDown { get; set; }
    public float CDTimer { get; set; }
    public float Damage { get; set; }
    public Enums.AttackTypes AttackType { get; set; }
    public MageAttackAttributes MageAttack { get; set; }

    public GameObject prefab;
}
