using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPowerUp : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    // Start is called before the first frame update
    private int PlayerEnergy;
    void Start()
    {
        player=GameManager.instance.Player;
        playerController=player.GetComponent<PlayerController>();
        PlayerEnergy=playerController.CurrentEnergy;
        GameManager.instance.RegisterPowerUp();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject==player){
            playerController.PowerUpEnergy();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
         
    }
}
