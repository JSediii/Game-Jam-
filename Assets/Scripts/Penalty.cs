using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Penalty : MonoBehaviour
{
    public GameObject penaltyWall;

    public GameObject characterKnight;
    public GameObject characterEnemy;

    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private AudioSource deathSound;

    public int playerScore;
    public Text scoretext;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EnemyCollide"))
        {
            HealthManager.health++;
            addScore(1);
            if (HealthManager.health >= 5)
            {
                HealthManager.health = 5;
            }
            Destroy(characterEnemy);
        }
        else if (HealthManager.health == 1)
        {
            HealthManager.health = 0;
            Debug.Log("DEAD");
            deathSound.Play();
            Time.timeScale = 0;
        }
        else
        {
            HealthManager.health--;
            hurtSound.Play();
        }
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoretext.text = playerScore.ToString();
    }
}
