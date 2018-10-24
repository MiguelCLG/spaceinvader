using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 0.1f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public GameObject gs;
    private HUD hud;
    public GameObject wave;
    private int spawnPointIndex = 0;
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        gs = GameObject.FindGameObjectWithTag("game-system");
        hud = FindObjectOfType<HUD>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }


    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        if (hud.spawning == 1)
        {
            GameObject clone = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
            wave = GameObject.FindGameObjectWithTag("wave");
            clone.transform.parent = wave.transform;
            if (spawnPointIndex >= hud.numEnemies-1)
            {
                hud.spawning = 0;
            }
            else
            {
                hud.spawning = 1;
            }
            spawnPointIndex += 1;
        }
        else {
            spawnPointIndex = 0;
        }
        hud.initialSpawn = false;
    }
}