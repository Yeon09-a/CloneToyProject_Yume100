using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChaGachaUI : MonoBehaviour
{
    public Button valueBtn;
    public Button oneTimeBtn;
    public Button tenTimeBtn;

    void Start()
    {
        valueBtn.onClick.AddListener(() => valueSceneMove());
        oneTimeBtn.onClick.AddListener(() => resultMove());
        tenTimeBtn.onClick.AddListener(() => resultMove());
    }

    private void valueSceneMove() // 출현 캐릭터 화면 이동
    {
        SceneManager.LoadScene("GachaValue");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }

    private void resultMove() // 뽑기 결과 화면 이동
    {
        SceneManager.LoadScene("GachaResult");
    }
}
