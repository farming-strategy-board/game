using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class InfantryUnit : MonoBehaviour, Unit
{
    private int hp;
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
    
    public void setPosition(int x, int y){
        this.x = x;
        this.y = y;
    }
}

namespace Types{
    interface Unit{
        void go();
        void setPosition(int x, int y);
    }
}
