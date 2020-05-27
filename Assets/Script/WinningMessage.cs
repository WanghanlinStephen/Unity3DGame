using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningMessage : MonoBehaviour
{
    public Button OK;
    public static bool stopEnemy = false;
    public void OnOK()
    {
        PlayerController.instance.update = false;
        PlayerController.instance.transform.position = new Vector3(151.29f, -8.49f, 24.41f);
        PlayerController.instance.playerHealth.recovery();
        stopEnemy = true;
        this.gameObject.SetActive(false);
    }
}
