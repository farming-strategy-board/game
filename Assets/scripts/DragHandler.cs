using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemDrag;
    Vector3 startPos;
    Transform startParent;
    CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDrag = gameObject;
        startPos = transform.position;
        //디버그 출력 : 드래그 시작한 위치
        Debug.Log("OnBeginDrag" + startPos);
        startParent = transform.parent;
        //UI요소의 불투명도 조절
        canvasGroup.alpha = .6f;
        //해당 컴포넌트로 Raycat함수를 호출할 것인지
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemDrag = null;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (transform.parent != startParent)
        {
            transform.position = startPos;
        }
        Debug.Log("OnEndDrag");
    }
}