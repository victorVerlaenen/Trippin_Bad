using UnityEngine;
using UnityEngine.EventSystems;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject creditsButton;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject creditsSkeleton;
    [SerializeField] private GameObject mainMenuSkeleton;
    [SerializeField] private GameObject exitSkeleton;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("End");
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == creditsButton)
        {
            creditsSkeleton.SetActive(true);
            mainMenuSkeleton.SetActive(false);
            exitSkeleton.SetActive(false);
        }
        if (EventSystem.current.currentSelectedGameObject == exitButton)
        {
            creditsSkeleton.SetActive(false);
            mainMenuSkeleton.SetActive(false);
            exitSkeleton.SetActive(true);
        }
        if (EventSystem.current.currentSelectedGameObject == mainMenuButton)
        {
            creditsSkeleton.SetActive(false);
            mainMenuSkeleton.SetActive(true);
            exitSkeleton.SetActive(false);
        }
    }
}
