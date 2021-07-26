using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadiumManager : MonoBehaviour
{
    GameManager gameManager;
    Player Enemy;
    Player MyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        MyPlayer = gameManager.MyPlayer;
        Enemy = gameManager.match[MyPlayer.id];

        MyPlayer.addNewUnit();
        MyPlayer.addNewUnit();
        MyPlayer.addNewUnit();
        MyPlayer.addNewUnit();
        MyPlayer.addNewUnit();
        MyPlayer.addNewUnit();
        MyPlayer.addNewUnit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
