using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollow : MonoBehaviour
{

    public GameObject player;
    public float followSpeed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
    
        if (distance < 6) //conditional statement if the player is close to enemy, then enemy will follow the player
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }
    }
}
