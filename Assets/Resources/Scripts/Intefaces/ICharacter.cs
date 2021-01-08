using System.Collections.Generic;
using UnityEngine;

interface ICharacter
{
    List<Ability> Abilities { get; set; }
    void GetDamage(Ability ability);
    void MakeDamage(Ability ability, GameObject target);
    void Death();
     
}

