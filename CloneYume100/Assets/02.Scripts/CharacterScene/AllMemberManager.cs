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

    public GameObject characterMemberPanel; // 캐릭터 프리셋
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
                    cha.lv);
                characterCount -= 1;
                allMembersPanel.Add(temp);
            }
            else // 육성재료
            {

            }
            
            
            
        }
    }

    public void ArrayConditionCharacter(bool character, bool train,
        bool fiveStar, bool fourStar, bool threeStar, bool twoStar, bool oneStar,
        bool red, bool blue, bool green, bool yellow, bool pupple)
    {
        arrayMemberPanel.Clear();

        int allPanelCount = allMembersPanel.Count;
        
        for(int j = 0; j < allPanelCount; j++)
        {
            allMembersPanel[j].SetActive(false);
        }
        
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

        int arrayCount = arrayMemberPanel.Count;
        
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

        for(int k = 0; k < arrayCount; k++)
        {
            arrayMemberPanel[k].SetActive(true);
        }
    }
}
