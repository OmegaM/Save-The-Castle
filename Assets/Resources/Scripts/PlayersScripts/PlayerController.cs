public class PlayerController : Controller
{
    public float playerHealth;
    public int playerMeleeDefense;
    public float playerAutoAttackDamage;
    public float playerAutoAttackRange;
    public float playerAutoAttackCoolDown;
    public UnityEngine.GameObject playerAutoAttackPrefab;

    private void Awake()
    {
        _stats = GetComponent<Stats>();
        animator.SetBool("Death", false);
        _stats.Health = playerHealth;
        _stats.MeleeDefense = playerMeleeDefense;
        _stats.Ability = new Ability
        {
           AttackType = Enums.AttackTypes.Melee,
           CDTimer = 0.0f,
           CoolDown = playerAutoAttackCoolDown,
           Damage  = playerAutoAttackDamage,
           Range = playerAutoAttackRange
        };
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
