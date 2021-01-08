public class PlayerController : Controller
{
    private void Awake()
    {
        _stats = GetComponent<Stats>();
        animator.SetBool("Death", false);
    }
}
