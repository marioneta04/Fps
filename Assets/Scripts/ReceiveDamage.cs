using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReceiveDamage : MonoBehaviour
{
    public int health;
    public int damage;
    private int  currentHealth;
    public Scrollbar healthBar;
    public GameObject bloodParticlesPrefab;



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= damage;

            UpdateHealthBar();
           
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
           
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (bloodParticlesPrefab != null) 
        {
            
            ContactPoint contact = collision.contacts[0];
            Vector3 impactPoint = contact.point;

            
            Instantiate(bloodParticlesPrefab, impactPoint, Quaternion.identity);
        }

    }

    private void OnDestroy()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddPoint();
        }
    }
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.size = (float)currentHealth / health;
        }
    }
}
