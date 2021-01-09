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
    private Stats _stats;
    void Awake()
    {
        _mainTarget = GameObject.FindGameObjectWithTag("Castle");
        _controller = GetComponent<EnemyController>();
        _stats = GetComponent<Stats>();
    }
    private void Start()
    {
        if (this.transform.position.x > 0)
            this.transform.rotation = new Quaternion(0, 90, 0, 0);
    }
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Player");
        if (!_controller.animator.GetBool("Death") && Vector2.Distance(this.transform.position, enemy.transform.position) != (_stats.Ability == null ? 0 : _stats.Ability.Range))
        {
            isInRangeOfView = Vector3.Distance(enemy.transform.position, this.transform.position) <= rangeOfView;
            if (isInRangeOfView)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, enemy.transform.position, speed * Time.deltaTime);
                this.transform.rotation = enemy.transform.position.x < this.transform.position.x ? new Quaternion(0, 90, 0, 0) : new Quaternion(0, 0, 0, 0);
            }
            else
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, _mainTarget.transform.position, speed * Time.deltaTime);
                this.transform.rotation = this.transform.position.x > 0 ? new Quaternion(0, 90, 0, 0) : new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
