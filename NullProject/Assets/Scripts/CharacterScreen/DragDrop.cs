using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 orgin;
    private ItemSlot itemInfo;
    [SerializeField] GameObject objectGUI;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        orgin = rectTransform.anchoredPosition;
        itemInfo = GetComponentInParent<ItemSlot>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeganDrag");
        canvasGroup.blocksRaycasts = false;
        NetworkGame.isDragging = true;
        canvasGroup.alpha = .7f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        NetworkGame.isDragging = false;
        rectTransform.anchoredPosition = orgin;
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.GetComponentInParent<ItemSlot>() != null || eventData.pointerEnter.GetComponent<GearSlot>().item != null)
        {
            objectGUI.SetActive(true);
        }
        //Set the itemGui info
        if (itemInfo != null)
        {
            Text[] text = objectGUI.GetComponentsInChildren<Text>();
            if (itemInfo.item.teir == 1)
            {
                text[0].color = new Color32(255, 255, 255, 255);
            }
            else if (itemInfo.item.teir == 2)
            {
                text[0].color = new Color32(51, 49, 164, 255);
            }
            else
            {
                text[0].color = new Color32(65, 8, 152, 255);
            }
            text[0].text = itemInfo.item.itemName + "";
            text[1].text = "Armor: " + itemInfo.item.ArmorValue + "";
            text[2].text = "Agility: " + itemInfo.item.Agility + "";
            text[3].text = "Strength: " + itemInfo.item.Strength + "";
            text[4].text = "Intellect: " + itemInfo.item.Intellect + "";
            text[5].text = "Stamina: " + itemInfo.item.Stamina + "";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectGUI.transform.position = new Vector3(0, 0, 0);
        objectGUI.SetActive(false);
    }

}
