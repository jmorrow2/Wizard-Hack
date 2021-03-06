﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int initialHealth = 100;
    public int enemyCurrentHealth;
    public bool isDead = false;
    public Slider enemyHealthSlider;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        /* enemy initial health should be 100 when starting */
        enemyCurrentHealth = initialHealth;
    }

    public void damageEnemy(int damageAmount)
    {
        if (enemyCurrentHealth - damageAmount <= 0)
        {
            death();
        }
        enemyCurrentHealth -= damageAmount;
        enemyHealthSlider.value = enemyCurrentHealth;
    }

    void death()
    {
        isDead = true;
        animator.SetBool("Dead", true);

        FindObjectOfType<LevelController>().enemyDead();

        Destroy(gameObject, 1.5f);
    }

}
