using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllMemberManager : MonoBehaviour
{
    static public List<Character> allMembers = new List<Character>(); // 플레이어가 가지고 있는 캐릭터들 리스트

    public GameObject characterMemberPanel; // 캐릭터 프리셋
    public RectTransform content;

    public TextMeshProUGUI memberCount; // 멤버 수 UI
    private int count; // 멤버 수
    private int maxCount = 100; // 최대 멤버 수

    private void Start()
    {
        count = allMembers.Count;
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

        for (int i = count - 1; i >= 0; i--) // 갖고있는 캐릭터의 panel 생성
        {
            GameObject temp = Instantiate(characterMemberPanel, content);
            Character cha = allMembers[i];
            temp.GetComponent<CharacterMemberPanel>().SetCharacterMemberPanel(
                (int)cha.color,
                cha.characterImage,
                cha.starsImage,
                cha.colorImage,
                cha.lv);
        }
    }
}
