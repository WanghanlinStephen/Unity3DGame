using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DyingMessage : MonoBehaviour
{
    public Button Try;
    public static bool stopEnemy = false;
    public void OnTry()
    {
        PlayerController.instance.update = false;
        PlayerController.instance.playerHealth.recovery();
        PlayerController.instance.transform.position = new Vector3(151.29f, -8.49f, 24.41f);
        stopEnemy = true;
        this.gameObject.SetActive(false);
    }
}
