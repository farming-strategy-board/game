using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
   
    Vector3 mousePos, transPos, targetPos;
    public GameObject unitLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unitLayer.activeSelf == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                CalTargetPos();
            }
            MoveToTarget();
        }
    }

    void CalTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
    }

    void MoveToTarget()
    {
        transform.position = targetPos;
    }
}
