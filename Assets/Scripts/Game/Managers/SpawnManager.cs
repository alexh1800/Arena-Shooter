using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int enemyMultiplier = 2;

    [SerializeField] GameplayManager gameplayManager;
    [SerializeField] GameObject enemyPrefab;


    // Update is called once per frame
    void Update()
    {
        enemyManager();
    }

    void enemyManager()
    {   // get number of enemies that should be spawned based on level
        int enemyGoal = gameplayManager.Level * enemyMultiplier;
        //print($"Enemy Goal: {enemyGoal}");

        // get the number of enemies currently active
        // note think about adding a dedicated enemy manager later for better performance
        int numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //print($"Number of enemies: {numberOfEnemies}");

        // if there aren't enough enemies active, spawn one (within bounds of arena)
        if (enemyGoal > numberOfEnemies)
        {
            //print("spawn enemy");
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        //Spawn an enemy
        GameObject newEnemyObject = Instantiate(enemyPrefab, getSpawnLocation(), enemyPrefab.transform.rotation);
        
        //Not sure if I want to add spawn modifications here or in enemy script, will do later
        //Get the New Enemy Script
        //Enemy newEnemy = newEnemyObject.GetComponent<Enemy>();


    
    }

    Vector3 getSpawnLocation()
    {
        float arenaSize = gameplayManager.ArenaSize;
        float randomX = Random.Range(-arenaSize, arenaSize);
        float randomZ = Random.Range(-arenaSize, arenaSize);

        return new Vector3(randomX, 1, randomZ);

    }

}
