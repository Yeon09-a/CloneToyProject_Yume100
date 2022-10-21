using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultValueUIManager : MonoBehaviour
{
    public Button okBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        okBtn.onClick.AddListener(() => BackMove());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BackMove()
    {
        SceneManager.LoadScene("GachaScene");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }
}
