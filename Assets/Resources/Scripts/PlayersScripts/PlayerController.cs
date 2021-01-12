using UnityEngine;

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
        
        animator.SetBool("Death", false);
    }
    private void Start()
    {
        _stats.Ability = new Ability
        {
            abillityName = "AutoAttack",
            AttackType = Enums.AttackTypes.Melee,
            Damage = playerAutoAttackDamage,
            CoolDown = playerAutoAttackCoolDown,
            CDTimer = playerAutoAttackCoolDown,
            Range = playerAutoAttackRange
        };
        Abilities.Add(new Ability
        {
            abillityName = "DarkSplash",
            AttackType = Enums.AttackTypes.Mage,
            Damage = 50,
            CoolDown = 1.0f,
            CDTimer = 1.0f,
            MageAttack = new MageAttackAttributes { Darkness = 10, Earth = 0, Fire = 0, Light = 0, Water = 0 },
            Range = 2,
            prefab = (GameObject)Resources.Load("Prefabs/dark_attack")
        }) ;
    }
    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            animator.SetBool("CanAttack", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            MakeDamage(_stats.Ability, collision.gameObject);
    }


}
