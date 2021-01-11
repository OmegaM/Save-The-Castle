using UnityEngine;

public class Ability : MonoBehaviour
{
    public float Range { get; set; }
    public float CoolDown = 1.0f;
    public float CDTimer = 0.0f;
    public float Damage { get; set; }
    public Enums.AttackTypes AttackType { get; set; }
    public MageAttackAttributes MageAttack { get; set; } = new MageAttackAttributes();
    public GameObject prefab;
    public bool CanBeUsed
    {
        get
        {
            return CDTimer >= CoolDown;
        }
    }
    

    private void Start()
    {
        InvokeRepeating("AbillityCDUpdate", 0.0f, 1.0f);
    }

    private void AbillityCDUpdate()
    {
        CDTimer += 1.0f;
    }
}
