using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private const float resetPosition = 68.9f;
    [SerializeField] private float moveSpeed = 4.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        if(transform.position.x <= -resetPosition)
        {
            transform.position = new Vector3(resetPosition,transform.position.y,transform.position.z);
        }
    }
}
