using System;
using System.Collections.Generic;
using System.Linq;

public class SkillBranch
{
    public List<Ability> FirstLine;
    public Ability SelectedFirstLineAbillity { get; set; }
    public List<Ability> SecondLine;
    public Ability SelectedSecondLineAbility { get; set; }
    public List<Ability> FinalLine;
    public Ability SelectedFinalLineAbillity { get; set; } 
}
