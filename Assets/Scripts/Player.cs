using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    // Variables
    private CharacterController _controller;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float gravity = 1.0f;
    [SerializeField] private float jumpHeight = 35.0f;
    [SerializeField] private int coins;
    private UIManager _uiManager;
    private float _yVelocity;
    private bool _canDoubleJump = false;




    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL!");
        }
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += jumpHeight * 2f;
                    _canDoubleJump = false;
                }
            }
            
            _yVelocity -= gravity;
        }

        velocity.y = _yVelocity;
        
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
        coins++;

        _uiManager.UpDateCoinDisplay(coins);
    }
}
