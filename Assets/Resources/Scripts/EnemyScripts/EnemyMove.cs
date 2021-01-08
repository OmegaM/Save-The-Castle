using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    public GameObject enemy;
    public float rangeOfView = 1.0f;
    public float speed = 2.0f;
    public bool isInRangeOfView;
    private GameObject _mainTarget;
    private EnemyController _controller;
    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Player");
        _mainTarget = GameObject.FindGameObjectWithTag("main_target");
        _controller = GetComponent<EnemyController>();
    }
    private void Start()
    {
        if (this.transform.position.x > 0)
            this.transform.rotation = new Quaternion(0, 90, 0, 0);
    }
    void Update()
    {
        if (!_controller.animator.GetBool("Death"))
        {
            isInRangeOfView = Vector3.Distance(enemy.transform.position, transform.position) <= rangeOfView;
            if (isInRangeOfView)
                transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position, _mainTarget.transform.position, speed * Time.deltaTime);
        }
    }
}
