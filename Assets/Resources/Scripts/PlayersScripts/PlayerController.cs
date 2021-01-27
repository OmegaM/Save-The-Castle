using UnityEngine;

public class PlayerController : Controller
{
    public float playerHealth;
    public int playerMeleeDefense;
    public float playerAutoAttackDamage;
    public float playerAutoAttackRange;
    public float playerAutoAttackCoolDown;
    public GameObject playerAutoAttackPrefab;
    public GameObject healthBarObject;
    public SkillTree skills;
    public Enums.CharacterType characterType;
    private void Awake()
    {
        healthBar = healthBarObject.GetComponentInChildren<UnityEngine.UI.Slider>();
        _stats = GetComponent<Stats>();
        _stats.MaxHealth = playerHealth;
        _stats.Health = _stats.MaxHealth;
        healthBar.maxValue = _stats.MaxHealth;
        healthBar.value = _stats.Health;
        _stats.MeleeDefense = playerMeleeDefense;

        switch (characterType)
        {
            case Enums.CharacterType.Warrior:
                skills = new WarriorSkillTree();
                break;
            case Enums.CharacterType.Mage:
                skills = new MageSkillTree();
                break;
            case Enums.CharacterType.Ranger:
                skills = new RangerSkillTree();
                break;
            default:
                break;
        }

        animator.SetBool("Death", false);
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            animator.SetBool("CanAttack", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.transform.rotation = collision.transform.position.x <= this.transform.position.x ? new Quaternion(0, 180, 0, 0) : new Quaternion(0, 0, 0, 0);
            MakeDamage(_stats.Ability, collision.gameObject);
        }
    }


}
