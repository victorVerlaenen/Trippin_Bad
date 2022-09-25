using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject controlsButton;
    [SerializeField] private GameObject playSkeleton;
    [SerializeField] private GameObject exitSkeleton;
    [SerializeField] private GameObject controlsSkeleton;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MenuTheme");
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == playButton)
        {
            playSkeleton.SetActive(true);
            exitSkeleton.SetActive(false);
            controlsSkeleton.SetActive(false);
        }
        if (EventSystem.current.currentSelectedGameObject == exitButton)
        {
            playSkeleton.SetActive(false);
            exitSkeleton.SetActive(true);
            controlsSkeleton.SetActive(false);
        }
        if (EventSystem.current.currentSelectedGameObject == controlsButton)
        {
            playSkeleton.SetActive(false);
            exitSkeleton.SetActive(false);
            controlsSkeleton.SetActive(true);
        }
    }
}
