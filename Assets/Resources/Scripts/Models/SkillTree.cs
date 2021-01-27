using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillTree : MonoBehaviour, ISkillTree
{
    public SkillBranch AttackBranch { get; set; } = new SkillBranch();
    public SkillBranch SupportBranch { get; set; } = new SkillBranch();
    
    public int currentSkillPoints { get ; set ; }

    public List<Ability> currentSkills { get; } = new List<Ability>();

    public bool isCanLearnSkill {
        get 
        { 
            return currentSkillPoints > 0;
        }
    }
    /// <summary>
    /// Learn new skill
    /// </summary>
    /// <param name="skillToLearn"></param>
    public void LearnSkill(Ability skillToLearn)
    {
        if (currentSkills.Contains(skillToLearn) || !isCanLearnSkill)
            return;
        currentSkills.Add(skillToLearn);
        currentSkillPoints -= 1;
    }
    /// <summary>
    /// Reset All skills
    /// </summary>
    public void ResetSkills()
    {
        currentSkillPoints += currentSkills.Count;
        currentSkills.Clear();
    }
}

