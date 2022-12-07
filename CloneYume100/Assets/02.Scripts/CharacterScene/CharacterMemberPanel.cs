using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMemberPanel : MonoBehaviour, IPointerExitHandler
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
    public TrainingObject trObj;

    public int rare;
    public int colorNum;
    public int getOrderNum;
    public int lv;

    public void SetCharacterMemberPanel(Character cha)
    {
        code = 0;
        this.cha = cha;
        rare = cha.rare;
        colorNum = (int)cha.color;
        getOrderNum = cha.getOrderNum;
        Color hexEdgeColor;
        Color hexLevelColor;
        ColorUtility.TryParseHtmlString(edgeColorArray[colorNum], out hexEdgeColor);
        edgeColor.color = hexEdgeColor;
        this.characterImage.sprite = cha.characterImage;
        stars.sprite = cha.starsImage;
        color.sprite = cha.colorImage;
        ColorUtility.TryParseHtmlString(levelColorArray[colorNum], out hexLevelColor);
        levelImage.color = hexLevelColor;
        lv = cha.lv;

        level.text = "Lv : " + lv;
    }

    public void SetTrainingObjectMemberPanel(TrainingObject trObj, Sprite characterImage, Sprite starImage, Sprite colorImage)
    {
        code = 1;
        this.trObj = trObj;
        Color hexEdgeColor;
        Color hexLevelColor;
        ColorUtility.TryParseHtmlString(edgeColorArray[(int)cha.color], out hexEdgeColor);
        edgeColor.color = hexEdgeColor;
        this.characterImage.sprite = characterImage;
        stars.sprite = starImage;
        color.sprite = colorImage;
        ColorUtility.TryParseHtmlString(levelColorArray[(int)cha.color], out hexLevelColor);
        levelImage.color = hexLevelColor;

        level.text = "X 1";
    }
    public void setCount(int count)
    {
        level.text = "X " + count;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SceneManager.LoadScene("CharacterInfo");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }
}
