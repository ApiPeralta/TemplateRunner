using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject drop;
    public GameObject fuel;
    public GameObject instantiatePos;
    public GameObject instantiatePos2;
    public float respawningTimer;
    public float respawningTimer1;
    public float respawningTimer2;
    private float time = 0;

    void Start()
    {
        respawningTimer2 = 3;
        respawningTimer1 = 5;
        Controller_Enemy.enemyVelocity = 2;
    }

    void Update()
    {
        SpawnEnemies();
        ChangeVelocity();
        SpawnDrop();
        SpawnFuel();
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
            respawningTimer = UnityEngine.Random.Range(3, 6);
        }
    }
    private void SpawnDrop()
    {
        respawningTimer1 -= Time.deltaTime;

        if (respawningTimer1 <= 0)
        {
            Instantiate(drop, instantiatePos2.transform);
            respawningTimer1 = UnityEngine.Random.Range(8, 10);
        }
    }
    private void SpawnFuel()
    {
        respawningTimer2 -= Time.deltaTime;

        if (respawningTimer2 <= 0)
        {
            Instantiate(fuel, instantiatePos2.transform);
            respawningTimer2 = UnityEngine.Random.Range(3, 5);
        }
    }
}
