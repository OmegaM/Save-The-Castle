using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    private Stats _stats;
    private void Start()
    {
        GameObject.Destroy(this, 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _stats = GetComponent<Stats>();
            collision.gameObject.GetComponent<EnemyController>().GetDamage(_stats.Ability);
            GameObject.Destroy(this.gameObject);
        }
    }
}