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
        this.transform.rotation = xAxis < 0 ? new Quaternion(0, 180, 0, 0) : new Quaternion(0,0,0,0);
        this.transform.Translate(Vector2.right * Math.Abs(xAxis) * speed * Time.deltaTime);
    }
}
