using UnityEngine;

public class Ability : MonoBehaviour
{
    public string abillityName;
    public float Range { get; set; }
    public float CoolDown;
    public float CDTimer;
    public float Damage { get; set; }
    public Enums.AttackTypes AttackType { get; set; }
    public MageAttackAttributes MageAttack { get; set; } = new MageAttackAttributes();
    public GameObject prefab;
    public bool IsActive = true;
    public bool CanBeUsed
    {
        get
        {
            return CDTimer <= Time.time;
        }
    }
    public void ResetCoolDownTimer()
    {
        CDTimer = Time.time + CoolDown;
    }
}
