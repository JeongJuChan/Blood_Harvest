using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIBase : MonoBehaviour, IPointerClickHandler
{
    [Header("Popup Canvas")]
    private Canvas _canvas;

    private event Action<UIBase> _selectEvent;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    private void OnEnable()
    {
        _selectEvent += UIManager.Instance.OnPopupSelected;
    }

    private void Start()
    {
        _canvas.sortingOrder = 10;
    }

    private void OnDisable()
    {
        _selectEvent -= UIManager.Instance.OnPopupSelected;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Focus();
    }

    public void SetSortOrder(int sortOrder)
    {
        _canvas.sortingOrder = sortOrder;   
    }

    private void Focus()
    {
        _selectEvent.Invoke(this);
    }


}
