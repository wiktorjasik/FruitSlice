using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitSpawner : MonoBehaviour {

    public GameObject[] fruitPrefabs;
    public Transform[] spawnPoints;

    public AudioClip fruitSound;
    public AudioSource audioSource;
    static public AudioSource player;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(SpawnFruits());
        player = audioSource;
        player.clip = fruitSound;        
    }
	
	IEnumerator SpawnFruits()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            CreateFruit();            
        }
    }

    void CreateFruit()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        int fruitIndex = Random.Range(0, fruitPrefabs.Length);

        GameObject spawnFruit = Instantiate(fruitPrefabs[fruitIndex], spawnPoint.position, spawnPoint.rotation);

        Destroy(spawnFruit, 3f);
    }
}
