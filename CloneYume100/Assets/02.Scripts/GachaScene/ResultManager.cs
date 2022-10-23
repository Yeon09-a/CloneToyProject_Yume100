using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ResultManager : MonoBehaviour
{
    public Sprite[] rareImage; // ��� �̹���
    public Sprite[] colorImage; // �Ӽ� �̹���

    public Sprite[] oneImage; // 1�� ĳ���� �̹��� ����Ʈ
    public Sprite[] twoImage; // 2�� ĳ���� �̹��� ����Ʈ
    public Sprite[] threeImage; // 3�� ĳ���� �̹��� ����Ʈ
    public Sprite[] fourImage; // 4�� ĳ���� �̹��� ����Ʈ
    public Sprite[] fiveImage; // 5�� ĳ���� �̹��� ����Ʈ

    private Dictionary<int, Sprite[]> characterDic; // ���� ����� ���� ĳ���� �̹��� ����Ʈ�� ����� �������� ��ųʸ�

    public RectTransform content;
    public GameObject characterPanelPrefab;

    private List<Character> gachaResult;
    
    // Start is called before the first frame update
    void Start()
    {
        characterDic = new Dictionary<int, Sprite[]>() {
            {1, oneImage},
            {2, twoImage},
            {3, threeImage},
            {4, fourImage},
            {5, fiveImage}
        };
        gachaResult = ChaGachaUI.result.ToList();
        
        if(gachaResult.Count == 1)
        {
            content.sizeDelta = new Vector2(content.sizeDelta.x, 180);
        }
        else
        {
            content.sizeDelta = new Vector2(content.sizeDelta.x, 180 + (gachaResult.Count - 1) * 200);
        }

        for (int i = 0; i < gachaResult.Count; i++)
        {
            GameObject temp = Instantiate(characterPanelPrefab, content);
            Character cha = gachaResult[i];
            temp.GetComponent<CharacterPanel>().SetCharacterPanel(
                cha.chaName, 
                colorImage[((int)cha.color)], 
                characterDic[cha.rare][cha.characterNum], 
                rareImage[cha.rare - 1], 
                cha.hp,
                cha.attack,
                cha.heal);
        }

        gachaResult.Clear(); // ��� ����Ʈ �ʱ�ȭ
        ChaGachaUI.result.Clear(); // ��� ����Ʈ �ʱ�ȭ
    }
}
