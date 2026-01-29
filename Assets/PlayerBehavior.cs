using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    public GameObject fruitHeld;
    public GameObject[] fruits;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fruitHeld != null)
        {
            Vector3 playerPos = transform.position;
            Vector3 fruitPos = new Vector3(0.0f, -6.0f, 0.0f);

            fruitHeld.transform.position = transform.position;

        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed * Time.deltaTime;
            transform.position = newPos;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed * Time.deltaTime;
            transform.position = newPos;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.y = newPos.y + speed * Time.deltaTime;
            transform.position = newPos;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.y = newPos.y - speed * Time.deltaTime;
            transform.position = newPos;
        }
        if (Keyboard.current.spaceKey.isPressed)
        {
            int num = Random.Range(0, fruits.Length);


            Rigidbody2D rb = fruitHeld.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1.0f;

            Collider2D coll = fruitHeld.GetComponent<Collider2D>();
            coll.enabled = true;
            
            fruitHeld = Instantiate(fruits[num], transform.position, Quaternion.identity);

            fruitHeld.GetComponent<Rigidbody2D>().gravityScale = 0;
            fruitHeld.GetComponent<Collider2D>().enabled = false;

        }
    }
}
