using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchingManager : MonoBehaviour
{
    private GameManager gameManager;
    private Dictionary<string, Player> histories = new Dictionary<string, Player>();
    private Queue<Player> walkoverQueue = new Queue<Player>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        foreach(Player p in gameManager.GetPlayers()){
            walkoverQueue.Enqueue(p);
        }
        StartCoroutine(DelayTime(5));
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("GameScene");
    }

    public string getMatchingTable(){
        string result = "";
        // 1. 가장 부전승 조금 한사람 부전승으로 선택 if 남아있는 Player 수 == 홀수
        // 2. 전체 플레이어들의 현재 HP를 기준으로 비슷한 hp끼리 매칭
        // 3. 직전에 만난사람 거르기

        List<Player> players = new List<Player>();

        foreach(Player player in gameManager.GetPlayers()){
            if(player.isAlive()){
                players.Add(player);
            }
        }

        players.Sort((p1, p2) => p1.hp.CompareTo(p2.hp));

        if(gameManager.alivePlayers % 2 == 1){
            // #1 - 부전승
            // 살아있는 플레이어가 홀수 일때만 부전승 있음
            Player walkoverPlayer = walkoverQueue.Dequeue();

            while(!walkoverPlayer.isAlive()){
                //이미 죽은 플레이어면 다시 뽑기
                walkoverPlayer = walkoverQueue.Dequeue();
            }

            result += "부전승 : " + walkoverPlayer.id + " ";
            walkoverQueue.Enqueue(walkoverPlayer);
            
            players.Remove(walkoverPlayer);
        }

        result += "/";

        Stack<Player> playerStack = new Stack<Player>(players);
        
        // playerStack.Count : 짝수임이 보장됨
        while(playerStack.Count > 1){
            Player p1 = playerStack.Pop();
            Player p2 = playerStack.Pop();

            // #3 - 직전에 만난사람 필터링
            if(histories.ContainsKey(p1.id) && histories[p1.id].Equals(p2)){
                if(playerStack.Count > 0){
                    Player temp = p2;
                    p2 = playerStack.Pop();
                    playerStack.Push(temp);
                }
            }
            
            //히스토리 갱신
            histories[p1.id] = p2;
            histories[p2.id] = p1;

            result += p1.id + "-" + p2.id + ", ";
        }
        
        return result + "\n";
    }
}
