using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScriptBehavior : MonoBehaviour
{
    float timeStart;
    float timeOut;
    public GameObject gameOver;
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
        if (collision.gameObject.CompareTag("fruit"))
        {
            if ((Time.time - timeStart) > timeOut)
            {
                Debug.Log("Yaaa");
                gameOver.SetActive(true);
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
