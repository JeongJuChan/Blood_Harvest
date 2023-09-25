using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager
{
    private static UIManager _instance;
    public static UIManager Instance { get => GetInstnace(); }

    [Header("Current Popups")]
    private int _currentSortOrder = 10;
    private int _defaultSortOrder;
    private LinkedList<UIBase> _currentPopups = new LinkedList<UIBase>();

    private Dictionary<string, UIBase> _popupDict = new Dictionary<string, UIBase>();

    private UIManager()
    {
        _defaultSortOrder = _currentSortOrder;
    }

    private static UIManager GetInstnace()
    {
        if (_instance == null)
        {
            _instance = new UIManager();
        }

        return _instance;
    }

    public T ShowPopup<T>() where T : UIBase
    {
        return ShowPopup(typeof(T).Name) as T;
    }

    public UIBase ShowPopup(string popupName)
    {
        if (_currentPopups.Count > 0)
        {
            if (IsPopupExist(popupName, out UIBase popup))
            {
                SetPopupFront(popup);
                return null;
            }
        }

        if (!_popupDict.ContainsKey(popupName))
        {
            _popupDict.Add(popupName, ResourceManager.Instance.Load<UIBase>($"UI/{popupName}"));
        }

        UIBase uiPopup = UnityEngine.Object.Instantiate(_popupDict[popupName]);

        uiPopup.name = GetNameSubStringClone(uiPopup.name);

        SetPopupFront(uiPopup);

        return uiPopup;
    }

    private string GetNameSubStringClone(string originName)
    {
        return originName.Substring(0, originName.Length - 7);
    }

    public void ClosePopup<T>(T t) where T : UIBase
    {
        if (_currentPopups.Count == 0 || !_currentPopups.Contains(t))
        {
            return;
        }

        t.SetSortOrder(_defaultSortOrder);

        _currentPopups.Remove(t);
        _currentSortOrder--;

        if (_currentPopups.Count == 0)
            _currentSortOrder = _defaultSortOrder;
    }

    public void CloseLastPopup()
    {
        if (_currentPopups.Count == 0)
            return;

        UIBase uiBase = _currentPopups.Last();
        ClosePopup(uiBase);
    }

    public void OnPopupSelected(UIBase uiBase)
    {
        if (_currentPopups.Count == 0 || uiBase.Equals(_currentPopups.Last))
        {
            return;
        }


        SetPopupFront(uiBase);
    }

    private void SetPopupFront<T>(T t) where T : UIBase
    {
        _currentPopups.Remove(t);
        t.SetSortOrder(_currentSortOrder);
        _currentPopups.AddLast(t);
        _currentSortOrder++;
    }

    private bool IsPopupExist(string popupName, out UIBase uiPopup)
    {
        foreach (var popup in _currentPopups)
        {
            if (popupName.Equals(popup.name))
            {
                uiPopup = popup;
                return true;
            }
        }

        uiPopup = null;
        return false;
    }
}
