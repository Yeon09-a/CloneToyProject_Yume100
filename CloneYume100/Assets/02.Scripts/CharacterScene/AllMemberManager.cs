using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllMemberManager : MonoBehaviour
{
    static public List<Character> allMembers = new List<Character>(); // �÷��̾ ������ �ִ� ĳ���͵� ����Ʈ

    public GameObject characterMemberPanel; // ĳ���� ������
    public RectTransform content;

    public TextMeshProUGUI memberCount; // ��� �� UI
    private int count; // ��� ��
    private int maxCount = 100; // �ִ� ��� ��

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
            int lineCount = 0; // ��ũ���� content�� ũ�⸦ �����ϱ� ���� �ʿ�
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

        for (int i = count - 1; i >= 0; i--) // �����ִ� ĳ������ panel ����
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
