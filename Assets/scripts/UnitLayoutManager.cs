using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UnitLayoutManager : MonoBehaviour
{
    public GameObject LoadingPanel;
    public GameObject UnitLayoutPanel;

    private GameManager gameManager;
  
    void Start()
    {
        gameManager = GameManager.instance;
        StartCoroutine(DelayTime(2));
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Stadium");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
