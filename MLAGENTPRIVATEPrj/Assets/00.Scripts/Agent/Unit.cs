using System.Collections.Generic;
using UnityEngine;


public class Unit : Agent
{

    public bool IsSelected = false;
    [SerializeField] private List<GameObject> _isSelectedObj, _isDisabledObj = new();
    public Transform ViewPivot;
    public Transform WeaponTrm;
    public GetCompoParent MasterController;

    public AgentController Controller;

    public StatManager UnitStat; //모든 유닛에게 존재하며 캐싱하는 편이 최적화에 도움이 된다고 판단하였음.

    protected List<IAgentDieEvent> AgentDieEventList = new();

    protected override void Awake()
    {
#if UNITY_EDITOR
        if (gameObject.GetComponent<AgentController>() == null)
            Debug.LogWarning("컨트롤러가 없잖아!!");
#endif

        base.Awake();
        AgentDieEventList.AddRange(GetComponentsInChildren<IAgentDieEvent>(true));
        UnitStat = GetComponentInChildren<StatManager>(true);
    }

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

    public void UnitDie()
    {
        while(AgentDieEventList.Count > 0) 
        {
            AgentDieEventList[0].OnDead();
            AgentDieEventList.RemoveAt(0);
        }
    }
}

