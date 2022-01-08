using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject enemy1;

    public GameObject deathEffect;

    public Slider enemySlider;

    public void Start()
    {
        enemy1 = GameObject.FindGameObjectWithTag("Enemy");
        enemySlider.maxValue = health;
        enemySlider.value = health;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        enemySlider.value = health;

        if (health <= 0)
        {
            Die();
        }
    }

    
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Debug.Log(gameObject);

        Destroy(enemy1);

        Destroy(deathEffect);

        Cursor.visible = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}
