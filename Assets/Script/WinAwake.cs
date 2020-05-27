using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAwake : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameWin)
        {
            PlayerController.instance.GameWin();
            EnemyHealth.RemoveEnemy();
            this.transform.Find("Popup").gameObject.SetActive(true);
        }

    }
}
