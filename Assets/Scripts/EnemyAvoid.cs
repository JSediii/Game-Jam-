using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvoid : MonoBehaviour
{
    public GameObject player;
    public float minDistance = 5.0f;
    public float speed = 3.0f;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = player.transform;
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance < minDistance)
        {
            Vector3 direction = (transform.position - playerTransform.position).normalized;
            Vector3 moveVector = direction * speed * Time.fixedDeltaTime;
            transform.position += moveVector;
        }
    }
}

