using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> drop;
    public GameObject instantiatePos;
    public GameObject instantiatePos2;
    public float respawningTimer;
    private float time = 0;

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2;
    }

    void Update()
    {
        SpawnEnemies();
        ChangeVelocity();
        SpawnDrop();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnEnemies()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform);
            respawningTimer = UnityEngine.Random.Range(2, 6);
        }
    }
    private void SpawnDrop()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(drop[UnityEngine.Random.Range(0,drop.Count)], instantiatePos2.transform);
            respawningTimer = UnityEngine.Random.Range(2, 6);
        }
    }
}
