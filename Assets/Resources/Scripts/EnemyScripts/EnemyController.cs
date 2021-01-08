using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : Controller
{
   
    public int level;
    public float abilityRange;
    public float abilityCoolDown;
    public float abilityDamage;
    public Enums.AtackTypes abilityAtackType;
    public MageAtackAttributes abilityAttributes;
    public GameObject abilityPrefab;

    private void Awake()
    {
        _stats = GetComponent<Stats>();
        _stats.Health = level * 100;
        _stats.Ability = new Ability 
        {
            AtackType = abilityAtackType,
            CDTimer = 0.0f,
            CoolDown = abilityCoolDown,
            Damage = abilityDamage,
            MageAtack = abilityAttributes,
            Range = abilityRange,
            prefab = abilityPrefab
        };
        animator.SetBool("Death", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "main_target")
            MakeDamage(_stats.Ability,collision.gameObject);
        animator.SetBool("CanAtack", false);
    }

    

    public override void MakeDamage(Ability ability, GameObject target)
    {
        animator.SetBool("CanAtack",true);
        if (target.gameObject.tag == "Player")
            target.GetComponent<PlayerController>().GetDamage(ability);
        else if (target.gameObject.tag == "main_target")
            target.GetComponent<CastleController>().GetDamage(ability);

    }
}
