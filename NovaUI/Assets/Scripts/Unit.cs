using System;
using System.Collections;
using System.Collections.Generic;
using TigerFrogGames;
using UnityEngine;

public class Unit : MonoBehaviour, IClickable
{
    //note this is an info holder for the ui demo.
    
    [field: SerializeField] public bool isAPlayer { private set; get; }
    [field: SerializeField] public String unitName { private set; get; }
    [field: SerializeField] public List<WeaponData> unitWeapons { private set; get; }

    [SerializeField] private EventChannelUnit onClickedUnit;
    
    [Serializable]
    public struct WeaponData
    {
        public string weaponName;
        public string Ammo;
        public string Damage;
        public string hitPercentage;
    }

    public void OnClick()
    {
        onClickedUnit.RaiseEvent(this);
    }
}




