using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLayoutManager : MonoBehaviour
{
    public GameObject LoadingPanel;
    public GameObject UnitLayoutPanel;

  
    void Start()
    {
        UnitLayoutPanel.SetActive(false);
        // 5초 로딩이후 유닛 배치 창 등장. 5초 로딩은 매칭이나 재화지급의 과정을 포함.
        StartCoroutine(DelayTime(5));
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);
        LoadingPanel.SetActive(false);
        UnitLayoutPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
