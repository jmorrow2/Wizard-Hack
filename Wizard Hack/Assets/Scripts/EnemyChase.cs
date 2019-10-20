﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
	public float speed;
	public float distanceToStartAttack;
	public Animator animator;
    public float x;
    public float y;
    public float z;
	private Transform player;
    public int damageAmount;

	public GameObject my_player;
	PlayerHealth ph;

    private double count = 0.5;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start() {
    	ph = my_player.GetComponent<PlayerHealth>();
        transform.localScale = new Vector3(x, y, z);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
    	float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer < distanceToStartAttack && distanceToPlayer > 1) {
	    	// ** LOOK AT PLAYER **
	        Vector3 distanceVector = player.position - transform.position;
            // Debug.Log(direction[0]);

            if (!gameObject.GetComponent<EnemyHealth>().isDead)
            {
                if (distanceVector[0]>=0){
	        	    transform.localScale = new Vector3(x, y, z);
	            } else {
	        	    transform.localScale = new Vector3(-x, y, z);
                }
            // ** End **

            // ** CHASE PLAYER **
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                animator.SetFloat("Speed", 1);
            }
            // ** CATCH PLAYER ** 

        } else {
        	animator.SetFloat("Speed", 0);
        }

        if (canAttack){
            if (distanceToPlayer <= 2){
            	attack();
            } else {
            	animator.SetBool("Should_Attack", false);
            }
        }
        checkTime();
        // ** End **
    }

    void checkTime(){
        if (Time.time > count){
            count +=1.0;
            canAttack = true;
        }
    }

    void attack()
    {
        animator.SetBool("Should_Attack", true);
        ph.damagePlayer(damageAmount); 
        canAttack = false;
        // animator.SetBool("Should_Attack", false);
    }



}
