using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllMemUIManager : MonoBehaviour
{
    public Button backBtn;
    public Button arrayBtn;

    public GameObject arrayPanel;

    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(() => MoveCharacter());
        arrayBtn.onClick.AddListener(() => OpenArrayPanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void MoveCharacter()
    {
        SceneManager.LoadScene("CharacterScene");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }

    private void OpenArrayPanel()
    {
        arrayPanel.SetActive(true);
    }
}
