using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed * Time.deltaTime;
            transform.position = newPos;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed * Time.deltaTime;
            transform.position = newPos;
        }
        else if (Keyboard.current.upArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.y = newPos.y + speed * Time.deltaTime;
            transform.position = newPos;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.y = newPos.y - speed * Time.deltaTime;
            transform.position = newPos;
        }
    }
}
