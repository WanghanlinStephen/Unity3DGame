using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Initialize the distance
    [SerializeField] private float range=5f;
    //Initialize the time of attack
    [SerializeField] private float timeBetweenAttck=1f;
    private Animator anim;
    private GameObject player;
    private bool playerInRange;
    private BoxCollider[] weaponColliders;
    private EnemyHealth enemyHealth;
    public AudioClip EnemyWin;
    
    


    //Start is called before the first frame update
    void Start()
    {

        //Get the weapon list
        weaponColliders = GetComponentsInChildren<BoxCollider>();
         //Get the player component
         player=GameManager.instance.Player;
         //Get the animator component
         anim=GetComponent<Animator>();
         //call the attack() function
         StartCoroutine(attack());
         enemyHealth=GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the position information
        if(Vector3.Distance(transform.position,player.transform.position)<range && enemyHealth.IsAlive){
            playerInRange=true;
        }else{
            playerInRange=false;
        }
        
    }
    //Initialize the play attck functions
    IEnumerator attack(){
        if(playerInRange && !GameManager.instance.GameOver){
            Debug.Log("playerInRange:" + playerInRange + "  GameOver:" + GameManager.instance.GameOver);
            anim.Play("Attack");
            //wait for a few seconds
            yield return new WaitForSeconds(timeBetweenAttck);
        }
        /*else if(GameManager.instance.GameOver){
            AudioSource audio =GetComponent<AudioSource>();
            audio.PlayOneShot(EnemyWin);
            NumberOfFailed++;
        }*/
        //recursively call the functions
        yield return null;
        StartCoroutine(attack());
    }
    public void EnemyBeginAttack(){
        foreach(var weapon in weaponColliders){
            //enable the weapon when the enemy release the attack
            weapon.enabled=true;
        }
    }
    public void EnemyEndAttack(){
        foreach(var weapon in weaponColliders){
            //enable the weapon when the enemy release the attack
            weapon.enabled=false;
        }
    }
}
