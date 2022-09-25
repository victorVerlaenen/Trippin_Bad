using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject retrySkeleton;
    [SerializeField] private GameObject exitSkeleton;
    [SerializeField] private GameObject menuSkeleton;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Ouch");
        FindObjectOfType<AudioManager>().Play("YouDied");
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == retryButton)
        {
            retrySkeleton.SetActive(true);
            exitSkeleton.SetActive(false);
            menuSkeleton.SetActive(false);
        }
        if (EventSystem.current.currentSelectedGameObject == exitButton)
        {
            retrySkeleton.SetActive(false);
            exitSkeleton.SetActive(true);
            menuSkeleton.SetActive(false);
        }
        if (EventSystem.current.currentSelectedGameObject == menuButton)
        {
            retrySkeleton.SetActive(false);
            exitSkeleton.SetActive(false);
            menuSkeleton.SetActive(true);
        }
    }
}
