using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentActCommander : MonoBehaviour, IGetCompoable
{
    private Agent _agent;
    //public List<ActSO> OwnActs = new List<ActSO>();
    public Transform WeaponTrm;

    private StatManager _statManager;

    public int ActPoint = 0;

    public Action ActFail;

    public ActSO CurrentAct;

    public UnityEvent OnActChangeEvent, OnActRunEvent;

    public void Initialize(GetCompoParent entity)
    {
        _agent = entity as Agent;
        _statManager = entity.GetCompo<StatManager>();
    }

    public void ExecuteAct(Vector3 dir)
    {


        if(CurrentAct.IsCanActable)
        if (ActPoint - CurrentAct.SkillNeedPower >=0)
        {
            //ActPoint -= CurrentAct.SkillNeedPower;
            ActPoint = Mathf.Clamp(ActPoint - CurrentAct.CostPoints, 0, 999);

            float power = Mathf.Clamp(dir.magnitude + CurrentAct.MinPower, 0f, Mathf.Min(ActPoint, CurrentAct.MaxPower));

            CurrentAct.RunAct(dir.normalized * power,_agent);

            OnActRunEvent?.Invoke();
        }
    }



}
