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
    private List<GameObject> allMembersPanel = new List<GameObject>(); // 만든 오브젝트의 Panel 리스트(가장 먼저 만들어진 CharacterPanel이 앞번호로 온다.)(입수 순)
    private List<GameObject> arrayMemberPanel = new List<GameObject>(); // 정렬된 panel 리스트

    public GameObject characterMemberPanel; // 캐릭터 프리팹
    public RectTransform content;

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
                GameObject temp = Instantiate(characterMemberPanel, content);
                Character cha = allCharacters[characterCount - 1];
                temp.GetComponent<CharacterMemberPanel>().SetCharacterMemberPanel(
                    (int)cha.color,
                    cha.characterImage,
                    cha.starsImage,
                    cha.colorImage,
                    cha.lv,
                    cha.rare);
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
        bool red, bool blue, bool green, bool yellow, bool pupple)
    {
        arrayMemberPanel.Clear();

        int allPanelCount = allMembersPanel.Count;

        int arrayCount;

        for (int j = 0; j < allPanelCount; j++)
        {
            allMembersPanel[j].SetActive(false);
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
                if(allMembersPanel[i].GetComponent<CharacterMemberPanel>())
                {
                    arrayMemberPanel.Add(allMembersPanel[i]);
                }
            }
        }
        else if (train)
        {
            for (int i = 0; i < allMembersPanel.Count; i++)
            {
                if (allMembersPanel[i].GetComponent<TrainingObjectMemberPanel>())
                {
                    arrayMemberPanel.Add(allMembersPanel[i]);
                }
            }
        }

        arrayCount = arrayMemberPanel.Count;

        // 레어도 표시 조건
        if (fiveStar || fourStar || threeStar || twoStar || oneStar)
        {
            List<GameObject> temp = new List<GameObject>();

            for (int m = 0; m < arrayCount; m ++)
            {
                if(arrayMemberPanel[m].GetComponent<CharacterMemberPanel>()) // 캐릭터인 경우
                {
                    if (fiveStar && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().rare == 5)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (fourStar && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().rare == 4)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (threeStar && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().rare == 3)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (twoStar && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().rare == 2)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (oneStar && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().rare == 1)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                }
                else // 육성재료일 경우
                {

                }
            }

            arrayMemberPanel = temp.ToList();
        }

        arrayCount = arrayMemberPanel.Count;

        // 속성 표시 조건
        if (red || blue || green || yellow || pupple)
        {
            List<GameObject> temp = new List<GameObject>();

            for (int m = 0; m < arrayCount; m++)
            {
                if (arrayMemberPanel[m].GetComponent<CharacterMemberPanel>()) // 캐릭터인 경우
                {
                    if (red && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().colorNum == 0)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (blue && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().colorNum == 1)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (green && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().colorNum == 2)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (yellow && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().colorNum == 3)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (pupple && arrayMemberPanel[m].GetComponent<CharacterMemberPanel>().colorNum == 4)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                }
                else // 육성재료일 경우
                {

                }
            }

            arrayMemberPanel = temp.ToList();
        }

        arrayCount = arrayMemberPanel.Count;

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

        for(int k = 0; k < arrayCount; k++) // 정렬된 panel을 활성화
        {
            arrayMemberPanel[k].SetActive(true);
        }
    }
}
