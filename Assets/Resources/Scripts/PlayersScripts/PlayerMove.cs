using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    Transform trans;
    private float xAxis;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
        {
            trans.Translate(Vector3.up * (jumpPower * Time.deltaTime));
        }
        trans.Translate(Vector3.right * (xAxis * speed * Time.deltaTime));
    }
}
