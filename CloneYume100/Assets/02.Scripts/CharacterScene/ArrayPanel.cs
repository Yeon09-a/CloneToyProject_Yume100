using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayPanel : MonoBehaviour
{
    public AllMemberManager aMMgr;
    
    // Conditional
    public Toggle conToggle;
    public GameObject conditionPanel;

    public Toggle characterToggle;
    public Toggle trainingToggle;

    public Toggle oneStar;
    public Toggle twoStar;
    public Toggle threeStar;
    public Toggle fourStar;
    public Toggle fiveStar;

    public Toggle red;
    public Toggle blue;
    public Toggle green;
    public Toggle yellow;
    public Toggle pupple;
         
    // Order
    public Toggle orToggle;
    public GameObject orderPanel;

    public Button okay;

    private void Start()
    {
        orToggle.onValueChanged.AddListener(ChangeArrayPanel);
        okay.onClick.AddListener(() => PressOkay());
    }

    private void ChangeArrayPanel(bool orToggleOn)
    {
        if(orToggleOn)
        {
            conditionPanel.SetActive(false);
            orderPanel.SetActive(true);
        }
        else
        {
            conditionPanel.SetActive(true);
            orderPanel.SetActive(false);
        }
    }

    private void PressOkay()
    {
        aMMgr.ArrayConditionCharacter(characterToggle.isOn, trainingToggle.isOn,
            fiveStar.isOn, fourStar.isOn, threeStar.isOn, twoStar.isOn, oneStar.isOn,
            red.isOn, blue.isOn, green.isOn, yellow.isOn, pupple.isOn);

        gameObject.SetActive(false);
    }
}
