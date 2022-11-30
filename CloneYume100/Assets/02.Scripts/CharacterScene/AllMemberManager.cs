using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AllMemberManager : MonoBehaviour
{
    static public List<int> allObjectsOrder = new List<int>(); // 플레이어가 가지고 있는 오브젝트들 리스트
    static public List<Character> allCharacters = new List<Character>(); // 플레이어가 가지고 있는 캐릭터 리스트
    static public List<TrainingObject> allTrainingObjects = new List<TrainingObject>(); // 플레이어가 가지고 있는 육성재료 리스트
    private List<CharacterMemberPanel> allMembersPanel = new List<CharacterMemberPanel>(); // 만든 오브젝트의 Panel 리스트(가장 먼저 만들어진 CharacterPanel이 앞번호로 온다.)(입수 순)
    private List<CharacterMemberPanel> arrayMemberPanel = new List<CharacterMemberPanel>(); // 정렬된 panel 리스트

    public GameObject characterMemberPanel; // 캐릭터 프리팹
    public GameObject trainingObjectMemberPanel; // 육성 재료 프리팹
    public RectTransform content;
    public RectTransform tempContent;

    public TextMeshProUGUI memberCount; // 멤버 수 UI
    private int count; // 멤버 수
    private int maxCount = 100; // 최대 멤버 수

    private void Start()
    {
        count = allCharacters.Count + allTrainingObjects.Count;
        if(count <= maxCount)
        {
            memberCount.color = Color.black;
            memberCount.text = count + " / " + maxCount;
        }
        else
        {
            memberCount.color = Color.red;
            memberCount.text = count + " / " + maxCount;
        }

        if (count == 1)
        {
            content.sizeDelta = new Vector2(content.sizeDelta.x, 120);
        }
        else if(count > 1)
        {
            int lineCount = 0; // 스크롤의 content의 크기를 조절하기 위해 필요
            if(count % 5 == 0)
            {
                lineCount = count / 5;
            }
            else
            {
                lineCount = (count / 5) + 1;
            }
            content.sizeDelta = new Vector2(content.sizeDelta.x, 120 + (lineCount - 1) * 140);
        }

        int objectCount = allObjectsOrder.Count;
        int characterCount = allCharacters.Count;
        int trainingObjectCount = allTrainingObjects.Count;

        for (int i = objectCount - 1; i >= 0; i--) // 갖고있는 캐릭터의 panel 생성(가장 최근에 추가된 캐릭터가 가장 먼저 오도록)
        {
            if(allObjectsOrder[i] == 0) // 캐릭터
            {
                CharacterMemberPanel temp = Instantiate(characterMemberPanel, content).GetComponent<CharacterMemberPanel>() ;
                Character cha = allCharacters[characterCount - 1];
                cha.getOrderNum = i;
                temp.SetCharacterMemberPanel(cha);
                characterCount -= 1;
                allMembersPanel.Add(temp);
            }
            else // 육성재료
            {

            }
            
            
            
        }
    }

    // 표시 조건 함수
    public void ArrayConditionCharacter(bool character, bool train, 
        bool fiveStar, bool fourStar, bool threeStar, bool twoStar, bool oneStar,
        bool red, bool blue, bool green, bool yellow, bool purple)
    {
        arrayMemberPanel.Clear();

        int allPanelCount = allMembersPanel.Count;

        int arrayCount;

        for (int j = 0; j < allPanelCount; j++)
        {
            allMembersPanel[j].transform.SetParent(tempContent);
            allMembersPanel[j].gameObject.SetActive(false);
        }
        
        // 캐릭터, 육성재료 표시 조건
        if ((character && train) || (!character && !train))
        {
            arrayMemberPanel = allMembersPanel.ToList();
        }
        else if (character)
        {
            for(int i = 0; i < allMembersPanel.Count; i++)
            {
                if(allMembersPanel[i].code == 0)
                {
                    arrayMemberPanel.Add(allMembersPanel[i]);
                }
            }
        }
        else if (train)
        {
            for (int i = 0; i < allMembersPanel.Count; i++)
            {
                if (allMembersPanel[i].code == 1)
                {
                    arrayMemberPanel.Add(allMembersPanel[i]);
                }
            }
        }

        arrayCount = arrayMemberPanel.Count;

        // 레어도 표시 조건
        if (fiveStar || fourStar || threeStar || twoStar || oneStar)
        {
            List<CharacterMemberPanel> temp = new List<CharacterMemberPanel>();

            for (int m = 0; m < arrayCount; m ++)
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
        if(rare) // 레어도 기준
        {
            RareArrayOrder(ref arrayMemberPanel, out int rareFiveCount, out int rareFourCount, out int rareThreeCount, out int rareTwoCount, out int rareOneCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount + rareFourCount, rareFiveCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount + rareFourCount + rareThreeCount, rareFiveCount + rareFourCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount + rareFourCount + rareThreeCount + rareTwoCount, rareFiveCount + rareFourCount + rareThreeCount);
            LevelRareArrayOrder(ref arrayMemberPanel, rareFiveCount + rareFourCount + rareThreeCount + rareTwoCount + rareOneCount, rareFiveCount + rareFourCount + rareThreeCount + rareTwoCount);

            // 후에 육성재료 부분 추가
        }
        else if(color) // 속성 기준
        {
            ColorArrayOrder(ref arrayMemberPanel, out int colorRedCount, out int colorBlueCount, out int colorGreenCount, out int colorYellowCount, out int colorPurpleCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount + colorBlueCount, colorRedCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount + colorBlueCount + colorGreenCount, colorRedCount + colorBlueCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount + colorBlueCount + colorGreenCount + colorYellowCount, colorRedCount + colorBlueCount + colorGreenCount);
            LevelColorArrayOrder(ref arrayMemberPanel, colorRedCount + colorBlueCount + colorGreenCount + colorYellowCount + colorPurpleCount, colorRedCount + colorBlueCount + colorGreenCount + colorYellowCount);

            // 후에 육성재료 부분 추가
        }
        else if(level) // Lv 기준
        {
            LevelArrayOrder(ref arrayMemberPanel);

            // 후에 육성재료 부분 추가 
        }
        else if(getOrder) // 입수 순 기준
        {
            GetOrderArrayOrder(ref arrayMemberPanel);
        }

        if(ascending) // 오름차순
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

        for(int i = 0; i < count - 1; i++)
        {
            max = i;
            for(int j = i + 1; j < count; j++)
            {
                if(objectsList[j].rare > objectsList[max].rare)
                {
                    max = j;
                }
            }

            if(i != max)
            {
                CharacterMemberPanel temp = objectsList[max];
                objectsList[max] = objectsList[i];
                objectsList[i] = temp;
            }
        }

        for(int k = 0; k < count; k++)
        {
            if(arrayMemberPanel[k].rare == 5)
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

        count = objectsList.Count;
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
        count = objectsList.Count;
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
                else if(objectsList[j].lv == objectsList[max].lv)
                {
                    if(objectsList[j].colorNum < objectsList[max].colorNum)
                    {
                        max = j;
                    }
                    else if(objectsList[j].colorNum == objectsList[max].colorNum)
                    {
                        if(objectsList[j].getOrderNum > objectsList[max].getOrderNum)
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
                        else if(objectsList[j].rare == objectsList[max].rare)
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
