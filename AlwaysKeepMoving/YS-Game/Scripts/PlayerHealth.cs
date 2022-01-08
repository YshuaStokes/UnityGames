using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	//public GameSceneManager gameSceneManager;
	[SerializeField] private float startingHealth;
	public float currentHealth {get; set;}

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public GameObject deathEffect;

	public GameObject player;

    public void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
        

	}

    public void TakeDamage(float damage)
	{
		currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
		

		StartCoroutine(DamageAnimation());

		if (currentHealth <= 0)
		{
			Debug.Log("Player Died");
			Die();
			
		}
	}

    public void Die()
    {
		
		Instantiate(deathEffect, transform.position, Quaternion.identity);

		Debug.Log(gameObject);

		Destroy(player);

		Destroy(deathEffect);

		Cursor.visible = true;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}

}
