using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float timeBetweenEnemies = 2f;
    public float timeBetweenWaves = 5f;

    private float countDown = 2f;

    private int index;

    public int[] Waves;

    public Text waveCountdownText;


    public Transform enemyHolder;

    private int waveIndex = 0; 
    private int enemyCount = 0;

    public GameManager gameManager;

    private Enemy enemyClass;

    private int enemiesAlive = 0;




    // Start is called before the first frame update
    void Start()
    {
        index = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (waveIndex == Waves.Length && enemiesAlive <= 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countDown <= 0)
        {

            /*StartCoroutine("SpawnWaveCoroutine");
            countDown = timeBetweenWaves;*/
            if (index < Waves.Length)
            {
                StartCoroutine("SpawnWaveCoroutine");
                countDown = timeBetweenWaves;
            }
        }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWaveCoroutine()
    {
        for (int i = 0; i < Waves[index]; i++)
        {
           
            SpawnEnemy();
            yield return new WaitForSeconds(1f /timeBetweenEnemies);
            
        }
        index++;
        waveIndex++;

    }

    public void SpawnEnemy()
    {
        //Instanciar al Enemy
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, Waypoints.route_0[0].position, Waypoints.route_0[0].rotation, enemyHolder);
        enemiesAlive++;
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.OnEnemyDestroyed += OnEnemyDestroyed;
    }

    public void OnEnemyDestroyed()
    {
        enemiesAlive--;
    }

}
