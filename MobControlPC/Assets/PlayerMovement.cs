using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed=3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get a and d input, apply horizontal movement
        float movement = 0;
        if (Keyboard.current.aKey.isPressed)
            movement = -1;
        else if (Keyboard.current.dKey.isPressed)
            movement = 1;
        else movement = 0;

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
    }
}
