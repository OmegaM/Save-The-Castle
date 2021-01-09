public class PlayerController : Controller
{
    public float playerHealth;
    public int playerMeleeDefense;
    public float playerAutoAttackDamage;
    public float playerAutoAttackRange;
    public float playerAutoAttackCoolDown;
    public UnityEngine.GameObject playerAutoAttackPrefab;
    public UnityEngine.GameObject healthBarObject;
    private void Awake()
    {
        healthBar = healthBarObject.GetComponentInChildren<UnityEngine.UI.Slider>();
        _stats = GetComponent<Stats>();
        _stats.MaxHealth = playerHealth;
        _stats.Health = _stats.MaxHealth;
        healthBar.maxValue = _stats.MaxHealth;
        healthBar.value = _stats.Health;
        _stats.MeleeDefense = playerMeleeDefense;
        _stats.Ability = new Ability
        {
           AttackType = Enums.AttackTypes.Melee,
           CDTimer = 0.0f,
           CoolDown = playerAutoAttackCoolDown,
           Damage  = playerAutoAttackDamage,
           Range = playerAutoAttackRange
        };
        animator.SetBool("Death", false);
    }
    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            animator.SetBool("CanAttack", false);
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            MakeDamage(_stats.Ability, collision.gameObject);
    }


}
