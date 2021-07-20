using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int NUM_PLAYERS = 5;
    public static GameManager instance;
    private Dictionary<string, Player> players = new Dictionary<string, Player>();
    private Player _MyPlayer;
    public Player MyPlayer {
        get { return _MyPlayer; }
    }
    private int _alivePlayers = NUM_PLAYERS;
    public int alivePlayers {
        get { return _alivePlayers; }
    }
    private int round = 1;

    void Awake(){
        instance = this;
        players.Add(GameObject.Find("Player5").GetComponent<Player>().id,
                    GameObject.Find("Player5").GetComponent<Player>());

        players.Add(GameObject.Find("Player4").GetComponent<Player>().id,
                    GameObject.Find("Player4").GetComponent<Player>());

        players.Add(GameObject.Find("Player3").GetComponent<Player>().id,
                    GameObject.Find("Player3").GetComponent<Player>());

        players.Add(GameObject.Find("Player2").GetComponent<Player>().id,
                    GameObject.Find("Player2").GetComponent<Player>());

        players.Add(GameObject.Find("Player1").GetComponent<Player>().id,
                    GameObject.Find("Player1").GetComponent<Player>());

        _MyPlayer = players["A"];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Player getPlayerByID(string id){
        return players[id];
    }

    public List<Player> GetPlayers(){
        return new List<Player>(players.Values);
    }

    public void decreaseAlivePlayers(){
        _alivePlayers -= 1;
    }
}
