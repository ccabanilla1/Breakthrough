using UnityEngine;

public class DisappearAfterDelay : MonoBehaviour
{
    public float delay = 30f; // Time in seconds before disappearing

    void Start()
    {
        // Use Invoke to delay the action
        Invoke("Disappear", delay);
    }

    void Disappear()
    {
        gameObject.SetActive(false); // Deactivate the GameObject
    }
}