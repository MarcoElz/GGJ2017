using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject enemyMissile;
    public GameObject enemyMonster;

    public GameObject firstBg;
    public GameObject bossBG;
    public GameObject boss;

    private GameObject player;
    private const string TAG_PLAYER = "Player"; //Player Tag

    public static LevelManager instance;

    private float minXRange;
    private float maxXRange;

    private float minYRange;
    private float maxYRange;

    private int numberOfEnemies;
    private int numberOfPastWaves;

    private bool isStop;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        isStop = false;
        minXRange = 0;
        maxXRange = 15;
        minYRange = 0;
        maxYRange = 7;
        numberOfEnemies = 1;
        numberOfPastWaves = 0;

        player = GameObject.FindGameObjectWithTag(TAG_PLAYER);

        InvokeRepeating("Spawner", 5.0f, 6.0f);
    }

    private void Spawner()
    {
        if (isStop)
            return;
        
        numberOfPastWaves += 1;
   
        StartCoroutine(SpawnMissiles());
        StartCoroutine(SpawnEnemies());

        if (numberOfPastWaves == 4)
            numberOfEnemies = 2;
        //else if (numberOfPastWaves == 6)
        //    numberOfEnemies = 3;
    }

    IEnumerator SpawnMissiles()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(minXRange, maxXRange), 10, 0);
            Instantiate(enemyMissile, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPos = new Vector3(19, Random.Range(minYRange, maxYRange), 0);
            Instantiate(enemyMonster, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1.4f);
        }
    }

    public void BossFight()
    {
        StartCoroutine(BeginBoss());
    }

    public void Stop()
    {
        isStop = true;
    }

    public void Continue()
    {
        isStop = false;
    }

    IEnumerator BeginBoss()
    {
        UIManager.instance.blackScreen.GetComponent<Animator>().SetTrigger("BossIn");
        //numberOfEnemies = 3;
        yield return new WaitForSeconds(0.6f);
        firstBg.SetActive(false);
        bossBG.SetActive(true);
        boss.SetActive(true);

        //MovePlayer
        Vector3 newPos = new Vector3(7.0f, 5.5f, 0.0f);
        player.transform.position = newPos;
        UIManager.instance.blackScreen.GetComponent<Animator>().SetTrigger("FadeOutBoss");
        player.GetComponent<Submarine>().canTakeDamage = true;

        Stop();
        yield return new WaitForSeconds(3.0f);
        Continue();

        
    }



}
