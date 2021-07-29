using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //ĵ������ ũ�⸦ �����ϴ� ��� ����
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    //private RectTransform startPos;

    //�ڽ� ������Ʈ�� �ѹ��� ����
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    //�巡�׸� ������ ��
    public void OnBeginDrag(PointerEventData eventData)
    {
        //startPos = rectTransform;
        Debug.Log("OnBeginDrag");
        //UI����� ������ ����
        canvasGroup.alpha = .6f;
        //�ش� ������Ʈ�� Raycat�Լ��� ȣ���� ������
        canvasGroup.blocksRaycasts = false;
    }

    //�巡�� ���� ��
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //��Ŀ �������� ���� ������ ���ϱ�
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //�巡�װ� ���� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        //rectTransform = startPos;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    //��ư�� Ŭ���ϴ� ����
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

   /* public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/

}


