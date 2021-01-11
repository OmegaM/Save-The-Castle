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
        var playerSkills = currentPlayer.GetComponent<PlayerController>().Abilities;
        for (var i = 0; i < playerSkills.Count; i++)
        {
            var skill = playerSkills[i];
            var btn = Instantiate(skillButton, new Vector2((skillList.transform.position.x + (((RectTransform)skillButton.transform).rect.width) * i), skillList.transform.position.y), Quaternion.identity);
            btn.transform.SetParent(skillList.transform);
            btn.image.sprite = skill.prefab.GetComponent<SpriteRenderer>().sprite;
            btn.onClick.AddListener(() => UseSkill(skill));
        }
        _drownedPlayer = currentPlayer;
    }
    public void UseSkill(Ability skill)
    {
        if (!skill.CanBeUsed)
            return;
        var attackPlace = currentPlayer.transform.Find("AttackArea");
        var tmp = Instantiate(skill.prefab, new Vector2(attackPlace.transform.position.x, attackPlace.transform.position.y), Quaternion.identity);
        tmp.GetComponent<Stats>().Ability = skill;
        tmp.GetComponent<Rigidbody2D>().velocity = new Vector2(this.transform.position.x, this.transform.position.y) * 50.0f * Time.deltaTime;
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
