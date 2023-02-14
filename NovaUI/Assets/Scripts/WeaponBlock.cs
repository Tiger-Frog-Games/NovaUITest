using System;
using System.Collections;
using System.Collections.Generic;
using TigerFrogGames;
using UnityEngine;

public class WeaponBlock : MonoBehaviour
{
    [SerializeField] private EventChannelUnit OnUnitClick;

    [SerializeField] private EventChannelBasic OnUnitNotSelected;
    
    [SerializeField] private UIWeaponHolder uiPrefab;

    
    
    private List<UIWeaponHolder> weaponBlockHolders = new ();

    private void OnEnable()
    {
        OnUnitClick.OnEvent += OnUnitClickOnOnEvent;
        OnUnitNotSelected.OnEvent += OnUnitNotSelectedOnOnEvent;
    }
    
    private void OnDisable()
    {
        OnUnitClick.OnEvent -= OnUnitClickOnOnEvent;
        OnUnitNotSelected.OnEvent -= OnUnitNotSelectedOnOnEvent;
    }
    
    private void OnUnitClickOnOnEvent(Unit InternalObj)
    {
        for (int i = weaponBlockHolders.Count - 1; i >= 0; i--)
        {
            Destroy(weaponBlockHolders[i].gameObject);
        }
        weaponBlockHolders.Clear();


        foreach (var weapon in InternalObj.unitWeapons)
        {
            var temp = Instantiate(uiPrefab, gameObject.transform, false);
            temp.setUp(weapon);
            
            weaponBlockHolders.Add(temp);
        }
    }
    
    private void OnUnitNotSelectedOnOnEvent()
    {
        for (int i = weaponBlockHolders.Count - 1; i >= 0; i--)
        {
            Destroy(weaponBlockHolders[i].gameObject);
        }
        weaponBlockHolders.Clear();
    }
    
}
