using System.Collections.Generic;
using UnityEngine;

public class Unit : Agent
{

    public bool IsSelected = false;
    [SerializeField] private List<GameObject> _isSelectedObj, _isDisabledObj = new();
    public Transform ViewPivot;
    public Transform WeaponTrm;
    public GetCompoParent MasterController;

    public void Init(GetCompoParent masterController)
    {
        MasterController = masterController;
    }

    public void SelectVisual(bool enable)
    {
        IsSelected = enable;
        if(_isSelectedObj != null)
            foreach(var obj in _isSelectedObj)
                obj.SetActive(enable);
        if(_isDisabledObj != null)
            foreach(var obj in _isDisabledObj)
                obj.SetActive(!enable);
    }
}

