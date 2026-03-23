using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


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
    public GameObject GameOver;
    public Rigidbody2D playerRb;

    public int totalPoints;
    public TMP_Text textField;
    public AudioSource dropSound;

    public GameObject q;

    public Vector3 dessertOffset = new Vector3(0, -1, 0);
    private bool isGameOver = false;
    private Queue<GameObject> gameQueue;
    

    // Start is called before the first frame update
    void Start()
    {

        speed = 10f;
    
        playerRb = this.GetComponent<Rigidbody2D>();
        totalPoints = 0;
        q = GameObject.FindWithTag("queue");
        q.GetComponent<QueueManger>().createQueue();
        
        gameQueue = q.GetComponent<QueueManger>().gameQueue;
     
        createFruit();
    }
   

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                restart();
            }
            return;
        }
        if(fruitHeld != null) 
        { 
            fruitHeld.transform.position = this.transform.position + dessertOffset; 
        }
       
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {


            dropFruit();
            createFruit();


        }


    }

    private void FixedUpdate()
    {
        if(playerRb != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                Vector3 newPos = transform.position;
                newPos.x = newPos.x - speed * Time.deltaTime;
                playerRb.MovePosition(newPos);
            }
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                Vector3 newPos = transform.position;
                newPos.x = newPos.x + speed * Time.deltaTime;
                playerRb.MovePosition(newPos);
            }
        }
        
    }
    public void createFruit()
    {
       // int num = Random.Range(0, fruits.Length);

        fruitHeld = Instantiate(gameQueue.Peek(), transform.position, Quaternion.identity);

        Rigidbody2D rb = fruitHeld.GetComponent<Rigidbody2D>();
        rb.simulated = false;
        

         Collider2D coll = fruitHeld.GetComponent<Collider2D>();
         coll.enabled = false;


        Vector3 fruitPos = transform.position;
        fruitPos.y = -10;


        fruitHeld.tag = "dessert";
       
    }

    public void dropFruit()
    {
        gameQueue.Dequeue();
        q.GetComponent<QueueManger>().updateQueue();
        Rigidbody2D rb = fruitHeld.GetComponent<Rigidbody2D>();
        Collider2D coll = fruitHeld.GetComponent <Collider2D>();
        coll.enabled = true;
        rb.simulated = true;
        rb.gravityScale = 2f;
        dropSound.Play();
        fruitHeld = null;

    }

    public void updateScore(int points)
    {
        totalPoints += points;
        textField.SetText("Score:" + "\n " + totalPoints);
    }

    public void gameOver()
    {
        isGameOver = true;
        GameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
