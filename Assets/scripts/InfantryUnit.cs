using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryUnit : Unit
{
    
    
    // Start is called before the first frame update
    
    void Start()
    {
        attack = 10;
        speed = 1;
        _hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void go(){
        Debug.Log("InfantryUnit's go()");
        // 누구 : 적 or 아군, 그 중 어떤 유닛
    }
}