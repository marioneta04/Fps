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
