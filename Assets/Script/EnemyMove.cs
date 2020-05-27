using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private Animator anim;
    private EnemyHealth enemyHealth;


    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player.transform;
        print("Success");
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
        //nav.SetDestination(player.position);
    }
    // Update is called once per frame
    void Update()
    {

        //适用于enemy还没有死
        if (!GameManager.instance.GameOver && enemyHealth.IsAlive && PlayerController.instance.GameStart) {
            nav.enabled = true;
            //move the enemy move towards the enemy;
            nav.SetDestination(player.position);
            //适用于enemy已经死去
        }
        else if ((!GameManager.instance.GameOver || GameManager.instance.GameOver) && !enemyHealth.IsAlive) {
            nav.enabled = false;
        }
        //适用于游戏结束但是有一部分的enemy还没死
        else {
            nav.enabled = false;
            anim.Play("Victory");
        }
    }
   
}
