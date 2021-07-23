using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UnitLayoutManager : MonoBehaviour
{
    public GameObject LoadingPanel;
    public GameObject UnitLayoutPanel;

  
    void Start()
    {
        // UnitLayoutPanel.SetActive(false);
        // 5�� �ε����� ���� ��ġ â ����. 5�� �ε��� ��Ī�̳� ��ȭ������ ������ ����.
        StartCoroutine(DelayTime(2));
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);
        // LoadingPanel.SetActive(false);
        // UnitLayoutPanel.SetActive(true);
        SceneManager.LoadScene("Stadium");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
