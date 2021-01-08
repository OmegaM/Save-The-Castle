public class PlayerController : Controller
{
    public float playerHealth;
    public int playerMeleeDefense;
    private void Awake()
    {
        _stats = GetComponent<Stats>();
        animator.SetBool("Death", false);
        _stats.Health = playerHealth;
        _stats.MeleeDefense = playerMeleeDefense;
    }
}
