using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] LayerMask layer;
    [SerializeField] float radius;
    [SerializeField] Collider[] col;

    [SerializeField] Transform target;

	// Use this for initialization
	void Start () 
    {
		InvokeRepeating("enemyaround", 0, 0.2f);
	}

	// Update is called once per frame
	void Update () 
    {

    }

    void enemyaround()
    {
        col = Physics.OverlapSphere(player.transform.position, radius, layer);

        Transform short_enemy = null;

        if(col.Length > 0)
        {
            float short_distance = Mathf.Infinity;

            foreach (Collider s_col in col)
            {
                float playerToenemy = Vector3.SqrMagnitude(player.transform.position - s_col.transform.position);

                if(short_distance > playerToenemy)
                {
                    short_distance = playerToenemy;
                    short_enemy = s_col.transform;
                }
            }
        }

        target = short_enemy;
    }
}
