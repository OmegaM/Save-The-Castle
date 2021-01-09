﻿using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : Controller
{
   
    public int level;
    public float abilityRange;
    public float abilityCoolDown;
    public float abilityDamage;
    public Enums.AttackTypes abilityAttackType;
    public MageAttackAttributes abilityAttributes;
    public GameObject abilityPrefab;

    private void Awake()
    {
        _stats = GetComponent<Stats>();
        _stats.Health = level * 100;
        _stats.Ability = new Ability 
        {
            AttackType = abilityAttackType,
            CDTimer = 0.0f,
            CoolDown = abilityCoolDown,
            Damage = abilityDamage,
            MageAttack = abilityAttributes,
            Range = abilityRange,
            prefab = abilityPrefab
        };
        animator.SetBool("Death", false);
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            animator.SetBool("CanAttack", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Castle")
            MakeDamage(_stats.Ability,collision.gameObject);
        
    }
}
