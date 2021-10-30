using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiater : MonoBehaviour
{
    [SerializeField] GameObject copter,smallship, coin, ufo, powerUp, health, shield, enemyPlane, fighterJet;

    public float copterTime, shipTime, coinTime, ufoTime, powerupTime, healthTime, ShieldTime, planeTime, jetTime;

    Vector3 spawnPos0, spawnPos1, spawnPos2, spawnPos3, spawnPos4, spawnPos5, spawnPos6, spawnPos7, spawnPos8;

    public bool enableEnemyPlane, enableFighterJet;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCopter", copterTime, copterTime);
        InvokeRepeating("SpawnSmallship", shipTime, shipTime);
        InvokeRepeating("SpawnCoin", coinTime, coinTime);
        InvokeRepeating("SpawnUFO", ufoTime, ufoTime);
        InvokeRepeating("SpawnPowerUp", 20f, powerupTime);
        InvokeRepeating("SpawnHealth", healthTime, healthTime);
        InvokeRepeating("SpawnShield", ShieldTime, ShieldTime);

        if (enableEnemyPlane)
        {
            InvokeRepeating("SpawnEnemyPlane", planeTime, planeTime);
        }

        if (enableFighterJet)
        {
            InvokeRepeating("SpawnEnemyJet", jetTime, jetTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnPos0 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
        spawnPos1 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
        spawnPos2 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
        spawnPos3 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
        spawnPos4 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
        spawnPos5 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
        spawnPos6 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
        spawnPos7 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
        spawnPos8 = new Vector3(Random.Range(-8, 8), Random.Range(6, 11), 0);
    }

    public void SpawnCopter()
    {
        Instantiate(copter, spawnPos0, Quaternion.identity);
    }

    public void SpawnSmallship()
    {
        Instantiate(smallship, spawnPos1, Quaternion.identity);
    }

    public void SpawnCoin()
    {
        Instantiate(coin, spawnPos2, Quaternion.identity);
    }

    public void SpawnUFO()
    {
        Instantiate(ufo, spawnPos3, Quaternion.identity);
    }

    public void SpawnPowerUp()
    {
        Instantiate(powerUp, spawnPos4, Quaternion.identity);
    }

    public void SpawnHealth()
    {
        Instantiate(health, spawnPos5, Quaternion.identity);
    }

    public void SpawnShield()
    {
        Instantiate(shield, spawnPos6, Quaternion.identity);
    }

    public void SpawnEnemyPlane()
    {
        Instantiate(enemyPlane, spawnPos7, Quaternion.identity);
    }

    public void SpawnEnemyJet()
    {
        Instantiate(fighterJet, spawnPos8, Quaternion.identity);
    }
}
