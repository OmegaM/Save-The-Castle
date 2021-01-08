﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;


public class Controller : MonoBehaviour, ICharacter
{
    public List<Ability> Abilities { get ; set ; }
    public Stats _stats;
    public Animator animator;
    

    public virtual void Death()
    {
        animator.SetBool("Death", true);
        GameObject.Destroy(this.gameObject, 5);
    }

    public virtual void GetDamage(Ability abillity)
    {
        var damage = 0.0f;
        if (abillity.AtackType == Enums.AtackTypes.Mage)
        {
            var defenseAttributes = _stats.MageDefense.GetType().GetProperties().Where(p => (float)p.GetValue(_stats.MageDefense, null) > 0);
            var atackAttributes = abillity.MageAtack.GetType().GetProperties().Where(p => (float)p.GetValue(abillity.MageAtack, null) > 0);
            foreach (var attribute in atackAttributes)
            {
                if (atackAttributes.Contains(attribute))
                {
                    damage += abillity.Damage - ((float)defenseAttributes.SingleOrDefault(p => p.Name == attribute.Name).GetValue(_stats.MageDefense, null) / 10);
                }
                else
                    damage += abillity.Damage;
            }
        }
        else
        {
            damage += abillity.Damage - (_stats.MeleeDefense / 10);
        }
        _stats.Health -= damage;
        Debug.Log($"Make {damage} damage | Current Heath Level is {_stats.Health}");

        if (_stats.Health <= 0)
        {
            Death();
            return;
        }
    }
    /// <summary>
    /// Using Tag, find target controller
    /// And make damage to it
    /// </summary>
    /// <param name="ability">Ability to use</param>
    /// <param name="target">Target of damage</param>
    public async virtual void MakeDamage(Ability ability, GameObject target)
    {
        animator.SetBool("CanAttack", true);
        switch (target.gameObject.tag)
        {
            case "Player":
                target.GetComponent<PlayerController>().GetDamage(ability);
                break;
            case "Enemy":
                target.GetComponent<EnemyController>().GetDamage(ability);
                break;
            case "Castle":
                target.GetComponent<CastleController>().GetDamage(ability);
                break;
            default:
                return;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            animator.SetBool("CanAttack", false);
    }
}
