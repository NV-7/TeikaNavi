using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TopBorderBehavior : MonoBehaviour
{
    
    public float timeOut = 2f;
    
    public GameObject gameOver;
    private bool touch = false;
    private float timer = 0f;
    private int touching = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(touching);
        if(touching > 0)
        {
            timer += Time.deltaTime;
            //gameOver.SetActive(true);
            if (timer >= timeOut)
            {
                Debug.Log("timer greater than time out");
                gameOver.SetActive(true);
            }
            else
            {
                
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("dessert"))
        {
            
            touching++;
            Debug.Log("Collision Enter " + touching);


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dessert"))
        {
            Debug.Log("Collision Exit");
            touch = false;
            touching = Mathf.Max(0, touching - 1);

        }

    }
    
}
