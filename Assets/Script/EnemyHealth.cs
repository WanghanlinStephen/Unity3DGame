using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth =20;
    //确保下次表现受伤伤害时相隔0.5s
    [SerializeField] private float timeSinceLastHit=0.5f;
    //尸体消失时间
    [SerializeField] private float disappearSpeed=2f;
    [SerializeField] private Slider healthSlider;
    private AudioSource audio;
    private float timer=0f;
    private Animator anim;
    //确保enemy不会追赶hero
    private NavMeshAgent nav;
    private bool isAlive;
    private Rigidbody rigidBody;
    private CapsuleCollider capsuleCollider;
    private bool disappearEnemy=false;
    private int currentHealth;
    private ParticleSystem blood;
    //get functions  
    public bool IsAlive{
        get{return isAlive; }
    }
    void Awake(){
        Assert.IsNotNull(healthSlider);
    }


    // Start is called before the first frame update
    void Start()
    {
        //add the initial game object into the list
        GameManager.instance.RegisterEnemy(this);
        rigidBody= GetComponent<Rigidbody>();
        capsuleCollider=GetComponent<CapsuleCollider>();
        nav=GetComponent<NavMeshAgent>();
        anim=GetComponent<Animator>();
        audio=GetComponent<AudioSource>();
        isAlive=true;
        currentHealth=startingHealth;
        //blood=GetComponentInChildren<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // 把enemy向下移动消失
        if(disappearEnemy){
            transform.Translate(-Vector3.up*disappearSpeed*Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other){
        if(timer>=timeSinceLastHit && !GameManager.instance.GameOver){
            //当受到enemy的攻击的时候
            if(other.tag == "PlayerWeapon"){
                audio.PlayOneShot(audio.clip);
                takeHit();
                //reset the timer;
                timer=0;
            }
        }
    }
    void takeHit(){
        if(currentHealth>0){
            anim.Play("Hurt");
            currentHealth-=10;
            healthSlider.value=currentHealth;
            //blood.Play();
        }
        if(currentHealth<=0){
            capsuleCollider.enabled = false;
            isAlive =false;
            KillEnemy();
        }
    }
    //清空当前的怪物
    

    public static void RemoveEnemy()
    {
        print("The enemy has been reached");
        //GameManager.instance.enemies2.Clear();
        List<GameObject> enemies = GameManager.instance.enemyCollection;
        if (enemies.Count == 0)
        {
            print("The list is Null !!!!!!!!!!!!!!!!");
            
        }
        else
        {
            print("The list is not null !!!!!!!!!!!!");
        }
        print("The list contains " + enemies.Count + " Enemy !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        foreach (GameObject enemy in enemies)
        {
            /*
            Animator ani = enemy.GetComponent<Animator>();
            ani.Play("Idle");
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            agent.enabled = false;
            */
            Destroy(enemy);
            print("The enemy has been killed");
        }
    }

    

    void KillEnemy(){
        GameManager.instance.KilledEnemy(this);
        capsuleCollider.enabled=false;
        nav.enabled=false;
        anim.SetTrigger("EnemyDie");
        //其是说明game object不能不能动了
        rigidBody.isKinematic=true;
        //blood.Play();
        
        StartCoroutine(removeEnemy());
    }
    IEnumerator removeEnemy(){
        yield return new WaitForSeconds(4f);
        disappearEnemy=true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
