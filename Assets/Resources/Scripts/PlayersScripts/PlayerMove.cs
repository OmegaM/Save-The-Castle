    using UnityEngine;
    using System;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private float xAxis;
    public Animator animator;
    public Vector3 _target;
    private bool IsMoving = false;

    private void Start()
    { 
        _target = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void Update()
    {
        Move();
        if (this.transform.position.x == _target.x)
        {
            animator.SetBool("IsWalking", IsMoving);
            IsMoving = false;
        }
        if (Input.GetMouseButtonDown(0) && Camera.main.GetComponent<MainCamera>().currentPlayer == this.gameObject)
        {
            SetNewTarget();
            IsMoving = true;
            animator.SetBool("IsWalking", IsMoving);
        }
    }

    private void Move()
    {
        var euler = _target - this.transform.position;
        var rotation = Quaternion.Euler(0,90,0) * -euler;
        var targetRotation = Quaternion.LookRotation(rotation);
        targetRotation.x = 0;
        this.transform.rotation = targetRotation;//Quaternion.RotateTowards(this.transform.rotation, targetRotation, speed * Time.deltaTime);
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector2(_target.x, this.transform.position.y), speed * Time.deltaTime);
    }
    private void SetNewTarget()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        var result = _target;
        result.x = mousePos.x;
        result.y = this.transform.position.y;
        _target = result;
       
    }
}
