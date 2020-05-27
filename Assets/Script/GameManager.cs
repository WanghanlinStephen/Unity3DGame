using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Initialize an instance
    public static GameManager instance = null;
    //Initialize an game object
    [SerializeField] GameObject player;
    [SerializeField] int BossShowTime=5;
    [SerializeField] GameObject[] spawnpoints;
    [SerializeField] GameObject[] powerUpSpawns;
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject BOSS;
    [SerializeField] GameObject BOSS2;
    [SerializeField] GameObject BOSS3;

    [SerializeField] GameObject healthPowerUp;
    [SerializeField] GameObject speedPowerUp;

    [SerializeField] Text LevelText;
    [SerializeField] int maxPowerUps =4;
    [SerializeField] public static int difficulty =1;
    private AudioSource audio;
    public AudioClip backgroundMusic;
    //Reference to game over
    public bool gameWin= false;
    public bool gameOver= false;
    public int currentLevel;
    //创建怪物的空格
    private float generatedSpawnTime=1;
    private float currentSpawnTime=0;
    private float powerUpSpawnTime=5;
    private float currentPowerUpSpawnTime=0;
    private GameObject newEnemy;
    private GameObject newPowerup;
    private int powerups=0;
    public int BossNumberController = 0;

    public static int killed = 0;
    public static int boss1=0;
    public static int boss2=0;
    public static int boss3=0;
    public static int boss4=0;


    //创建enemy list
    public List<EnemyHealth> enemies = new List<EnemyHealth>();
    public List<EnemyHealth> enemies2 = new List<EnemyHealth>();

    public List<EnemyHealth> killedEnemies = new List<EnemyHealth>();
    public List<EnemyHealth> killedEnemies2 = new List<EnemyHealth>();
    public List<GameObject> enemyCollection = new List<GameObject>();

    //使用EnemyHealth 是因为会在enemyHealth当中调用这两个函数
    public void RegisterEnemy(EnemyHealth enemy){
        enemies.Add(enemy);
        enemies2.Add(enemy);
    }
    public void KilledEnemy(EnemyHealth enemy){
        killedEnemies.Add(enemy);
        killedEnemies2.Add(enemy);
    }
    public void RegisterPowerUp(){
        powerups++;
    }

    //Get functins
    public bool GameOver{
       get { return gameOver; }  
    }

    public bool GameWin{
        get { return gameWin; }
    }

    public int GameDifficulty{
        get { return difficulty;}
        set { difficulty = value; }
    }
   

    public GameObject Player{
        get{return player;}
    }

    //Run before start
    void Awake(){
        //initizlize GameManager instance
        if(instance== null){
            instance = this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    } 


    // Start is called before the first frame update
    void Start()
    {
        audio=GetComponent<AudioSource>();
        audio.Play();
        //call function spawn();
        StartCoroutine(spawn());
        StartCoroutine(powerUpSpawn());
        currentLevel=1;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnTime+=Time.deltaTime;
        currentPowerUpSpawnTime+=Time.deltaTime;
        //BOSSCheck();
        killed = killedEnemies2.Count;
    }

     
    //更新游戏是否结束
    public void PlayerHit(int currentHP){
         if(currentHP>0){
             
             gameOver=false;
         }else{
             
             gameOver=true;
         }
    }
    IEnumerator spawn(){
        //确保每隔一段时间进行创建检查
        if(currentSpawnTime>generatedSpawnTime){
            currentSpawnTime=0;
            //当场上的enemy的个数小于当前要求的值,并且玩家没有打赢游戏
            //修改
            print("The game win is:" + gameWin);
            print("The enemies2 acount" + enemies2.Count);
            print("The difficulty" + difficulty);
            
            if(enemies2.Count<difficulty && gameWin==false){
                
                //随机选取random spawnLocation 的位置
                int randomNumber=Random.Range(0,spawnpoints.Length-1);
                GameObject spawnLocation=spawnpoints[randomNumber];
                //随机选取random Enemy的人物
                if((PlayerController.BOSS1 && boss1 == 0)|| (PlayerController.BOSS2 && boss2 == 0)|| (PlayerController.BOSS3 && boss3 == 0)|| (PlayerController.BOSS4 && boss4 == 0))
                {

                    //特殊馆卡选择
                    if (PlayerController.BOSS1 && boss1 == 0)
                    {
                        newEnemy = Instantiate(BOSS) as GameObject;
                        boss1 = 1;
                    }
                    else if (PlayerController.BOSS2 && boss2 == 0)
                    {
                        newEnemy = Instantiate(BOSS2) as GameObject;
                        boss2 = 1;

                    }
                    else if (PlayerController.BOSS3 && boss3 == 0)
                    {
                        newEnemy = Instantiate(BOSS3) as GameObject;
                        boss3 = 1;
                    }
                    else if (PlayerController.BOSS4 && boss4 == 0)
                    {
                        newEnemy = Instantiate(BOSS) as GameObject;
                        boss4 = 1;
                    }

                }
                else
                {
                    //普通关卡选择
                    int randomEnemy = Random.Range(0, 3);
                    if (randomEnemy == 0)
                    {
                        newEnemy = Instantiate(Enemy1) as GameObject;
                    }
                    else if (randomEnemy == 1)
                    {
                        newEnemy = Instantiate(Enemy2) as GameObject;
                    }
                    else if (randomEnemy == 2)
                    {
                        newEnemy = Instantiate(Enemy3) as GameObject;
                    }
                }
                //修改
                enemyCollection.Add(newEnemy);
                //在选择的地点 创建new Enemy
                newEnemy.transform.position=spawnLocation.transform.position;
            }
            //新添加部分
            if(killedEnemies2.Count>=difficulty){
                killedEnemies2.Clear();
                gameWin=true;
            }else{
                print("Killed Enemy is"+killedEnemies.Count);
                print("Current Level is"+currentLevel);

                print("Enermy Added is"+enemyCollection.Count);
                print("The difficulty is" + difficulty);
                print("The current win is" + PlayerController.NumberOfWins);
                print("The Number of failed" + PlayerController.NumberOfFailed);
                print("Game Win is" + gameWin);

            }
            //更新等级系统
            if (killedEnemies.Count > currentLevel) {
                //潜在的问题
                enemies.Clear();
                killedEnemies.Clear();
                //等待3s
                yield return new WaitForSeconds(3f);
                currentLevel++;
                //更新levelText的内容
                LevelText.text = "Level" + currentLevel;
                //更新boss信息
               
            }
            /*
            //更新难度系统
            if(currentLevel>difficulty){
                print(difficulty);
                print(currentLevel);
                gameWin=true;
                print("The Player has win the game : "+gameWin);
            }
            */
        }
        //重新call function
        yield return null;
        StartCoroutine(spawn());
    }
    /*
    public void BOSSCheck()
    {
        if (PlayerController.BOSS1 || PlayerController.BOSS2 || PlayerController.BOSS3 || PlayerController.BOSS4)
        {
            BossNumberController = 1;
        }
        else
        {
            BossNumberController = 0;
        }
    }
    */
    IEnumerator powerUpSpawn(){
        if(currentPowerUpSpawnTime>powerUpSpawnTime){
            currentPowerUpSpawnTime=0;
            if(powerups<maxPowerUps){
                int randomNumber=Random.Range(0,powerUpSpawns.Length-1);
                GameObject spawnLocation=powerUpSpawns[randomNumber];
                int randomPowerUp = Random.Range(0,2);
                if(randomPowerUp==0){
                   newPowerup =Instantiate(healthPowerUp) as GameObject;
                }else if(randomPowerUp==1){
                    newPowerup =Instantiate(speedPowerUp) as GameObject;
                }
                newPowerup.transform.position=spawnLocation.transform.position;
            }
        }
        yield return null;
        StartCoroutine(powerUpSpawn());
    }
}
