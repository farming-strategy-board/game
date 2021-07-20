using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public string id;
    private int _hp = 100;
    public int hp { 
        get { return _hp; }
    }
    private int money;
    private List<Unit> units = new List<Unit>();
    private int aliveUnits;

    void Start()
    {
        units.Add(GameObject.Find("infantryUnit").GetComponent<InfantryUnit>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isAlive(){
        return _hp > 0;
    }

    public void decreaseHp(int dmg){
        if(dmg < 0){
            throw new System.Exception("음수 데미지를 가할 수 없습니다.");
        }
        _hp -= dmg;
        if(!isAlive()){
            GameManager.instance.decreaseAlivePlayers();
        }
    }

    public void increaseHp(int amount){
        if(amount < 0){
            throw new System.Exception("음수값으로 힐링할 수 없습니다.");
        }
        _hp += amount;
    }

    public void purchaseUnit(){
        GameObject newUnit = Instantiate(GameObject.Find("infantryUnit"));
        units.Add(newUnit.GetComponent<InfantryUnit>());
    }

    public string getUnitsListString(){
        string result = "";
        foreach(Unit u in units){
            result += u.getName() + "\n";
        }
        return result + "\n";
    }
}