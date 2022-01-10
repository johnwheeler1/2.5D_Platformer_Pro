using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Variables
    [SerializeField] private Transform targetA, targetB;
    [SerializeField] private float speed = 3.0f;
    private bool _switching = false;
    
    void Update()
    {
        if (_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetB.position, speed * Time.deltaTime);
        }
        else if (_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetA.position, speed * Time.deltaTime);
        }

        if (transform.position == targetB.position)
        {
            _switching = true;
        }
        else if (transform.position == targetA.position)
        {
            _switching = false;
        }
    }
    
    // create method for the PlatformMovement()
}