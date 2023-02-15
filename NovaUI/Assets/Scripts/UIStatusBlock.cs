using System.Collections;
using System.Collections.Generic;
using Nova;
using TigerFrogGames;
using UnityEngine;

public class UIStatusBlock : MonoBehaviour
{
    [SerializeField] private EventChannelUnit OnUnitClick;

    [SerializeField] private EventChannelBasic OnUnitNotSelected;

    [SerializeField] private UIBlock2D hpProgress, hpRoot;
    [SerializeField] private TextBlock nameText, classText, hpText;
    
    
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
    

    private void OnUnitClickOnOnEvent(Unit unit)
    {
        hpRoot.gameObject.SetActive(true);
        hpProgress.Size.X.Percent = unit.unitCurrentHPPercent;
        
        nameText.gameObject.SetActive(true);
        nameText.Text = unit.unitName;
        
        classText.gameObject.SetActive(true);
        classText.Text = unit.unitClass;
        
        hpText.gameObject.SetActive(true);
        hpText.Text = unit.unitName;
    }
    
    private void OnUnitNotSelectedOnOnEvent()
    {
        hpRoot.gameObject.SetActive(false);
        
        nameText.gameObject.SetActive(false);
        classText.gameObject.SetActive(false);
        hpText.gameObject.SetActive(false);
    }
}
