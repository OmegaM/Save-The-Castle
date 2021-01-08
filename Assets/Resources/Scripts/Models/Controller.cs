using System.Collections.Generic;
using System.Linq;
using UnityEngine;


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

    public virtual void MakeDamage(Ability ability, GameObject target)
    {
        
    }
}
