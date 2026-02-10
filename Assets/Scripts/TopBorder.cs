using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBorder : MonoBehaviour
{
    public float timeStart;
    public float timeOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timeStart = Time.time;
        if (collision.gameObject.CompareTag("Top"))
        {
            if ((Time.time - timeStart) > timeOut)
            {
                Debug.Log("Yaaa");
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            if ((Time.time - timeStart) > timeOut)
            {
                Debug.Log("Yaaa");
            }

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            if ((Time.time - timeStart) > timeOut)
            {
                Debug.Log("Yaaa");
            }

        }
        timeStart = 0;
    }
}
