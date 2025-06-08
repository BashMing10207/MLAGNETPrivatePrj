
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour, IGetCompoable
{
    protected GetCompoParent _parent;

    public List<ActSO> Items = new();

    public List<ActSO> Skills = new();

    public void Initialize(GetCompoParent entity)
    {
        _parent = entity;
    }


    public void TurnEvent()
    {

    }

    public void Start()
    {
        
    }

    public void OnDestroy()
    {

    }



}
