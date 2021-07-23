using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class InfantryUnit : MonoBehaviour, Unit
{
    private int _hp = 100;
    public int hp {
        get { return _hp; }
    }
    private int attack;
    private int speed;
    private int x, y;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void go(){

    }

    public bool isAlive(){
        return _hp > 0;
    }

    public void setPosition(int x, int y){
        this.x = x;
        this.y = y;
    }

    public string getName(){
        Debug.Log(this.name);
        return this.name;
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
}

namespace Types{
    interface Unit{
        void go();
        void setPosition(int x, int y);
        string getName();
    }
}
