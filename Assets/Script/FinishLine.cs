using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private Stage1_UIManager uiManager;
    bool finish = false;

    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<Stage1_UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!finish)
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
