using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //캔버스가 크기를 조정하는 방식 제한
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    //private RectTransform startPos;

    //자식 오브젝트를 한번에 제어
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    //드래그를 시작할 때
    public void OnBeginDrag(PointerEventData eventData)
    {
        //startPos = rectTransform;
        Debug.Log("OnBeginDrag");
        //UI요소의 불투명도 조절
        canvasGroup.alpha = .6f;
        //해당 컴포넌트로 Raycat함수를 호출할 것인지
        canvasGroup.blocksRaycasts = false;
    }

    //드래그 실행 중
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //앵커 기준점에 따른 포지션 정하기
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //드래그가 끝날 때
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        //rectTransform = startPos;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    //버튼을 클릭하는 순간
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

   /* public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/

}


