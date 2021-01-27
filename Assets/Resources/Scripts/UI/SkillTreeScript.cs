using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class SkillTreeScript : MonoBehaviour
{
    private int currentSkillIndex;
    public Button buttonPrefab;

    public void SetSkillBranch(SkillBranch abillityList, Enums.SkillBranches branch)
    {
        currentSkillIndex = 0;
        var branchPanel = this.transform.GetComponentsInChildren<Transform>().SingleOrDefault(b => b.name.Contains(branch.ToString()));
        Button tmp;
        abillityList.FirstLine.ForEach(fl =>
        {
            tmp = Instantiate(buttonPrefab, new Vector2(transform.position.x + ((RectTransform)buttonPrefab.transform).rect.width * currentSkillIndex, transform.position.y), Quaternion.identity);
            tmp.GetComponentInChildren<Image>().sprite = fl.prefab.GetComponent<SpriteRenderer>().sprite;
            tmp.onClick.AddListener(() => LearnSkill(fl));
            tmp.transform.SetParent(branchPanel);
            currentSkillIndex++;
        });
    }

    private void LearnSkill(Ability fl)
    {
        Console.WriteLine($"Learning Skill {fl}");
    }
}
