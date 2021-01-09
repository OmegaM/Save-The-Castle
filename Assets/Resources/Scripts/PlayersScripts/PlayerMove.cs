using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private float xAxis;
    public Animator animator;

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        animator.SetFloat("WalkingSpeed",Math.Abs(xAxis));
        if (Input.GetButton("Jump"))
        {
            this.transform.Translate(Vector3.up * (jumpPower * Time.deltaTime));
        }
        if (xAxis < 0)
            this.transform.rotation = new Quaternion(0, 180, 0, 0);
        else if (xAxis > 0)
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.Translate(Vector2.right * Math.Abs(xAxis) * speed * Time.deltaTime);
    }
}
