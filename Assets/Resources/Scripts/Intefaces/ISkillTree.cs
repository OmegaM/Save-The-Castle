using System.Collections.Generic;

public interface ISkillTree
{
    SkillBranch AttackBranch { get; set; }
    SkillBranch SupportBranch { get; set; }
    List<Ability> currentSkills { get; }
    int currentSkillPoints { get; set; }
    bool isCanLearnSkill {get; }

    void LearnSkill(Ability skillToLearn);
    void ResetSkills();
}
