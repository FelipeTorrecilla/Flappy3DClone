using UnityEngine;

public class FlappyBirdScore : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlappyBirdController controller = other.GetComponent<FlappyBirdController>();
            if (controller != null)
            {
                controller.IncreaseScore();
            }
        }
    }
}

