using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var player = other.GetComponent<Player>();

        if (player != null)
        {
            player.AddCoins();
        }

        Destroy(this.gameObject);
    }
}
