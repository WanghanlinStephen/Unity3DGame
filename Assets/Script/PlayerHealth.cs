using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerHealth: MonoBehaviour
{
    [SerializeField] int startingHealth =100;
    [SerializeField] float timeSinceLastHit =2f;
    [SerializeField] private int currentHealth;
    [SerializeField] private Slider healthSlider;
    //used to control the number of times a character is playing.
    private float timer = 0f;
    private CharacterController characterController;
    private Animator anim;
    private AudioSource audio;

    //get and set function for health
    public int CurrentHealth{
        get{return currentHealth;}
        set{
            if(value<0){
                currentHealth=0;
            }
            else{
                currentHealth=value;
            }
        }
    }
    

    void Awake(){
        Assert.IsNotNull(healthSlider);
    }
    
    // Start is called before the first frame update
        void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        currentHealth = startingHealth;
        audio=GetComponent<AudioSource>();
        //blood=GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //update the time variable
        timer+=Time.deltaTime;
    }
    //1:set the isTrigger on the box collider you want to collide with 
    //2:when the box collider collide with each other, the function OnTriggerEnter will trigger. 
    void OnTriggerEnter(Collider other){
        if(timer>=timeSinceLastHit && !GameManager.instance.GameOver){
            if(other.tag =="Weapon"){
                takeHit();
                //loop
                timer=0;
            }
        }
    }
    void takeHit(){
        if(currentHealth>0){
            //1:check whether the game will end
            GameManager.instance.PlayerHit(currentHealth);
            //2:Play Hurt animation
            anim.Play("Hurt");
            currentHealth -=10;
            healthSlider.value=currentHealth;
            audio.PlayOneShot(audio.clip);
            //blood.Play();
        }
        if(currentHealth <=0){
            killPlayer();
        }
    }
    public void PowerUpHealth(){
        if(currentHealth<=70){
            CurrentHealth+=30;
        }else if(currentHealth<startingHealth){
            CurrentHealth=startingHealth;
        }
        healthSlider.value=currentHealth;
    }
    public void recovery(){
        CurrentHealth=100;
        healthSlider.value=currentHealth;
        characterController.enabled = true;
    }
    void killPlayer(){
        GameManager.instance.PlayerHit(currentHealth);
        //set the Trigger for Die;
        anim.SetTrigger("HeroDie");
        //Ensure no body is able to move;
        characterController.enabled = false;
       // blood.Play();
        
    }
}
