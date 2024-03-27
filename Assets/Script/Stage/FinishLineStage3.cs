using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineStage3 : MonoBehaviour
{
    private UIManager uiManager;
    bool finish = false;

    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!finish)
        {
            if (other.tag == "Player")
            {
                uiManager.FinishGameWin();
                finish = true;
            }
            else
            {
                uiManager.FinishGameLose();
                finish = true;
            }
        }
    }
}

