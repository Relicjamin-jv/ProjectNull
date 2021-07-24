using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositiion : MonoBehaviour
{
    public Camera uiCamera;
    // Start is called before the first frame update
    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        float clampedX = Mathf.Clamp(localPoint.x, -1000, 305);
        float clampedY = Mathf.Clamp(localPoint.y, -1000, 62);
        Debug.Log(localPoint.x + " " + localPoint.y);
        transform.localPosition = new Vector2(clampedX + 10, clampedY + 8);
    }

}
