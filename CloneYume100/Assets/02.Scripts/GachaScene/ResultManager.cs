using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ResultManager : MonoBehaviour
{
    public Sprite[] rareImage; // 레어도 이미지
    public Sprite[] colorImage; // 속성 이미지

    public Sprite[] oneImage; // 1성 캐릭터 이미지 리스트
    public Sprite[] twoImage; // 2성 캐릭터 이미지 리스트
    public Sprite[] threeImage; // 3성 캐릭터 이미지 리스트
    public Sprite[] fourImage; // 4성 캐릭터 이미지 리스트
    public Sprite[] fiveImage; // 5성 캐릭터 이미지 리스트

    private Dictionary<int, Sprite[]> characterDic; // 위의 레어도에 따른 캐릭터 이미지 리스트와 레어도를 연결지은 딕셔너리

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

        gachaResult.Clear(); // 결과 리스트 초기화
        ChaGachaUI.result.Clear(); // 결과 리스트 초기화
    }
}
