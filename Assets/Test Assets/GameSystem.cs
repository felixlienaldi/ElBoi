using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameSystem  {
    public static GameSystem current;
    public int currentChekcpoint;
    public int currentlevel = 1;
    public bool gameStart;
    public static bool gameContinue = false;

    public GameSystem() {
        current = this;
        gameStart = true;
        gameContinue = false;

        currentChekcpoint = -1;
        currentlevel = 1;
    }
}
