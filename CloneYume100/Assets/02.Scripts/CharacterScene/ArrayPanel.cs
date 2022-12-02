using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ArrayPanel : MonoBehaviour
{
    private List<CharacterMemberPanel> arrayMemberPanel = new List<CharacterMemberPanel>(); // 정렬된 panel 리스트
    public RectTransform tempContent;
    public RectTransform content;

    // Condition
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
    public Toggle purple;

    public Button conditionReset;
         
    // Order
    public Toggle orToggle;
    public GameObject orderPanel;

    public Toggle ascendingToggle;

    public Toggle rare;
    public Toggle color;
    public Toggle level;
    public Toggle getOrder;

    public Button orderReset;

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
        ArrayConditionCharacter(characterToggle.isOn, trainingToggle.isOn,
            fiveStar.isOn, fourStar.isOn, threeStar.isOn, twoStar.isOn, oneStar.isOn,
            red.isOn, blue.isOn, green.isOn, yellow.isOn, purple.isOn);

        ArrayOrderCharacter(ascendingToggle.isOn,
            rare.isOn, color.isOn, level.isOn, getOrder.isOn);
        
        SetActiveMemberPanel();

        gameObject.SetActive(false);
    }

    // 표시 조건 함수
    public void ArrayConditionCharacter(bool character, bool train,
        bool fiveStar, bool fourStar, bool threeStar, bool twoStar, bool oneStar,
        bool red, bool blue, bool green, bool yellow, bool purple)
    {
        arrayMemberPanel.Clear();

        List<CharacterMemberPanel> tempAllMembersPanel = MemberArray.allMembersPanel;

        int allPanelCount = tempAllMembersPanel.Count;

        int arrayCount;

        for (int j = 0; j < allPanelCount; j++)
        {
            tempAllMembersPanel[j].transform.SetParent(tempContent);
            tempAllMembersPanel[j].gameObject.SetActive(false);
        }

        // 캐릭터, 육성재료 표시 조건
        if ((character && train) || (!character && !train))
        {
            arrayMemberPanel = tempAllMembersPanel.ToList();
        }
        else if (character)
        {
            for (int i = 0; i < tempAllMembersPanel.Count; i++)
            {
                if (tempAllMembersPanel[i].code == 0)
                {
                    arrayMemberPanel.Add(tempAllMembersPanel[i]);
                }
            }
        }
        else if (train)
        {
            for (int i = 0; i < tempAllMembersPanel.Count; i++)
            {
                if (tempAllMembersPanel[i].code == 1)
                {
                    arrayMemberPanel.Add(tempAllMembersPanel[i]);
                }
            }
        }

        arrayCount = arrayMemberPanel.Count;

        // 레어도 표시 조건
        if (fiveStar || fourStar || threeStar || twoStar || oneStar)
        {
            List<CharacterMemberPanel> temp = new List<CharacterMemberPanel>();

            for (int m = 0; m < arrayCount; m++)
            {
                if (fiveStar && arrayMemberPanel[m].rare == 5)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
                else if (fourStar && arrayMemberPanel[m].rare == 4)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
                else if (threeStar && arrayMemberPanel[m].rare == 3)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
                else if (twoStar && arrayMemberPanel[m].rare == 2)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
                else if (oneStar && arrayMemberPanel[m].rare == 1)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
            }

            arrayMemberPanel = temp.ToList();
        }

        arrayCount = arrayMemberPanel.Count;

        // 속성 표시 조건
        if (red || blue || green || yellow || purple)
        {
            List<CharacterMemberPanel> temp = new List<CharacterMemberPanel>();

            for (int m = 0; m < arrayCount; m++)
            {
                if (red && arrayMemberPanel[m].colorNum == 0)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
                else if (blue && arrayMemberPanel[m].colorNum == 1)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
                else if (green && arrayMemberPanel[m].colorNum == 2)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
                else if (yellow && arrayMemberPanel[m].colorNum == 3)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
                else if (purple && arrayMemberPanel[m].colorNum == 4)
                {
                    temp.Add(arrayMemberPanel[m]);
                }
            }

            arrayMemberPanel = temp.ToList();
        }
    }

    public void ArrayOrderCharacter(bool ascending,
        bool rare, bool color, bool level, bool getOrder)
    {
        // 내림차순을 기준으로 정렬
        if (rare) // 레어도 기준
        {
            RareArrayOrder(ref arrayMemberPanel, out int rareFiveCount, out int rareFourCount, out int rareThreeCount, out int rareTwoCount, out int rareOneCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount + rareFourCount, rareFiveCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount + rareFourCount + rareThreeCount, rareFiveCount + rareFourCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount + rareFourCount + rareThreeCount + rareTwoCount, rareFiveCount + rareFourCount + rareThreeCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount + rareFourCount + rareThreeCount + rareTwoCount + rareOneCount, rareFiveCount + rareFourCount + rareThreeCount + rareTwoCount);

            // 후에 육성재료 부분 추가
        }
        else if (color) // 속성 기준
        {
            ColorArrayOrder(ref arrayMemberPanel, out int colorRedCount, out int colorBlueCount, out int colorGreenCount, out int colorYellowCount, out int colorPurpleCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount + colorBlueCount, colorRedCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount + colorBlueCount + colorGreenCount, colorRedCount + colorBlueCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount + colorBlueCount + colorGreenCount + colorYellowCount, colorRedCount + colorBlueCount + colorGreenCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount + colorBlueCount + colorGreenCount + colorYellowCount + colorPurpleCount, colorRedCount + colorBlueCount + colorGreenCount + colorYellowCount);

            // 후에 육성재료 부분 추가
        }
        else if (level) // Lv 기준
        {
            LevelArrayOrder(ref arrayMemberPanel);

            // 후에 육성재료 부분 추가 
        }
        else if (getOrder) // 입수 순 기준
        {
            GetOrderArrayOrder(ref arrayMemberPanel);
        }

        if (ascending) // 오름차순
        {
            arrayMemberPanel.Reverse();
        }
    }

    // 레어도 순서 함수
    private void RareArrayOrder(ref List<CharacterMemberPanel> objectsList, out int fiveCount, out int fourCount, out int threeCount, out int twoCount, out int oneCount)
    {
        fiveCount = 0;
        fourCount = 0;
        threeCount = 0;
        twoCount = 0;
        oneCount = 0;

        int count = objectsList.Count;
        int max;

        for (int i = 0; i < count - 1; i++)
        {
            max = i;
            for (int j = i + 1; j < count; j++)
            {
                if (objectsList[j].rare > objectsList[max].rare)
                {
                    max = j;
                }
            }

            if (i != max)
            {
                CharacterMemberPanel temp = objectsList[max];
                objectsList[max] = objectsList[i];
                objectsList[i] = temp;
            }
        }

        for (int k = 0; k < count; k++)
        {
            if (arrayMemberPanel[k].rare == 5)
            {
                fiveCount += 1;
            }
            else if (arrayMemberPanel[k].rare == 4)
            {
                fourCount += 1;
            }
            else if (arrayMemberPanel[k].rare == 3)
            {
                threeCount += 1;
            }
            else if (arrayMemberPanel[k].rare == 2)
            {
                twoCount += 1;
            }
            else if (arrayMemberPanel[k].rare == 1)
            {
                oneCount += 1;
            }
        }
    }

    // 속성 순서 함수
    private void ColorArrayOrder(ref List<CharacterMemberPanel> objectsList, out int redCount, out int blueCount, out int greenCount, out int yellowCount, out int purpleCount)
    {
        redCount = 0;
        blueCount = 0;
        greenCount = 0;
        yellowCount = 0;
        purpleCount = 0;

        int count = objectsList.Count;
        int min;

        for (int i = 0; i < count - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < count; j++)
            {
                if (objectsList[j].colorNum < objectsList[min].colorNum)
                {
                    min = j;
                }
            }

            if (i != min)
            {
                CharacterMemberPanel temp = objectsList[min];
                objectsList[min] = objectsList[i];
                objectsList[i] = temp;
            }
        }

        for (int k = 0; k < count; k++)
        {
            if (arrayMemberPanel[k].colorNum == 0)
            {
                redCount += 1;
            }
            else if (arrayMemberPanel[k].colorNum == 1)
            {
                blueCount += 1;
            }
            else if (arrayMemberPanel[k].colorNum == 2)
            {
                greenCount += 1;
            }
            else if (arrayMemberPanel[k].colorNum == 3)
            {
                yellowCount += 1;
            }
            else if (arrayMemberPanel[k].colorNum == 4)
            {
                purpleCount += 1;
            }
        }
    }

    // 입수 순서 함수
    private void GetOrderArrayOrder(ref List<CharacterMemberPanel> objectsList)
    {
        int count = objectsList.Count;
        int max;

        for (int i = 0; i < count - 1; i++)
        {
            max = i;
            for (int j = i + 1; j < count; j++)
            {
                if (objectsList[j].getOrderNum > objectsList[max].getOrderNum)
                {
                    max = j;
                }
            }

            if (i != max)
            {
                CharacterMemberPanel temp = objectsList[max];
                objectsList[max] = objectsList[i];
                objectsList[i] = temp;
            }
        }
    }

    // 레벨 순서 함수(레어도 Ver)
    private void LevelRareArrayOrder(ref List<CharacterMemberPanel> objectsList, int end, int start = 0)
    {
        int max;

        for (int i = start; i < end - 1; i++)
        {
            max = i;
            for (int j = i + 1; j < end; j++)
            {
                if (objectsList[j].lv > objectsList[max].lv)
                {
                    max = j;
                }
                else if (objectsList[j].lv == objectsList[max].lv)
                {
                    if (objectsList[j].colorNum < objectsList[max].colorNum)
                    {
                        max = j;
                    }
                    else if (objectsList[j].colorNum == objectsList[max].colorNum)
                    {
                        if (objectsList[j].getOrderNum > objectsList[max].getOrderNum)
                        {
                            max = j;
                        }
                    }
                }
            }

            if (i != max)
            {
                CharacterMemberPanel temp = objectsList[max];
                objectsList[max] = objectsList[i];
                objectsList[i] = temp;
            }
        }
    }

    // 레벨 순서 함수(속성 Ver)
    private void LevelColorArrayOrder(ref List<CharacterMemberPanel> objectsList, int end, int start = 0)
    {
        int max;

        for (int i = start; i < end - 1; i++)
        {
            max = i;
            for (int j = i + 1; j < end; j++)
            {
                if (objectsList[j].lv > objectsList[max].lv)
                {
                    max = j;
                }
                else if (objectsList[j].lv == objectsList[max].lv)
                {
                    if (objectsList[j].rare > objectsList[max].rare)
                    {
                        max = j;
                    }
                    else if (objectsList[j].rare == objectsList[max].rare)
                    {
                        if (objectsList[j].getOrderNum > objectsList[max].getOrderNum)
                        {
                            max = j;
                        }
                    }
                }
            }

            if (i != max)
            {
                CharacterMemberPanel temp = objectsList[max];
                objectsList[max] = objectsList[i];
                objectsList[i] = temp;
            }
        }
    }

    // 레벨 순서 함수
    private void LevelArrayOrder(ref List<CharacterMemberPanel> objectsList)
    {
        int max;
        int count = objectsList.Count;

        for (int i = 0; i < count - 1; i++)
        {
            max = i;
            for (int j = i + 1; j < count; j++)
            {
                if (objectsList[j].lv > objectsList[max].lv)
                {
                    max = j;
                }
                else if (objectsList[j].lv == objectsList[max].lv)
                {
                    if (objectsList[j].colorNum < objectsList[max].colorNum)
                    {
                        max = j;
                    }
                    else if (objectsList[j].colorNum == objectsList[max].colorNum)
                    {
                        if (objectsList[j].rare > objectsList[max].rare)
                        {
                            max = j;
                        }
                        else if (objectsList[j].rare == objectsList[max].rare)
                        {
                            if (objectsList[j].getOrderNum > objectsList[max].getOrderNum)
                            {
                                max = j;
                            }
                        }
                    }
                }
            }

            if (i != max)
            {
                CharacterMemberPanel temp = objectsList[max];
                objectsList[max] = objectsList[i];
                objectsList[i] = temp;
            }
        }
    }

    public void SetActiveMemberPanel()
    {
        int arrayCount = arrayMemberPanel.Count;

        // 스크롤의 content의 크기를 조절
        if (arrayCount == 1)
        {
            content.sizeDelta = new Vector2(content.sizeDelta.x, 120);
        }
        else if (arrayCount > 1)
        {
            int lineCount = 0; // 스크롤의 content의 크기를 조절하기 위해 필요
            if (arrayCount % 5 == 0)
            {
                lineCount = arrayCount / 5;
            }
            else
            {
                lineCount = (arrayCount / 5) + 1;
            }
            content.sizeDelta = new Vector2(content.sizeDelta.x, 120 + (lineCount - 1) * 140);
        }

        for (int k = 0; k < arrayCount; k++) // 정렬된 panel을 활성화
        {
            arrayMemberPanel[k].transform.SetParent(content);
            arrayMemberPanel[k].gameObject.SetActive(true);
        }
    }
}
