using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penalty : MonoBehaviour
{
    public float life = 5f;
    public GameObject penaltyWall;

    public GameObject characterKnight;
    public GameObject characterEnemy;

    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private AudioSource deathSound;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EnemyCollide"))
        {
            life += 1;
            Destroy(characterEnemy);
        }
        else if (life == 1)
        {
            Debug.Log("DEAD");
            deathSound.Play();
            characterKnight.SetActive(false);
        }
        else
        {
            hurtSound.Play();
            life -= 1;
        }
        Debug.Log("Life Left: " + life);
    }
}
