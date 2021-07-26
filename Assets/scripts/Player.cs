using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefabInfantryUnit;
    // Start is called before the first frame update
    public string id;
    private int _hp = 100;
    public int hp { 
        get { return _hp; }
    }
    private int money;

    void Start()
    {
        DontDestroyOnLoad(this);

        addNewUnit();

        Unit[] units = GetComponentsInChildren<Unit>();
        units[0].go();
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

    public void addNewUnit(){
        GameObject newUnit = Instantiate(prefabInfantryUnit);
        newUnit.transform.SetParent(gameObject.transform);
    }

    public string getUnitsListString(){
        return "";
    }

    public void purchaseUnit(){

    }

    public int getAliveUnitNum(){
        return GetComponentsInChildren<Unit>().Length;
    }

    public void deathUnit(GameObject obj){
        Debug.Log(obj + " dead");
    }
}