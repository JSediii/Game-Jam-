using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penalty : MonoBehaviour
{
    public float life = 5f;
    public GameObject penaltyWall;

    public GameObject characterKnight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        life -= 1;

        Debug.Log("Life Left: " + life);

        if (life == 0)
        {
            Debug.Log("DEAD");
            characterKnight.SetActive(false);
        }
    }
}