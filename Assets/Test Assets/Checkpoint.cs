using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour {
    public int checkpointID;
    // Use this for initialization 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerArea") {
            Debug.Log("a");
            SaveLoad.savedgame.currentChekcpoint = checkpointID;
            SaveLoad.savedgame.currentlevel = SceneManager.GetActiveScene().buildIndex;
            SaveLoad.Overwrite();
          
        }
    }
    public void SpawnPlayerAtCheckpoint(GameObject player)
    {

        player.transform.position = this.gameObject.transform.position;

    }

}
