using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class dessertBehavior : MonoBehaviour
{
    GameObject dessert;
    public AudioSource mergeSound;
    public int type;
    public int points;
    public GameObject nextDessert;
    public PlayerBehavior player;
    public float timeOut = 2;
    public float timeStart;
    public bool hasMerged = false;
    private float timeThusFar = 0;
    

    
    // Start is called before the first frame update
    void Start()
    {
        dessert = this.gameObject;
        mergeSound = this.GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerBehavior>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("dessert"))
        {
            GameObject dessert = col.gameObject;
            int dessertType = dessert.GetComponent<dessertBehavior>().type;
            dessertBehavior dessertHasMerged = dessert.GetComponent<dessertBehavior>();

            if(dessert == null || this.hasMerged || dessertHasMerged.hasMerged)
            {
                return;
            }
            if(type == dessertType && dessertType != 9)
            {
              if(this.gameObject.GetInstanceID() > col.gameObject.GetInstanceID())
                {
                   
                    this.hasMerged = true;
                    dessertHasMerged.hasMerged = true;

                    AudioSource.PlayClipAtPoint(mergeSound.clip, transform.position);

                    GameObject merged = Instantiate(nextDessert, Vector3.Lerp(transform.position, dessert.transform.position, 0.5f), Quaternion.identity);
                    Debug.Log(merged.name);
                    merged.GetComponent<Collider2D>().enabled = true;
                    merged.GetComponent<Rigidbody2D>().gravityScale = 2f;

                    player.updateScore(this.points);
                    Destroy(dessert);
                    Destroy(gameObject);
                }
            }
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            timeThusFar += Time.deltaTime;

            if(timeThusFar > timeOut)
            {
                player.GetComponent<PlayerBehavior>().gameOver();
            }
      
        }

       
    }
    private void OnTriggerExit2D(Collider2D colllision)
    {
        if (colllision.gameObject.CompareTag("Top"))
        {
        timeThusFar = 0;
        Debug.Log("2 Time thus far : " + timeThusFar);
        }
    }
    public int getPoints()
    {
        return points;
    }
}

    
        
    

