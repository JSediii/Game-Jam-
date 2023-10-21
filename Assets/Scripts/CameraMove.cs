using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject movement;

    public float cameraSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // test
    }

    // Update is called once per frame
    void Update()
    {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");


            Vector3 movement = new Vector3(horizontal, vertical, 0);

            transform.position += movement * cameraSpeed * Time.deltaTime;
    }
}
