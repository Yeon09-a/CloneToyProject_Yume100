using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMemberPanel : MonoBehaviour
{
    private string[] edgeColorArray = new string[5] { "#FF4949", "#4A60FF", "#55FF4A", "#F3FF4A", "#9D4AFF" };
    private string[] levelColorArray = new string[5] { "#FF7C7C", "#7C8DFF", "#49C27C", "#FFD426", "#B57CFF" };
    public Image edgeColor;
    public Image characterImage;
    public Image stars;
    public Image color;
    public Image levelImage;
    public TextMeshProUGUI level;

    public void SetCharacterMemberPanel(int colorInt, Sprite characterImage, Sprite starImage, Sprite colorImage, int lv)
    {
        Color hexEdgeColor;
        Color hexLevelColor;
        ColorUtility.TryParseHtmlString(edgeColorArray[colorInt], out hexEdgeColor);
        Debug.Log(edgeColorArray[colorInt]);
        edgeColor.color = hexEdgeColor;
        this.characterImage.sprite = characterImage;
        stars.sprite = starImage;
        color.sprite = colorImage;
        ColorUtility.TryParseHtmlString(levelColorArray[colorInt], out hexLevelColor);
        levelImage.color = hexLevelColor;
        level.text = "Lv : " + lv;
    }
}
