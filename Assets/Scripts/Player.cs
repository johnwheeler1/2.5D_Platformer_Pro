using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    // Variables
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float gravity = 1.0f;
    [SerializeField] private float jumpHeight = 35.0f;
    [SerializeField] private float jumpMultiplier = 2f;
    [SerializeField] private int coins;
    [SerializeField] private int lives = 3;
    

    private CharacterController _controller;
    private UIManager _uiManager;
    private float _yVelocity;
    private bool _canDoubleJump;


    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL!");
        }

        _uiManager.UpdateLivesDisplay(lives);
    }


    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * speed;

        if (_controller.isGrounded != true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump)
                {
                    _yVelocity += jumpHeight * jumpMultiplier;
                    _canDoubleJump = false;
                }
            }

            _yVelocity -= gravity;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = jumpHeight;
                _canDoubleJump = true;
            }
        }

        velocity.y = _yVelocity;
        
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
        coins++;

        _uiManager.UpDateCoinDisplay(coins);
    }

    public void Damage()
    {
        lives--;

        _uiManager.UpdateLivesDisplay(lives);

        if (lives >= 1) return;
        SceneManager.LoadScene(0);
    }
}
