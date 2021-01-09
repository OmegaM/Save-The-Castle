using UnityEngine;
/// <summary>
/// Use this class, like a pattern
/// And add to all objects, that cant be manipulated
/// </summary>
public class Stats : MonoBehaviour, IStats
{
    public int Level { get; set; }
    public Ability Ability { get; set; }
    public float MaxHealth { get; set; }
    public float Health { get; set; }
    public int MeleeDefense { get ; set ; }
    public float Experience { get ; set ; }
    public MageDefenseAttributes MageDefense { get ; set; }
}

