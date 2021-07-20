using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchSceneTest : MonoBehaviour
{
    private GameManager gameManager;
    private MatchingManager matchingManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        matchingManager = GameObject.Find("MatchingManager").GetComponent<MatchingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void simulate(){
        string matchTable = matchingManager.getMatchingTable();
        Text output = GameObject.Find("MatchResultText").GetComponent<Text>();
        output.text += matchTable;

        string[] p = matchTable.Split('/');
        string[] battles = p[1].Split(','); // battles : {"A-B", "C-D"}
        
        foreach(string battle in battles){
            string[] ids = battle.Split('-');
            if(ids.Length == 1){
                break;
            }

            Player[] players = new Player[2];
            players[0] = gameManager.getPlayerByID(ids[0].Trim());
            players[1] = gameManager.getPlayerByID(ids[1].Trim());

            int winner = Random.Range(0,2);
            int loser = 1 - winner;

            int dmg = Random.Range(30, 101);
            players[loser].decreaseHp(dmg);
            
            output.text += string.Format("{0}가 {1}를 이기고 {2}데미지를 주었습니다.\n", players[winner].id, players[loser].id, dmg);

            if(!players[loser].isAlive()){
                output.text += players[loser].id + "가 죽었습니다. \n";
            }
        }
        output.text += "\n";

        Text status = GameObject.Find("StatusText").GetComponent<Text>();
        status.text = "";
        foreach(Player player in gameManager.GetPlayers()){
            status.text += player.id + "'s HP : " + player.hp + "\n";
        }
    }
}
