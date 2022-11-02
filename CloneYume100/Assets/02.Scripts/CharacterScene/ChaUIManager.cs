using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChaUIManager : MonoBehaviour
{
    public Button backBtn;
    public Button representBtn;
    public Button organizationBtn;
    public Button trainingBtn;
    public Button allMemberBtn;
    public Button destroyBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(() => MoveHome());
        allMemberBtn.onClick.AddListener(() => MoveAllMember());
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

    private void MoveAllMember()
    {
        SceneManager.LoadScene("AllMemberScene");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }
}
