using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBpoint : MonoBehaviour
{
    int game;

    public void dataGame()
    {
        game = FindAnyObjectByType<AppControl>().balance;
        PlayerPrefs.SetInt("DBControl", game);
        //print("game-->"+  game);
    }
}
