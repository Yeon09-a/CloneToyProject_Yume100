using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    public Button homeBtn;
    public Button characterBtn;
    public Button questBtn;
    public Button gachaBtn;

    // Start is called before the first frame update
    void Start()
    {
        homeBtn.onClick.AddListener(() => MoveHome());
        gachaBtn.onClick.AddListener(() => MoveGacha());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveHome()
    {
        SceneManager.LoadScene("Main");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }

    private void MoveGacha()
    {
        SceneManager.LoadScene("GachaScene");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }
}
