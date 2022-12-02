using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemberArray : MonoBehaviour
{
    public static List<CharacterMemberPanel> allMembersPanel = new List<CharacterMemberPanel>(); // 만든 오브젝트의 Panel 리스트(가장 먼저 만들어진 CharacterPanel이 앞번호로 온다.)(입수 순)

    public GameObject characterMemberPanel; // 캐릭터 프리팹
    public GameObject trainingObjectMemberPanel; // 육성 재료 프리팹
    public RectTransform content;

    public TextMeshProUGUI memberCount; // 멤버 수 UI
    private int count; // 멤버 수
    private int maxCount = 100; // 최대 멤버 수

    private void Start()
    {
        count = AllMemberManager.allCharacters.Count + AllMemberManager.allTrainingObjects.Count;
        if (count <= maxCount)
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
        else if (count > 1)
        {
            int lineCount = 0; // 스크롤의 content의 크기를 조절하기 위해 필요
            if (count % 5 == 0)
            {
                lineCount = count / 5;
            }
            else
            {
                lineCount = (count / 5) + 1;
            }
            content.sizeDelta = new Vector2(content.sizeDelta.x, 120 + (lineCount - 1) * 140);
        }

        int objectCount = AllMemberManager.allObjectsOrder.Count;
        int characterCount = AllMemberManager.allCharacters.Count;
        int trainingObjectCount = AllMemberManager.allTrainingObjects.Count;

        for (int i = objectCount - 1; i >= 0; i--) // 갖고있는 캐릭터의 panel 생성(가장 최근에 추가된 캐릭터가 가장 먼저 오도록)
        {
            if (AllMemberManager.allObjectsOrder[i] == 0) // 캐릭터
            {
                CharacterMemberPanel temp = Instantiate(characterMemberPanel, content).GetComponent<CharacterMemberPanel>();
                Character cha = AllMemberManager.allCharacters[characterCount - 1];
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
}
