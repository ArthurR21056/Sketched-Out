using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Controls the background functions of the game that the player cannot control
public class WaveSpawner : MonoBehaviour  {
    [Tooltip("Enemy will begin to appear in round 1")]
    public Transform enemy1;

    [Tooltip("Enemy will begin to appear in round 5")]
    public Transform enemy2;

    [Tooltip("Enemy will begin to appear in round 10")]
    public Transform enemy3;

    [Tooltip("Enemy will begin to appear in round 15")]
    public Transform enemy4;
    
    [Tooltip("The Starting score the player will start with.")]
    public static int totalScore;
	
    [Tooltip("Text Object To display score")]
    public Text scoreText;

    [Tooltip("Text Object To display Round")]
    public Text roundStatus;

    [Tooltip("A buffer so enemies don't spawn every frame")]
    public float countdown;
    [Tooltip("Text object for round")]
    public Text round;

    private int spawnEnemies;           //The default amount of enemies spawned
    private int spawnLocation;          //Random number to select which spawn point to spawn enemy
    static public int waveNumber;       //The current round 
	static public int numberOfEnemies;  //A static variable of the amount of enemies currently in the game
    public GameObject[] spawnPoints;    //Spawn points for the enemies

    public Material sky1;
    
    // Gets the current round
    public int getWaveNumber()
    {
        return waveNumber;
    }
    /*
     * Adds score the the current in game score
     * @param score- the points to be added to score
    */
    public void AddScore(int score)
    {
        totalScore += score;
    }
    //
    void Start()
    {
        totalScore = 500;
        countdown = 3;
        waveNumber = 0;
        numberOfEnemies = 0;
        spawnEnemies = 5;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        RenderSettings.skybox = sky1;
    }
    //Controls the rounds in the game
    void Update ()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if ( numberOfEnemies <= 0)
        {
            countdown -= .2f;

            waveNumber++;
            StartCoroutine(SpawnWave());
        }

    }
    //Controls the spawn of enemies
    IEnumerator SpawnWave()
    {

        for(int i= 0; i < spawnEnemies * waveNumber; i++) {
            int j = Random.Range(0, 2);
            if( j == 0)
                SpawnEnemy(enemy1);
            if(j == 1)
                SpawnEnemy(enemy2);
            numberOfEnemies++;

            yield return new WaitForSeconds(countdown);
        }
        yield return new WaitForSeconds(5f);
        
    }
	/*
     * Spawns an enemy
     * @param enemy - The enemy to be spawned 
     */
    void SpawnEnemy(Transform enemy)
	{
        spawnLocation = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnLocation].transform.position, spawnPoints[spawnLocation].transform.rotation);

    }
}
