using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int Coins, lastSavePoint;

    public int playerLives = 3;
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            Coins = 0;
        }else{
            Destroy(gameObject);
        }
    }
}
