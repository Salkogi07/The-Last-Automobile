using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameManager gm;
    private Stage1_UIManager uiManager;
    bool finish = false;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<Stage1_UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!finish)
        {
            if (other.tag == "Player")
            {
                uiManager.FinishGameWin();
                gm.coin += 500;
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
