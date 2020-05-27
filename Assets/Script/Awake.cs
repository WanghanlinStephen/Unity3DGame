using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awake : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver||timecountdown.FailBoss1==true|| timecountdown.FailBoss2 == true|| timecountdown.FailBoss3 == true|| timecountdown.FailBoss4 == true)
        {
            timecountdown.FailBoss1 = false;
            timecountdown.FailBoss2 = false;
            timecountdown.FailBoss3 = false;
            timecountdown.FailBoss4 = false;
            PlayerController.instance.GameOver();
            GameManager.instance.killedEnemies2.Clear();
            EnemyHealth.RemoveEnemy();
            this.transform.Find("Popup").gameObject.SetActive(true);
        }

    }
}
