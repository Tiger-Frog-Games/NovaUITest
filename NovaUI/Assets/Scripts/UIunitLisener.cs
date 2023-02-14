using System;
using System.Collections;
using System.Collections.Generic;
using TigerFrogGames;
using UnityEngine;

public class UIunitLisener : MonoBehaviour
{
    [SerializeField] private EventChannelUnit OnSelectedUnit;

    [SerializeField] private EventChannel OnButtonSelect;
    
    [SerializeField] private GameObject actionsRoot;
    
    private Unit currentSelectedUnit;
    
    void Start()
    {
        OnSelectedUnit.OnEvent += OnSelectedUnitOnOnEvent;
    }
    
    private void OnDestroy()
    {
        OnSelectedUnit.OnEvent -= OnSelectedUnitOnOnEvent;
    }

    private void OnSelectedUnitOnOnEvent(Unit unit)
    {
        currentSelectedUnit = unit;
        
        if (currentSelectedUnit.isAPlayer)
        {
            showActions();
        }
        else
        {
            hideActions();
        }
    }
    
    private void showActions()
    {
        actionsRoot.SetActive(true);
    }

    private void hideActions()
    {
        OnButtonSelect.RaiseEvent(null);
        actionsRoot.SetActive(false);
    }
    
}
