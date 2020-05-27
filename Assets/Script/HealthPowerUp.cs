using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Health is working");
        player=GameManager.instance.Player;
        playerHealth=player.GetComponent<PlayerHealth>(); 
        GameManager.instance.RegisterPowerUp();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject==player){
            playerHealth.PowerUpHealth();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
         
    }
}
