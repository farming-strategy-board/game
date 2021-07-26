using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Unit : MonoBehaviour
{
    protected int attack;
    protected int speed;
    protected int x, y;
    protected int _hp;
    public int hp {
        get { return _hp; }
    }

    static public Vector3 ConvertGridToTransform(int x, int y){
        return new Vector3(x, y, 0);
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    abstract public void go();

    public void setPosition(int x, int y){
        this.x = x;
        this.y = y;
        transform.position = Unit.ConvertGridToTransform(x, y);
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
            gameObject.GetComponentInParent<Player>().deathUnit(gameObject);
            Destroy(gameObject);
        }
    }

    public void increaseHp(int amount){
        if(amount < 0){
            throw new System.Exception("음수값으로 힐링할 수 없습니다.");
        }
        _hp += amount;
    }

    public bool isAlive(){
        return _hp > 0;
    }
}
