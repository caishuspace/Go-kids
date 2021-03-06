﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class drag : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        //拖拽移动图片
        SetDraggedPosition(eventData);
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = gameObject.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
        }
    }
}
