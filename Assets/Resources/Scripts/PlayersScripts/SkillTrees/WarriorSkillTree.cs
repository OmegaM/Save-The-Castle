using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WarriorSkillTree : SkillTree
{
    public WarriorSkillTree()
    {
        AttackBranch.FirstLine = new List<Ability>();
        AttackBranch.FirstLine.Add(
            new Ability 
            { 
                abillityName = "Attack Stence",
                SkillBranch = Enums.SkillBranches.Attack,
                IsActive = false,
                description = "Increases melee atack power on 1%",
                prefab = (GameObject)Resources.Load("Prefabs\\light_attack")
            });
        AttackBranch.FirstLine.Add(
            new Ability
            {
                abillityName = "Holy Hammer",
                AttackType = Enums.AttackTypes.Mage,
                Damage = 50,
                IsActive = true,
                MageAttack = new MageAttackAttributes { Light = 10 },
                CoolDown = 10f,
                prefab = (GameObject)Resources.Load("Prefabs\\light_attack"),
                description = "Throw holy hammer in enemy"
            });
        AttackBranch.FirstLine.Add(
            new Ability
            {
                abillityName = "Dark bolt",
                AttackType = Enums.AttackTypes.Mage,
                Damage = 50,
                IsActive = true,
                MageAttack = new MageAttackAttributes { Darkness = 10 },
                CoolDown = 10f,
                prefab = (GameObject)Resources.Load("Prefabs\\dark_attack"),
                description = "Throw in enemy dark bolt to make it damage"
            });
        AttackBranch.SecondLine = new List<Ability>();
        AttackBranch.FinalLine = new List<Ability>();
    }
}

