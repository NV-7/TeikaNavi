using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/**
 * 
 * Order of dessert progression
 * Jello -> muffin -> donut -> peppermint -> cookie -> swirl -> cake -> cream -> sandwich
 * 
 */


public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    public GameObject fruitHeld;
    public GameObject[] fruits;
    public Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        speed = 10f;
        
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
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed * Time.deltaTime;
            transform.position = newPos;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {

           
             //   createFruit();
           
            float start = Time.time;
            int num = Random.Range(0, fruits.Length);


            Rigidbody2D rb = fruitHeld.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1.0f;

            Collider2D coll = fruitHeld.GetComponent<Collider2D>();
            coll.enabled = true;

            Vector3 fruitPos = transform.position;
            fruitPos.y = -5;
            
            fruitHeld = Instantiate(fruits[num], transform.position, Quaternion.identity);
            fruitHeld.tag = "Current";

            fruitHeld.GetComponent<Rigidbody2D>().gravityScale = 0;
            fruitHeld.GetComponent<Collider2D>().enabled = false;
            fruitHeld.GetComponent<Collider2D>().enabled = false;

            float timePassed = Time.time - start;
            print(timePassed);

        }


    }
    public void createFruit()
    {
        int num = Random.Range(0, fruits.Length);


        Rigidbody2D rb = fruitHeld.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1.0f;

        Collider2D coll = fruitHeld.GetComponent<Collider2D>();
        coll.enabled = true;

        fruitHeld = Instantiate(fruits[num], transform.position, Quaternion.identity);
        fruitHeld.tag = "current";

    }
}
