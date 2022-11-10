using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayPanel : MonoBehaviour
{
    public AllMemberManager aMMgr;
    
    // Conditional
    public Toggle conToggle;
    public GameObject conditionalPanel;

    // Order
    public Toggle orToggle;
    public GameObject orderPanel;

    private void Start()
    {
        orToggle.onValueChanged.AddListener(ChangeArrayPanel);
    }

    private void ChangeArrayPanel(bool orToggleOn)
    {
        if(orToggleOn)
        {
            conditionalPanel.SetActive(false);
            orderPanel.SetActive(true);
        }
        else
        {
            conditionalPanel.SetActive(true);
            orderPanel.SetActive(false);
        }
    }

    //private 
}
