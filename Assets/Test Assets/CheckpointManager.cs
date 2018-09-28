using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;
    public List<Checkpoint> checkpoints = new List<Checkpoint>();
    BoiMovement boi;
    public GameObject player;
    public GameObject deathmanager;
    public HeartSystem heart;
    public int j = 0;
    public DeathManager death;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        j = 0;
        GameSystem.current = SaveLoad.savedgame;
      
        boi = FindObjectOfType<BoiMovement>();

        if (GameSystem.current.gameStart) {
            SaveLoad.savedgame.currentChekcpoint = j;
        }

        

    
       

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SaveLoad.savedgame.currentChekcpoint);
    }

    public void spawn() {
        Debug.Log(SaveLoad.savedgame.currentChekcpoint);
        if (SaveLoad.savedgame.currentChekcpoint==0)
        {
            death.RestartGame(1);        
        }
        else
        {
            heart.currHealth = 6;
            heart.updateHearts();
            checkpoints[SaveLoad.savedgame.currentChekcpoint-1].SpawnPlayerAtCheckpoint(player);
            deathmanager.SetActive(false);
        }
    }


}