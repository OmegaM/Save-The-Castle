using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameMenuScript : MonoBehaviour
{
    private GameObject _skillPanel;
    private GameObject _currentPlayer;
    public Button skillButton;
    private SkillTree _skillTree;
    public  GameObject CurrentPlayer {
        get { return _currentPlayer; }
        set 
        {
            if (value == _currentPlayer) return;
            _currentPlayer = value;
            SkillTreeRefresh();
        }
    }
    private MainCamera _cameraScript;
    private void Start()
    {
        _skillPanel = GameObject.Find("SkillPanel");
        _cameraScript = Camera.main.GetComponent<MainCamera>();
        _skillTree = _currentPlayer.GetComponent<SkillTree>();
    }

    private void Update()
    {
        CurrentPlayer = _cameraScript.currentPlayer;
    }

    public void SkillTreeOpen()
    {
        
    }
    /// <summary>
    /// Method of refreshing skill tree
    /// When change player
    /// </summary>
    private void SkillTreeRefresh()
    {
        var tree = _currentPlayer.GetComponent<PlayerController>().skills;
        var panel = _skillPanel.GetComponent<SkillTreeScript>();
        panel.SetSkillBranch(tree.AttackBranch, Enums.SkillBranches.Attack);
        panel.SetSkillBranch(tree.SupportBranch, Enums.SkillBranches.Support);

        //tree.AttackBranch.FirstLine.ForEach(afl =>
        //{
        //    var skill = Instantiate(skillButton, attackPanel.);
        //    var skillPrefab = skill.GetComponentInChildren<GameObject>();
        //    skillPrefab = afl.prefab;
        //    skill.onClick.AddListener(() => _skillTree.LearnSkill(afl));
        //});
        //tree.AttackBranch.SecondLine.ForEach(asl =>
        //{
        //    var skill = Instantiate(skillButton, attackPanel.transform);
        //    var skillPrefab = skill.GetComponentInChildren<GameObject>();
        //    skillPrefab = asl.prefab;
        //    skill.onClick.AddListener(() => _skillTree.LearnSkill(asl));
        //});
        //tree.AttackBranch.FinalLine.ForEach(afil =>
        //{
        //    var skill = Instantiate(skillButton, attackPanel.transform);
        //    var skillPrefab = skill.GetComponentInChildren<GameObject>();
        //    skillPrefab = afil.prefab;
        //    skill.onClick.AddListener(() => _skillTree.LearnSkill(afil));
        //});
        var supportBranch = _skillPanel.GetComponentsInChildren<Grid>().SingleOrDefault(p => p.gameObject.name.Contains("Support"));
    }
}
