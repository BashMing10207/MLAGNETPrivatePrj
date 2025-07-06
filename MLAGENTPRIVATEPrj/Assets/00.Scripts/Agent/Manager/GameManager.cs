using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : GetCompoParent //Manager<GameManager>
{
    public Action OnTurnEnd;

    private bool _isPlayerturn =true;
    public bool IsPlayerturn => _isPlayerturn;

    public List<GetCompoParent> PlayerManagerCompos = new List<GetCompoParent>();
    //public EnemyManager EnemyManagerCompo;
    //public GetCompoParent PlayerManagerCompo => PlayerManagerCompos[_isPlayerturn ? 0:1];
    public GetCompoParent CurrentClientPlayerManagerCompo; // CurrentPlayer <= you

    public event Action OnTwoTurnEndEvent,OnTurnEndEvent;
    public static GameManager Instance;

    public PlayerInputSO PlayerInputSO;
    protected override void Awake()
    {
        //if(Instance != null)
        //    Destroy(Instance);

        Instance = this;
        base.Awake();
        OnTurnEnd += TurnEnd;
    }

    public void AddPlayer(Player player)
    {
        PlayerManagerCompos.Add(player);
    }

    [ContextMenu("TurnChange")]
    private void TurnEnd()
    {
        CurrentClientPlayerManagerCompo.gameObject.SetActive(false);
        _isPlayerturn = !_isPlayerturn;//턴넘기기
        CurrentClientPlayerManagerCompo.gameObject.SetActive(true);
        OnTurnEndEvent?.Invoke();

        if(_isPlayerturn)
            OnTwoTurnEndEvent?.Invoke();
        
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            TurnEnd();
        }
    }
}
