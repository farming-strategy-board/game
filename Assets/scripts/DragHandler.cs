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
        //����� ��� : �巡�� ������ ��ġ
        Debug.Log("OnBeginDrag" + startPos);
        startParent = transform.parent;
        //UI����� ������ ����
        canvasGroup.alpha = .6f;
        //�ش� ������Ʈ�� Raycat�Լ��� ȣ���� ������
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