using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    public GameObject currentPlayer;
    private GameObject[] _playerCharacters;
    public Button playerButton;
    public Button skillButton;
    private GameObject _drownedPlayer;
    void Update()
    {
        this.transform.position = new Vector3(currentPlayer.transform.position.x, -1.9f, -10);
    }
    public void Start()
    {
        _playerCharacters = GameObject.FindGameObjectsWithTag("Player");
        currentPlayer = _playerCharacters.FirstOrDefault();
        var playersList = GameObject.Find("PlayersList");
        for(var i = 0; i < _playerCharacters.Length; i++)
        {
            var player = _playerCharacters[i];
            var btn = Instantiate(playerButton, new Vector2(playersList.transform.position.x, playersList.transform.position.y + (((RectTransform)playerButton.transform).rect.height) * i), Quaternion.identity);
            btn.image.sprite = player.GetComponent<SpriteRenderer>().sprite;
            btn.onClick.AddListener(() => ChangeCurrentPalyer(player));
            btn.transform.SetParent(playersList.transform);
        }
        SetPlayersSkills();
    }
    /// <summary>
    /// Click players button 
    /// </summary>
    /// <param name="player"></param>
    private void ChangeCurrentPalyer(GameObject player)
    {
        currentPlayer = player;
        SetPlayersSkills();
    }
    /// <summary>
    /// When changed selected player
    /// We need to redraw skills
    /// </summary>
    private void SetPlayersSkills()
    {
        var skillList = GameObject.Find("SkillsList");
        if (_drownedPlayer == currentPlayer)
            return;
        var childs = skillList.transform.GetChildCount();
        if (childs > 0)
            CleanSkillChilds();
        var playerSkills = currentPlayer.GetComponent<SkillTree>().currentSkills.Where(s => s.IsActive).ToArray();
        
        for (var i = 0; i < playerSkills.Count(); i++)
        {
            var skill = playerSkills[i];
            var btn = Instantiate(skillButton, new Vector2((skillList.transform.position.x + (((RectTransform)skillButton.transform).rect.width) * i), skillList.transform.position.y), Quaternion.identity);
            btn.transform.SetParent(skillList.transform);
            btn.transform.Find("ImgPlace").GetComponentInChildren<Image>().sprite = skill.prefab.GetComponent<SpriteRenderer>().sprite;
            btn.transform.Find("CoolDown").GetComponent<Image>().fillAmount = 0;
            btn.onClick.AddListener(() => UseSkill(skill, btn));
        }
        _drownedPlayer = currentPlayer;
    }
    /// <summary>
    /// Let player use active skills
    /// </summary>
    /// <param name="skill">Skill</param>
    /// <param name="btn">link to btn from panel</param>
    public void UseSkill(Ability skill, Button btn)
    {
        var currentPalyerSkill = currentPlayer.GetComponent<PlayerController>().Abilities.SingleOrDefault(s => s.abillityName == skill.abillityName);
        if (!currentPalyerSkill.CanBeUsed)
            return;
        var attackPlace = currentPlayer.transform.Find("AttackArea");
        var tmp = Instantiate(skill.prefab, new Vector2(attackPlace.transform.position.x, attackPlace.transform.position.y), Quaternion.identity);
        tmp.GetComponent<Stats>().Ability = skill;
        tmp.GetComponent<Rigidbody2D>().velocity = (currentPlayer.transform.rotation.y == 0 ? Vector2.right : Vector2.left) * 50.0f * Time.deltaTime;
        currentPalyerSkill.ResetCoolDownTimer();
        btn.GetComponent<SkillButtonScript>().cdTime = skill.CoolDown;
    }
    /// <summary>
    /// Method that clean skill panel if need
    /// </summary>
    private void CleanSkillChilds()
    {
        var skillList = GameObject.Find("SkillsList");
        for (int i = 0; i < skillList.transform.GetChildCount(); i++)
        {
            Destroy(skillList.transform.GetChild(i).gameObject);
        }
    }
}
