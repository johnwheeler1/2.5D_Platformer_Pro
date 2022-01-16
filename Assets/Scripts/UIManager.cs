using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Variables
    [SerializeField] private Text coinText, livesText;
    public void UpDateCoinDisplay(int coins)
    {
        coinText.text = "Coins: " + coins;
    }

    public void UpdateLivesDisplay(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
