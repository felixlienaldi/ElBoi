using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathManager : MonoBehaviour {
    public GameObject boi_sprite;
    public Vector3 playerStartPoint;
    public ElementChange el;
    public GameObject[] all;
    public GameObject allSign;
    public GameObject deathMenu;
    public GameObject camera;
    public GameObject vicmenu;
    public bool level1;
    public bool level2;
	// Use this for initialization
	void Start () {
        playerStartPoint = boi_sprite.transform.position;
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death()
    {
        deathMenu.SetActive(true);
     
    }

    public void Victory()
    {
        vicmenu.SetActive(true);
    }
    

    public void RestartGame(int index)
    {
        /*el.elementNum = 0;
        allSign.SetActive(true);
        boi_sprite.transform.position = playerStartPoint;
        for (int i = 0; i < all.Length; i++)
        {
            all[i].SetActive(true);
        }
        deathMenu.SetActive(false);
        camera.transform.position = new Vector3(0f,3.83f,-10f);*/
        SceneManager.LoadScene(index);
    }

    public void exit()
    {
        Application.Quit();
    }
	public void Continue(int indexi){
		 SceneManager.LoadScene(indexi);
	}
    
  
}
