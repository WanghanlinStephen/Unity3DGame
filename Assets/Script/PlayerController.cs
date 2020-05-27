using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{ 
    public static PlayerController instance;
    public List<string> backPack = new List<string>(); //use to store things in backpack
    [SerializeField] int startingEnergy =100;
    [SerializeField] private int currentEnergy;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float moveSpeed= 5.0f;
    [SerializeField] private Slider EnergySlider;
    private CharacterController characterController;
    private Vector3 currentLookTarget = Vector3.zero;
    
    //use to control the animator
    private Animator anim;
    //for storing the weapon of the characters
    private BoxCollider[] swordColliders;

    public bool update;
    private int count=0;
    private int NumberOfPlay=0;
    private AudioSource audio;
    public AudioClip winSound;
    public AudioClip EnemyWin;
    private GameObject player;
    public PlayerHealth playerHealth;
    public static int NumberOfWins=0;
    public static int NumberOfFailed=0;
    public static bool BOSS1;
    public static bool BOSS2;
    public static bool BOSS3;
    public static bool BOSS4;
    public static bool Fail1 = false;
    public static bool Fail2 =false;
    public static bool Fail3 =false;



    public bool GameStart =false;

     public int CurrentEnergy{
        get{return currentEnergy;}
        set{
            if(value<0){
                currentEnergy=0;
            }
            else{
                currentEnergy=value;
            }
        }
    }
     void Awake(){
        //initizlize PlayerController instance
        if(instance== null){
            instance = this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    } 
    void Start()
    { 
        player=GameManager.instance.Player;
        playerHealth=player.GetComponent<PlayerHealth>(); 
        characterController= GetComponent<CharacterController>();
        anim= GetComponent<Animator>();
        swordColliders= GetComponentsInChildren<BoxCollider>();
        currentEnergy = startingEnergy;
        backPack.Add("Hair1");
        backPack.Add("Belt1");
        backPack.Add("Cloth1");
        backPack.Add("ShoulderPad1");
        backPack.Add("Glove1");
        backPack.Add("Shoe1");
        audio =GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // 从Class NPC里的两个string(即newEquipment与newEquipment2)中获得新加进背包装备的名字（有两个是方便glove与shoe同时加入）
        if (!backPack.Contains(NPC.newEquipment)) backPack.Add(NPC.newEquipment);
        if (!backPack.Contains(NPC.newEquipment2)) backPack.Add(NPC.newEquipment2);

        if (!GameManager.instance.GameOver)
        {
            if (!update)
            {
                if (count < 30)
                {
                    count++;
                    return;
                }
                count = 0;
                update = true;
            }
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            characterController.SimpleMove(moveDirection * moveSpeed);
            if (moveDirection == Vector3.zero)
            {
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                anim.Play("Attack");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && currentEnergy > 0)
            {
                anim.Play("Attack2");
                currentEnergy -= 10;
            }
            EnergySlider.value = currentEnergy;
            GameWinRecorder(NumberOfWins, NumberOfFailed);
        }
        //控制胜利后的动作和音效
        /*
        if(GameManager.instance.gameWin){
            anim.Play("Victory");
            NumberOfPlay++;
            audio.PlayOneShot(winSound);
            print("The music is working");
        }
        if(GameManager.instance.GameOver){
            audio.PlayOneShot(EnemyWin);
            NumberOfFailed++;
            GameWinRecorder(NumberOfWins,NumberOfFailed);
        }*/
    }
    void FixedUpdate(){

        if (!GameManager.instance.GameOver){
         RaycastHit hit;
         //定义layser射线的位置
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         //画出layser射线的图像
         Debug.DrawRay(ray.origin,ray.direction*500,Color.blue);
         if(Physics.Raycast(ray,out hit,500,layerMask,QueryTriggerInteraction.Ignore)){
            //重新定义currentLookTarget为layser的指向方向
            if(hit.point != currentLookTarget){
                currentLookTarget =hit.point;
            }
            //定义Vector3() xz,根据layser的方向进行改变  y保持不变
         Vector3 targetPosition = new Vector3(hit.point.x,transform.position.y,hit.point.z);
         Quaternion rotation = Quaternion.LookRotation(targetPosition-transform.position);
         //流畅旋转人物
         transform.rotation=Quaternion.Lerp(transform.rotation,rotation,Time.deltaTime*10f);
        } 
    }
    }
    public void AttackStart(){
        foreach(BoxCollider weapon in  swordColliders){
            weapon.enabled=true;
        }
    }
    public void AttackEnd(){
        foreach(BoxCollider weapon in  swordColliders){
            weapon.enabled=false;
        }
    }
    public void PowerUpEnergy(){
        if(currentEnergy<=70){
            CurrentEnergy+=30;
        }else if(currentEnergy<startingEnergy){
            CurrentEnergy=startingEnergy;
        }
        EnergySlider.value=currentEnergy;
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        //check whehther the game should start
         if (other.tag == "StartPoint")
        {
            GameStart=true;
            Debug.Log(GameStart);
        }

         /*
        if (!NPC.Court1|| (NPC.Court1Passed && (!NPC.Court2))|| (NPC.Court2Passed && (!NPC.Court3))||(NPC.Court3Failed && (!NPC.Court4)) || (NPC.Court4Passed && (!NPC.Court5)) || (NPC.Court5Passed && (!NPC.Court6)) || (NPC.Court6Passed && (!NPC.Court7)) || (NPC.Court7Passed && (!NPC.Court8)) || (NPC.Court8Passed && (!NPC.Court9)) || (NPC.Court9Passed && (!NPC.Court10)) || (NPC.Court10Passed && (!NPC.Court11)) || (NPC.Court11Passed && (!NPC.Court12)) || (NPC.Court12Failed && (!NPC.Court13)) || (NPC.Court13Passed && (!NPC.Court14)) || (NPC.Court14Passed && (!NPC.Court15)) || (NPC.Court15Passed && (!NPC.Court16)) || (NPC.Court16Passed && (!NPC.Court17)) || (NPC.Court17Failed && (!NPC.Court18)) || (NPC.Court18Passed && (!NPC.Court19)) || (NPC.Court19Passed && (!NPC.Court20)) )
        {
            return;
        }*/
        
        if (other.transform.name == "FootballEntrance")
        {
            update = false;
            Vector3 vector3 = new Vector3(-43.01f, -7.52f, 93.92f);
            transform.position = vector3;
            

        }
        else if (other.transform.name == "BasketballEntrance")
        {
            update = false;
            Vector3 vector3 = new Vector3(-186f, -7.52f, 94f);
            transform.position = vector3;
            
        }
        else if (other.transform.name == "TennisEntrance")
        {
            update = false;
            Vector3 vector3 = new Vector3(-45f, -7.52f, 235f);
            transform.position = vector3;
        }
        else if (other.transform.name == "VolleyballEntrance")
        {
            update = false;
            Vector3 vector3 = new Vector3(-183f, -7.52f, 237f);
            transform.position = vector3;
        }
        else if (other.transform.name == "Unopen")
        {
            print("Unopen");
        }

        
    }


   
        
    public void GameWin()
    {
        //GameManager.instance.GameDifficulty = GameManager.instance.GameDifficulty + 3;

        //记录胜利次数
        NumberOfWins++;
        //GameWinRecorder(NumberOfWins,NumberOfFailed);
        //播放胜利音乐
        anim.Play("Victory");
        NumberOfPlay++;
        audio.PlayOneShot(winSound);
        print("The music is working");
        GameManager.instance.gameWin = false;
        GameManager.instance.gameOver = false;
    }

    public void GameOver()//need to finish
    {
        //新添加
        audio.PlayOneShot(EnemyWin);
        NumberOfFailed++;
        //GameWinRecorder(NumberOfWins,NumberOfFailed);

        GameManager.instance.gameWin = false;
        GameManager.instance.gameOver = false;
    }

    public void Change(string name)
    {
        if (name.StartsWith("Belt"))
        {
            this.transform.Find("Belt1").gameObject.SetActive(false);
            this.transform.Find("Belt2").gameObject.SetActive(false);
            this.transform.Find("Belt3").gameObject.SetActive(false);
        }
        else if (name.StartsWith("Cl"))
        {
            this.transform.Find("Cloth1").gameObject.SetActive(false);
            this.transform.Find("Cloth2").gameObject.SetActive(false);
            this.transform.Find("Cloth3").gameObject.SetActive(false);
            this.transform.Find("Cloth4").gameObject.SetActive(false);
            this.transform.Find("Cloth5").gameObject.SetActive(false);
            this.transform.Find("Cloth6").gameObject.SetActive(false);
            this.transform.Find("Cloth7").gameObject.SetActive(false);

        }
        else if (name.StartsWith("Cr"))
        {
            this.transform.Find("Crown1").gameObject.SetActive(false);
            this.transform.Find("Crown2").gameObject.SetActive(false);
            this.transform.Find("Crown3").gameObject.SetActive(false);
            this.transform.Find("Crown4").gameObject.SetActive(false);
        }
        else if (name.StartsWith("G"))
        {
            this.transform.Find("Glove1").gameObject.SetActive(false);
            this.transform.Find("Glove2").gameObject.SetActive(false);
            this.transform.Find("Glove3").gameObject.SetActive(false);
            this.transform.Find("Glove4").gameObject.SetActive(false);
            this.transform.Find("Glove5").gameObject.SetActive(false);
            this.transform.Find("Glove6").gameObject.SetActive(false);

        }
        else if (name.StartsWith("Ha"))
        {
            this.transform.Find("Hair1").gameObject.SetActive(false);
            this.transform.Find("Hair2").gameObject.SetActive(false);
            this.transform.Find("Hair3").gameObject.SetActive(false);
            this.transform.Find("Hair4").gameObject.SetActive(false);
            this.transform.Find("Hair5").gameObject.SetActive(false);
        }
        else if (name.StartsWith("He"))
        {
            this.transform.Find("Helm1").gameObject.SetActive(false);
            this.transform.Find("Helm2").gameObject.SetActive(false);
            this.transform.Find("Helm3").gameObject.SetActive(false);
            this.transform.Find("Helm4").gameObject.SetActive(false);
            this.transform.Find("Helm5").gameObject.SetActive(false);
            this.transform.Find("Helm7").gameObject.SetActive(false);
            this.transform.Find("Helm6").gameObject.SetActive(false);
        }
        else if (name.StartsWith("Shoe"))
        {
            this.transform.Find("Shoe1").gameObject.SetActive(false);
            this.transform.Find("Shoe2").gameObject.SetActive(false);
            this.transform.Find("Shoe3").gameObject.SetActive(false);
            this.transform.Find("Shoe4").gameObject.SetActive(false);
            this.transform.Find("Shoe5").gameObject.SetActive(false);
            this.transform.Find("Shoe6").gameObject.SetActive(false);
        }
        else if (name.StartsWith("S"))
        {
            this.transform.Find("ShoulderPad1").gameObject.SetActive(false);
            this.transform.Find("ShoulderPad2").gameObject.SetActive(false);
            this.transform.Find("ShoulderPad3").gameObject.SetActive(false);
            this.transform.Find("ShoulderPad4").gameObject.SetActive(false);
            this.transform.Find("ShoulderPad5").gameObject.SetActive(false);
            this.transform.Find("ShoulderPad6").gameObject.SetActive(false);
        }
        else if (name.StartsWith("Back"))
        {
            Transform T = GameObject.FindGameObjectWithTag("root").transform;
            T.Find("BackPack1").gameObject.SetActive(false);
            T.Find("BackPack2").gameObject.SetActive(false);
            T.Find("Backpack3").gameObject.SetActive(false);
            T.Find(name).gameObject.SetActive(true);
        }
        else
        {
            return;
        }
        if (!name.StartsWith("Back"))
        {
            this.transform.Find(name).gameObject.SetActive(true);
        }
    }
    
    public void GameWinRecorder(int NumberOfWins, int NumberOfFailed)
    {


        if (NumberOfWins == 1 /*&& NumberOfFailed == 0*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court1Passed = true;
            GameManager.instance.enemies2.Clear();
            GameManager.instance.GameDifficulty = 2;
        }
        else if (NumberOfWins == 2 && Fail1 == false  /*&& NumberOfFailed == 0*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            Fail1 = true;
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court2Passed = true;
            GameManager.instance.enemies2.Clear();
            GameManager.instance.GameDifficulty = 15;
        }
        else if (NumberOfWins == 2 && NumberOfFailed >0 && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court3Failed = true;
            GameManager.instance.enemies2.Clear();
            GameManager.instance.GameDifficulty = 5;
        }
        else if (NumberOfWins == 3 /*&& NumberOfFailed == 1*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            BOSS1 = true;
            GameManager.boss1=0;
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court4Passed = true;
            GameManager.instance.GameDifficulty = 5;
        }
        else if (NumberOfWins == 4 /*&& NumberOfFailed == 1*/ &&(WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {

            BOSS1 = false;
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court5Passed = true;
            GameManager.instance.GameDifficulty = 6;
        }
        else if (NumberOfWins == 5 /*&& NumberOfFailed == 1*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court6Passed = true;
            GameManager.instance.GameDifficulty = 7;
        }
        else if (NumberOfWins == 6 /*&& NumberOfFailed == 1*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court7Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 7 /*&& NumberOfFailed == 1*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court8Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 8 /*&& NumberOfFailed == 1*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            BOSS2 = true;
            GameManager.boss2 = 0;
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court9Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 9 /*&& NumberOfFailed == 1*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            BOSS2 = false;
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court10Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 10 /*&& NumberOfFailed == 1*/&&Fail2==false&& (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            Fail2 = true;
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court11Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 10 /*&& NumberOfFailed == 2*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court12Failed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 11 /*&& NumberOfFailed == 2*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court13Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 12 /*&& NumberOfFailed == 2*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            BOSS3 = true;
            GameManager.boss3 = 0;
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court14Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 13 /*&& NumberOfFailed == 2*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            BOSS3 = false;
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court15Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 14 &&Fail3==false/*&& NumberOfFailed == 2*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            Fail3 = true;
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court16Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 14 /*&& NumberOfFailed == 3*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court17Failed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 15 /*&& NumberOfFailed == 3*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            NPC.Court18Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 16 /*&& NumberOfFailed == 3*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            BOSS4 = true;
            GameManager.boss4 = 0;
            NPC.Court19Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
        else if (NumberOfWins == 17 /*&& NumberOfFailed == 3*/ && (WinningMessage.stopEnemy == true || DyingMessage.stopEnemy == true))
        {
            GameManager.instance.enemies2.Clear();
            WinningMessage.stopEnemy = false;
            DyingMessage.stopEnemy = false;
            BOSS4 = false;
            NPC.Court20Passed = true;
            GameManager.instance.GameDifficulty = 3;
        }
    }
}
