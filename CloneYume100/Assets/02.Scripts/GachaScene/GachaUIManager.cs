using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GachaUIManager : MonoBehaviour
{
    public Button backBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(() => MoveHome());
    }

    private void MoveHome()
    {
        SceneManager.LoadScene("Main");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }
}
