using UnityEngine;

public class Bomb : MonoBehaviour
{

    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<GameManager>().Explode();
        }
    }
}
