using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadValues : MonoBehaviour
{
    private LeaderboardController leaderboardControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        leaderboardControllerScript = GameObject.Find("LeaderboardController").GetComponent<LeaderboardController>();
        leaderboardControllerScript.startGetScores("Geral");
    }

    public void loadLeaderboard(string level)
    {
        leaderboardControllerScript.startGetScores(level);
    }
}
