using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    private GameObject youWin;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        youWin = GameObject.FindGameObjectWithTag("You Win");
        youWin.SetActive(false);
        player = GameObject.Find("Player Ship");
    }

    // Update is called once per frame
    void Update()
    {
        int numTurrets = GameObject.FindGameObjectsWithTag("Turret").Length + GameObject.FindGameObjectsWithTag("Double Turret").Length;
        int numRockets = GameObject.FindGameObjectsWithTag("Rocket").Length;
        int numEnemies = GameObject.FindGameObjectsWithTag("Enemy Ship").Length;
        int numSpawners = GameObject.FindGameObjectsWithTag("Spawner").Length;
        int numGenerators = GameObject.FindGameObjectsWithTag("Generator").Length;

        if (numTurrets == 0 && numRockets == 0 && numEnemies == 0 && numSpawners == 0 && numGenerators == 0) {
            AudioListener.pause = true;
            youWin.SetActive(true);
            player.SetActive(false);
        }
    }
}
