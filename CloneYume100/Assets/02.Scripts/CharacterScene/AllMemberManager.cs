using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AllMemberManager : MonoBehaviour
{
    static public List<int> allObjectsOrder = new List<int>(); // �÷��̾ ������ �ִ� ������Ʈ�� ����Ʈ
    static public List<Character> allCharacters = new List<Character>(); // �÷��̾ ������ �ִ� ĳ���� ����Ʈ
    static public List<TrainingObject> allTrainingObjects = new List<TrainingObject>(); // �÷��̾ ������ �ִ� ������� ����Ʈ
    private List<GameObject> allMembersPanel = new List<GameObject>(); // ���� ������Ʈ�� Panel ����Ʈ(���� ���� ������� CharacterPanel�� �չ�ȣ�� �´�.)(�Լ� ��)
    private List<GameObject> arrayMemberPanel = new List<GameObject>(); // ���ĵ� panel ����Ʈ

    public GameObject characterMemberPanel; // ĳ���� ������
    public RectTransform content;

    public TextMeshProUGUI memberCount; // ��� �� UI
    private int count; // ��� ��
    private int maxCount = 100; // �ִ� ��� ��

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

        int objectCount = allObjectsOrder.Count;
        int characterCount = allCharacters.Count;
        int trainingObjectCount = allTrainingObjects.Count;

        for (int i = objectCount - 1; i >= 0; i--) // �����ִ� ĳ������ panel ����(���� �ֱٿ� �߰��� ĳ���Ͱ� ���� ���� ������)
        {
            if(allObjectsOrder[i] == 0) // ĳ����
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
            else // �������
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
            int lineCount = 0; // ��ũ���� content�� ũ�⸦ �����ϱ� ���� �ʿ�
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
