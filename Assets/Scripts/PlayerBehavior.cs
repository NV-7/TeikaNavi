using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


/**
 * 
 * Order of dessert progression
 * Jello -> muffin -> donut -> peppermint -> cookie -> swirl -> cake -> cream -> sandwich
 * 0        1         2        3             4         5        5       6        7
 */


public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    public GameObject fruitHeld;
    public GameObject[] fruits;
    public Collider collider;
    public GameObject gameOver;

    public int[] points;
    public int total;
    public TMP_Text textField;
    public AudioSource dropSound;

    public GameObject q;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        speed = 10f;
        dropSound = this.GetComponent<AudioSource>();
        

    
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        //fruitHeld.transform.position.x = this.transform.position.x;

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
            int choice = GameObject.FindGameObjectWithTag("q").GetComponent<QueueManger>().updateQueue();

            fruitHeld.GetComponent<Rigidbody2D>().gravityScale = 3f;

            createFruit();

            dropSound.Play();

            float start = Time.time;
            
            float timePassed = Time.time - start;
            print(timePassed);

        }


    }
    public void createFruit()
    {

        int num = Random.Range(0, fruits.Length);

        fruitHeld = Instantiate(fruits[num], transform.position, Quaternion.identity);

        Rigidbody2D rb = fruitHeld.GetComponent<Rigidbody2D>();
         rb.gravityScale = 0f;

         Collider2D coll = fruitHeld.GetComponent<Collider2D>();
         coll.enabled = true;

        Vector3 fruitPos = transform.position;
        fruitPos.y = -10;

        fruitHeld.tag = "dessert";
    }

    public void updateScore(int index)
    {
        total += points[index];
        textField.SetText(" " + total);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }
}
