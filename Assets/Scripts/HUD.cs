using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    public GameObject heart, emptyHeart;
    public Transform[] heartSpawnPoints;
    GameObject heart1, heart2, heart3;
    public static int lifes = 4;

    static public bool isUpdated = true;

    // Use this for initialization
    void Start ()
    {
        heart1 = Instantiate(heart, heartSpawnPoints[0].position, heartSpawnPoints[0].rotation);
        heart2 = Instantiate(heart, heartSpawnPoints[1].position, heartSpawnPoints[1].rotation);
        heart3 = Instantiate(heart, heartSpawnPoints[2].position, heartSpawnPoints[2].rotation);
    }

    // Update is called once per frame
    void Update ()
    {
        if (lifes == 3 && isUpdated == false)
        {
            Destroy(heart1);
            heart1 = Instantiate(emptyHeart, heartSpawnPoints[0].position, heartSpawnPoints[0].rotation);
            isUpdated = true;
        }
        if (lifes == 2 && isUpdated == false)
        {
            Destroy(heart2);
            heart2 = Instantiate(emptyHeart, heartSpawnPoints[1].position, heartSpawnPoints[1].rotation);
            isUpdated = true;
        }
        if (lifes == 1 && isUpdated == false)
        {
            Destroy(heart3);
            heart3 = Instantiate(emptyHeart, heartSpawnPoints[2].position, heartSpawnPoints[2].rotation);
            isUpdated = true;
        }
        if (lifes == 0 && isUpdated == false)
        {
            SceneManager.LoadScene("GameOver");
            lifes = 4;
            Score.score = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            lifes = 4;
            Score.score = 0;
        }
    }
}
