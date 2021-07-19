using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GoPrologScene()
    {
        SceneManager.LoadScene("PrologScene");
    }
    public void GoUnitScene()
    {
        SceneManager.LoadScene("UnitScene");
    }
   
}
