using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainingObjectMemberPanel : MonoBehaviour
{
    private string[] edgeColorArray = new string[5] { "#FF4949", "#4A60FF", "#55FF4A", "#F3FF4A", "#9D4AFF" };
    private string[] levelColorArray = new string[5] { "#FF7C7C", "#7C8DFF", "#49C27C", "#FFD426", "#B57CFF" };
    public Image edgeColor;
    public Image stars;
    public Image color;
    public Image countImage;
    public TextMeshProUGUI count;

    public void SetTrainingObjectMemberPanel(int colorInt, Sprite starImage, Sprite colorImage, int count)
    {
        Color hexEdgeColor;
        Color hexLevelColor;
        ColorUtility.TryParseHtmlString(edgeColorArray[colorInt], out hexEdgeColor);
        edgeColor.color = hexEdgeColor;
        stars.sprite = starImage;
        color.sprite = colorImage;
        ColorUtility.TryParseHtmlString(levelColorArray[colorInt], out hexLevelColor);
        countImage.color = hexLevelColor;
        this.count.text = "X " + count;
    }

    public void setCount(int count)
    {
        this.count.text = "X " + count;
    }
}
