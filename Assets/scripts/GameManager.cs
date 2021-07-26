using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabPlayer;

    public const int NUM_PLAYERS = 5;
    public static GameManager instance;
    private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();
    private Player _MyPlayer;
    public Player MyPlayer {
        get { return _MyPlayer; }
    }
    private int _alivePlayers = NUM_PLAYERS;
    public int alivePlayers {
        get { return _alivePlayers; }
    }
    private int round = 1;
    public Dictionary<string, Player> match = new Dictionary<string, Player>();

    void Awake(){
        instance = this;

        string[] ids = {"E", "D", "C", "B", "A"};
        foreach(string id in ids){
            GameObject player = Instantiate(prefabPlayer);
            player.GetComponent<Player>().id = id;
            players.Add(id, player);
        }

        _MyPlayer = players["A"].GetComponent<Player>();
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
        return players[id].GetComponent<Player>();
    }

    public List<Player> GetPlayers(){
        List<Player> list = new List<Player>();

        foreach(GameObject p in players.Values){
            list.Add(p.GetComponent<Player>());
        }
        return list;
    }

    public void decreaseAlivePlayers(){
        _alivePlayers -= 1;
    }
}
