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
    private List<CharacterMemberPanel> allMembersPanel = new List<CharacterMemberPanel>(); // ���� ������Ʈ�� Panel ����Ʈ(���� ���� ������� CharacterPanel�� �չ�ȣ�� �´�.)(�Լ� ��)
    private List<CharacterMemberPanel> arrayMemberPanel = new List<CharacterMemberPanel>(); // ���ĵ� panel ����Ʈ

    public GameObject characterMemberPanel; // ĳ���� ������
    public GameObject trainingObjectMemberPanel; // ���� ��� ������
    public RectTransform content;
    public RectTransform tempContent;

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
                CharacterMemberPanel temp = Instantiate(characterMemberPanel, content).GetComponent<CharacterMemberPanel>() ;
                Character cha = allCharacters[characterCount - 1];
                temp.SetCharacterMemberPanel(
                    cha,
                    cha.characterImage,
                    cha.starsImage,
                    cha.colorImage);
                characterCount -= 1;
                allMembersPanel.Add(temp);
            }
            else // �������
            {

            }
            
            
            
        }
    }

    // ǥ�� ���� �Լ�
    public void ArrayConditionCharacter(bool character, bool train, 
        bool fiveStar, bool fourStar, bool threeStar, bool twoStar, bool oneStar,
        bool red, bool blue, bool green, bool yellow, bool pupple)
    {
        arrayMemberPanel.Clear();

        int allPanelCount = allMembersPanel.Count;

        int arrayCount;

        for (int j = 0; j < allPanelCount; j++)
        {
            allMembersPanel[j].transform.SetParent(tempContent);
            allMembersPanel[j].gameObject.SetActive(false);
        }
        
        // ĳ����, ������� ǥ�� ����
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

        // ��� ǥ�� ����
        if (fiveStar || fourStar || threeStar || twoStar || oneStar)
        {
            List<CharacterMemberPanel> temp = new List<CharacterMemberPanel>();

            for (int m = 0; m < arrayCount; m ++)
            {
                if(arrayMemberPanel[m].code == 0) // ĳ������ ���
                {
                    if (fiveStar && arrayMemberPanel[m].cha.rare == 5)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (fourStar && arrayMemberPanel[m].cha.rare == 4)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (threeStar && arrayMemberPanel[m].cha.rare == 3)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (twoStar && arrayMemberPanel[m].cha.rare == 2)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (oneStar && arrayMemberPanel[m].cha.rare == 1)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                }
                else // ��������� ���
                {

                }
            }

            arrayMemberPanel = temp.ToList();
        }

        arrayCount = arrayMemberPanel.Count;

        // �Ӽ� ǥ�� ����
        if (red || blue || green || yellow || pupple)
        {
            List<CharacterMemberPanel> temp = new List<CharacterMemberPanel>();

            for (int m = 0; m < arrayCount; m++)
            {
                if (arrayMemberPanel[m].code == 0) // ĳ������ ���
                {
                    if (red && (int)(arrayMemberPanel[m].cha.color) == 0)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (blue && (int)(arrayMemberPanel[m].cha.color) == 1)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (green && (int)(arrayMemberPanel[m].cha.color) == 2)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (yellow && (int)(arrayMemberPanel[m].cha.color) == 3)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                    else if (pupple && (int)(arrayMemberPanel[m].cha.color) == 4)
                    {
                        temp.Add(arrayMemberPanel[m]);
                    }
                }
                else // ��������� ���
                {

                }
            }

            arrayMemberPanel = temp.ToList();
        }
    }

    public void ArrayOrderCharacter(bool ascending, 
        bool rare, bool color, bool level, bool getOrder)
    {
        // ���������� �������� ����
        if(rare) // ��� ����
        {
            RareArrayOrder(ref arrayMemberPanel, out int rareFiveCount, out int rareFourCount, out int rareThreeCount, out int rareTwoCount, out int rareOneCount);
        }
        else if(color) // �Ӽ� ����
        {

        }
        else if(level) // Lv ����
        {

        }
        else if(getOrder) // �Լ� �� ����
        {

        }

        if(ascending) // ��������
        {

        }
    }

    private void RareArrayOrder(ref List<CharacterMemberPanel> objectsList, out int fiveCount, out int fourCount, out int threeCount, out int twoCount, out int oneCount)
    {
        fiveCount = 0;
        fourCount = 0;
        threeCount = 0;
        twoCount = 0;
        oneCount = 0;
        
        count = objectsList.Count;
        int max;

        for(int i = 0; i < count - 1; i++)
        {
            max = i;
            for(int j = i + 1; j < count; j++)
            {
                if(objectsList[j].cha.rare > objectsList[max].cha.rare)
                {
                    max = j;
                }
            }

            /*CharacterMemberPanel temp = arrayMemberPanel[max];
            arrayMemberPanel.RemoveAt(max);
            arrayMemberPanel.Insert(max, arrayMemberPanel[i]);
            arrayMemberPanel.RemoveAt(i);
            arrayMemberPanel.Insert(i, temp);*/
            
            if(i != max)
            {
                CharacterMemberPanel temp = objectsList[max];
                objectsList[max] = objectsList[i];
                objectsList[i] = temp;
            }
        }

        for(int k = 0; k < count; k++)
        {
            if(arrayMemberPanel[k].cha.rare == 5)
            {
                fiveCount += 1;   
            }
            else if (arrayMemberPanel[k].cha.rare == 4)
            {
                fourCount += 1;
            }
            else if (arrayMemberPanel[k].cha.rare == 3)
            {
                threeCount += 1;
            }
            else if (arrayMemberPanel[k].cha.rare == 2)
            {
                twoCount += 1;
            }
            else if (arrayMemberPanel[k].cha.rare == 1)
            {
                oneCount += 1;
            }
        }
    }

    public void SetActiveMemberPanel()
    {
        int arrayCount = arrayMemberPanel.Count;

        // ��ũ���� content�� ũ�⸦ ����
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

        for (int k = 0; k < arrayCount; k++) // ���ĵ� panel�� Ȱ��ȭ
        {
            arrayMemberPanel[k].transform.SetParent(content);
            arrayMemberPanel[k].gameObject.SetActive(true);
        }
    }
}
