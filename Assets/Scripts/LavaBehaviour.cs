using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
    }

    public void Reset()
    {
        SceneManager.LoadScene("RespawnScreen");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Reset();
        }
    }
}
