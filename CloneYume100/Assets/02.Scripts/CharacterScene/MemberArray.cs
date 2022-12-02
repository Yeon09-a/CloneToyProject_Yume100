using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemberArray : MonoBehaviour
{
    public static List<CharacterMemberPanel> allMembersPanel = new List<CharacterMemberPanel>(); // ���� ������Ʈ�� Panel ����Ʈ(���� ���� ������� CharacterPanel�� �չ�ȣ�� �´�.)(�Լ� ��)

    public GameObject characterMemberPanel; // ĳ���� ������
    public GameObject trainingObjectMemberPanel; // ���� ��� ������
    public RectTransform content;

    public TextMeshProUGUI memberCount; // ��� �� UI
    private int count; // ��� ��
    private int maxCount = 100; // �ִ� ��� ��

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
            int lineCount = 0; // ��ũ���� content�� ũ�⸦ �����ϱ� ���� �ʿ�
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

        for (int i = objectCount - 1; i >= 0; i--) // �����ִ� ĳ������ panel ����(���� �ֱٿ� �߰��� ĳ���Ͱ� ���� ���� ������)
        {
            if (AllMemberManager.allObjectsOrder[i] == 0) // ĳ����
            {
                CharacterMemberPanel temp = Instantiate(characterMemberPanel, content).GetComponent<CharacterMemberPanel>();
                Character cha = AllMemberManager.allCharacters[characterCount - 1];
                cha.getOrderNum = i;
                temp.SetCharacterMemberPanel(cha);
                characterCount -= 1;
                allMembersPanel.Add(temp);
            }
            else // �������
            {

            }



        }
    }
}
