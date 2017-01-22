using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject enemyMissile;
    public GameObject enemyMonster;

    private float minXRange;
    private float maxXRange;

    private float minYRange;
    private float maxYRange;


    void Start()
    {
        InvokeRepeating("Spawner", 0.0f, 0.0f);
    }

    private void Spawner()
    {
        
    }

    private void SpawnMissiles()
    {
        
    }

    private void Spawn

}
