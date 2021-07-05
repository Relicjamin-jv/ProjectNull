using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,  IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 orgin;

    private void Awake() {
        rectTransform =  GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        orgin = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeganDrag");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .7f;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        rectTransform.anchoredPosition = orgin;
    }

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("PointerDown");
    }

    public void OnDrag(PointerEventData eventData){
        rectTransform.position = Input.mousePosition;
    }
}