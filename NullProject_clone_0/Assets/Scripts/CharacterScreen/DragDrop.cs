using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,  IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 orgin;
    private ItemSlot itemInfo;
    [SerializeField] GameObject objectGUI;
   

    private void Awake() {
        rectTransform =  GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        orgin = rectTransform.anchoredPosition;
        itemInfo = GetComponentInParent<ItemSlot>();
    }

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeganDrag");
        canvasGroup.blocksRaycasts = false;
        NetworkGame.isDragging = true;
        canvasGroup.alpha = .7f;
    }

    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        NetworkGame.isDragging = false;
        rectTransform.anchoredPosition = orgin;
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("PointerDown");
    }

    public void OnDrag(PointerEventData eventData){
        rectTransform.position = Input.mousePosition;
    }

    public void OnPointerEnter(PointerEventData eventData){
        objectGUI.SetActive(true);
    }

     public void OnPointerExit(PointerEventData eventData){
        objectGUI.transform.position = new Vector3(0,0,0);
        objectGUI.SetActive(false);
    }
    
}
