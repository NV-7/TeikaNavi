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
    public GameObject player;
    public 
    
    // Start is called before the first frame update
    void Start()
    {
        dessert = this.gameObject;
        mergeSound = this.GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        GameObject obj = col.gameObject;
        int currentType = this.type;


        if (col.gameObject.CompareTag(dessert.tag))
        {
            print("collion detected");
            Debug.Log("Collision Detected" + col.gameObject.name + "with " + dessert.name);
            int objType = obj.GetComponent<dessertBehavior>().type;

            if (currentType == objType && nextDessert != null)
            {
                Debug.Log("Same Type");
                

                if (gameObject.GetInstanceID() > col.gameObject.GetInstanceID())
                {
                    Debug.Log("Merge");

                    mergeSound.Play();
                    //player.GetComponent<PlayerBehavior>().updateScore(this.type);

                    Destroy(col.gameObject);
                    Destroy(this.gameObject);

                    GameObject newDessert = Instantiate(nextDessert,
                        Vector3.Lerp(transform.position, obj.transform.position, 0.5f), Quaternion.identity);
                    newDessert.GetComponent<Collider2D>().enabled = true;
                    newDessert.GetComponent<Rigidbody2D>().gravityScale = 3f;

                    
                }  
                  
            }
        }
    }

    public int getPoints()
    {
        return points;
    }
}

    
        
    

