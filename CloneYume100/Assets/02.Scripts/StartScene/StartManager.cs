using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1 && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene("MainUI");
                SceneManager.LoadScene("Main", LoadSceneMode.Additive);
            }
        }
    }
}
