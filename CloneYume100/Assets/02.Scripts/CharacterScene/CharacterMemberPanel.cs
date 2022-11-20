using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMemberPanel : MonoBehaviour
{
    public int code;
    
    private string[] edgeColorArray = new string[5] { "#FF4949", "#4A60FF", "#55FF4A", "#F3FF4A", "#9D4AFF" };
    private string[] levelColorArray = new string[5] { "#FF7C7C", "#7C8DFF", "#49C27C", "#FFD426", "#B57CFF" };
    public Image edgeColor;
    public Image characterImage;
    public Image stars;
    public Image color;
    public Image levelImage;
    public TextMeshProUGUI level;
    public Character cha;

    public void SetCharacterMemberPanel(Character cha, Sprite characterImage, Sprite starImage, Sprite colorImage)
    {
        this.cha = cha;
        Color hexEdgeColor;
        Color hexLevelColor;
        ColorUtility.TryParseHtmlString(edgeColorArray[(int)cha.color], out hexEdgeColor);
        edgeColor.color = hexEdgeColor;
        this.characterImage.sprite = characterImage;
        stars.sprite = starImage;
        color.sprite = colorImage;
        ColorUtility.TryParseHtmlString(levelColorArray[(int)cha.color], out hexLevelColor);
        levelImage.color = hexLevelColor;
        
        if(code == 0)
        {
            level.text = "Lv : " + cha.lv;
        }
        else
        {
            level.text = "X 1";
        }
    }

    public void setCount(int count)
    {
        level.text = "X " + count;
    }
}
