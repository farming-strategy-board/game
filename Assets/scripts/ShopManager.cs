using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Types;

public class ShopManager : MonoBehaviour
{
    private Player player;
    private GameManager gameManager;
    void Start()
    {
        this.gameManager = GameManager.instance;
        player = GameObject.Find("Player1").GetComponent<Player>();
    }

    void Update()
    {
        
    }

    public void buy(){
        player.purchaseUnit();
        GameObject.Find("MyUnits").GetComponent<Text>().text = player.getUnitsListString();
    }
}
