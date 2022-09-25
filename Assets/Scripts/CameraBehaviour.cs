using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private float maxSidewaysMovement = 2;
    [SerializeField] private GameObject player;
    private Vector3 desiredPosition;
    private Vector3 smoothedPosition;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));

        desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        transform.position = smoothedPosition;

        if (transform.position.x > maxSidewaysMovement)
        {
            transform.position = new Vector3(maxSidewaysMovement, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -maxSidewaysMovement)
        {
            transform.position = new Vector3(-maxSidewaysMovement, transform.position.y, transform.position.z);
        }

        //if (player.transform.position.y > transform.position.y + 4)
        //{
        //    transform.position = new Vector3(transform.position.x, player.transform.position.y - 4, transform.position.z);
        //}


    }

    public void Reset()
    {
        Debug.Log("Reset");
        transform.position = new Vector3(0, 0, -10);
    }
}
