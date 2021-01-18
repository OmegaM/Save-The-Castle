    using UnityEngine;
    using System;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public Vector3 _target;
    private bool IsMoving = false;
    private bool IsTargetVisible = true;
    public GameObject targetPoint;
    private GameObject _targetPointInstance;

    private void Start()
    { 
        _target = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void Update()
    {
        //If target point is in the world
        if (_targetPointInstance != null)
        {
            //Get point of current player 
            IsTargetVisible = _targetPointInstance.GetComponent<PointScript>().targetOfPlayer == this.gameObject;
            _targetPointInstance.GetComponentInChildren<SpriteRenderer>().enabled = IsTargetVisible;
        }
        Move();
        //If player reached point
        if (this.transform.position.x == _target.x)
        {
            if (_targetPointInstance != null)
                GameObject.Destroy(_targetPointInstance.gameObject);
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
    /// <summary>
    /// Player moving and rotation method
    /// </summary>
    private void Move()
    {
        var euler = _target - this.transform.position;
        var rotation = Quaternion.Euler(0,90,0) * -euler;
        var targetRotation = Quaternion.LookRotation(rotation);
        targetRotation.x = 0;
        this.transform.rotation = targetRotation;
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector2(_target.x, this.transform.position.y), speed * Time.deltaTime);
    }
    /// <summary>
    /// When clicking on the screen
    /// add target to go
    /// and put point of target
    /// </summary>
    private void SetNewTarget()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        var result = _target;
        result.x = mousePos.x;
        result.y = this.transform.position.y;
        _target = result;
        if (_targetPointInstance != null)
            GameObject.Destroy(_targetPointInstance.gameObject);
        _targetPointInstance = Instantiate(targetPoint, _target, Quaternion.identity);
    }
}
