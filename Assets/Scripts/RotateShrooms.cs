using UnityEngine;

public class RotateShrooms : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 6 * Time.deltaTime);
    }
}
