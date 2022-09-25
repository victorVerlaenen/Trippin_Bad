using UnityEngine;
using UnityEngine.EventSystems;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject backSkeleton;

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == backButton)
        {
            backSkeleton.SetActive(true);
        }
    }
}
