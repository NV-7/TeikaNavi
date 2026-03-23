using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QueueManger : MonoBehaviour
{
    public Sprite[] UISprite;
    public int[] queue;
    public SpriteRenderer[] childRenderer;
    private GameObject[] dessertList;
    public Queue<GameObject> gameQueue;

    // Start is called before the first frame update
    void Start()
    {


        dessertList = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>().fruits;
       
        //createQueue(); 
        

        //queue = new int[4];

        //for(int i = 0; i < 4; i++)
        //{
        //    queue[i] = Random.Range(0, 4);
            
        //}

        //childRenderer = new SpriteRenderer[4];

        //for(int i = 0; i < transform.childCount; i++)
        //{
        //    childRenderer[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i < transform.childCount; i++)
        //{
        //    childRenderer[i].sprite = UISprite[queue[i]];
        //}

       
    }
    public void updateQueue()
    {

        GameObject dessert = dessertList[Random.Range(0, 9)];
        gameQueue.Enqueue(dessert);
        Queue<GameObject> tempQ = new Queue<GameObject>(gameQueue);

        for(int i = 0; i < 4; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            child.GetComponent<SpriteRenderer>().sprite = tempQ.Dequeue().GetComponent<SpriteRenderer>().sprite;

        }


        //int currentType = queue[0];

        //for (int i = 1; i < queue.Length; i++)
        //{
        //    queue[i - 1] = queue[i];
        //}

        //queue[3] = Random.Range(0, 4);
        //return currentType;


    }

    public void createQueue()
    {
        
        dessertList = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>().fruits;

        gameQueue = new Queue<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            GameObject dessert = dessertList[Random.Range(0, 4)];
            child.GetComponent<SpriteRenderer>().sprite = dessert.GetComponent<SpriteRenderer>().sprite;

            gameQueue.Enqueue(dessert);
        }
        
    }

    public int GenerateNum()
    {
        int num = Random.Range(0, 4);
        return num;
    }
}
