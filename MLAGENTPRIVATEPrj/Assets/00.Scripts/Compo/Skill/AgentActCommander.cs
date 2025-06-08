using System.Collections.Generic;
using UnityEngine;

public class AgentActCommander : MonoBehaviour, IGetCompoable
{
    private Agent _agent;
    //public List<ActSO> OwnActs = new List<ActSO>();
    public Transform WeaponTrm;

    private StatManager _statManager;

    public int actPoint = 0;

    public void Initialize(GetCompoParent entity)
    {
        _agent = entity as Agent;
        _statManager = entity.GetCompo<StatManager>();
    }

    public void ExecuteAct(ActSO act, Vector3 dir)
    {
        if(actPoint - act.SkillNeddPower >0)
        {
            actPoint -= act.SkillNeddPower;
            act.RunAct(dir,_agent);
        }
    }

}
