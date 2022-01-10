using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Variables
    [SerializeField] private Text coinText;
    public void UpDateCoinDisplay(int coins)
    {
        coinText.text = "Coins: " + coins;
    }
}
