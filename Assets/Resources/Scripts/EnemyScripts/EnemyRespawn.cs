using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    private GameObject[] _respanw;
    public GameObject enemy;
    private float _timer = 0.0f;

    private void Awake()
    {
        _respanw = GameObject.FindGameObjectsWithTag("enemy_respawn");
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        //Get Random respawn from array of respawnes
        var randomRespawn = _respanw[Random.Range(-1, _respanw.Length - 1) + 1];
        //Get current enemy count
        var enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        //Respawn enemy every 5s and if enemy count less then 10
        if (_timer % 60 >= 5 && enemyCount.Length <= 10)
        {
            Instantiate(enemy, new Vector2(randomRespawn.transform.position.x, randomRespawn.transform.position.y), Quaternion.identity);
            _timer = 0.0f;
        }
    }
}
