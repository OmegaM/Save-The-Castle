using UnityEngine;
using UnityEngine.Sprites;

public class CastleController : Controller
{
    public int _level;
    public float _rangeOfView = 2;
    private GameObject _target = null;
    private GameObject[] _enemyArray;
    public GameObject healthBarObject;

    void Awake()
    {
        _stats = GetComponent<Stats>();
        healthBar = healthBarObject.GetComponentInChildren<UnityEngine.UI.Slider>();
        _stats.MaxHealth = _level * 100;
        _stats.Health = _stats.MaxHealth;
        healthBar.maxValue = _stats.MaxHealth;
        healthBar.value = _stats.Health;
    }
    void Start()
    {
        _stats = this.GetComponent<Stats>();
        _stats.Ability = new Ability{ 
            AttackType = Enums.AttackTypes.Range, 
            Range = 2,
            CoolDown = 1,
            MageAttack = new MageAttackAttributes() 
            { 
                Darkness = 0,
                Earth = 0,
                Fire = 0,
                Light = 0,
                Water = 0
            }, 
            Damage = 10,
            prefab = (GameObject)Resources.Load("Prefabs/RangeShot")
        };
    }
    void Update()
    {
        _enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in _enemyArray)
        {
            if (Vector2.Distance(enemy.transform.position, this.transform.position) <= _rangeOfView)
            {
                _target = enemy;
                break;
            }
        }
    }
    private void FixedUpdate()
    {
        if (_target != null && _stats.Ability.CanBeUsed)
        {
            var emb = GameObject.Find("Embrasure");
            var arrow = Instantiate<GameObject>(_stats.Ability.prefab, new Vector2(emb.transform.position.x, emb.transform.position.y) ,new Quaternion(0,0,_target.transform.position.x < 0 ? 180 : 0,0));
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(_target.transform.position.x, emb.transform.position.y + 2) * 50.0f * Time.deltaTime;
            arrow.GetComponent<Stats>().Ability = _stats.Ability;
        }
    }
}
