using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ResultManager : MonoBehaviour
{
    public RectTransform content;
    public GameObject characterPanelPrefab;

    private List<Character> gachaResult;
    
    // Start is called before the first frame update
    void Start()
    {
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
                cha.colorImage, 
                cha.characterImage, 
                cha.starsImage, 
                cha.hp,
                cha.attack,
                cha.heal);
        }

        gachaResult.Clear(); // ��� ����Ʈ �ʱ�ȭ
        ChaGachaUI.result.Clear(); // ��� ����Ʈ �ʱ�ȭ
    }
}
