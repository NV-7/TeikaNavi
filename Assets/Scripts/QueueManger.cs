using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManger : MonoBehaviour
{
    public Sprite[] UISprite;
    public int[] queue;
    public SpriteRenderer[] childRenderer;

    // Start is called before the first frame update
    void Start()
    {
        queue = new int[4];

        for(int i = 0; i < 4; i++)
        {
            queue[i] = Random.Range(0, 4);
            
        }

        childRenderer = new SpriteRenderer[4];

        for(int i = 0; i < transform.childCount; i++)
        {
            childRenderer[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            childRenderer[i].sprite = UISprite[queue[i]];
        }
        
    }

    public int updateQueue()
    {

        int currentType = queue[0];

        for (int i = 1; i < queue.Length; i++)
        {
            queue[i - 1] = queue[i];
        }

        queue[3] = Random.Range(0, 4);
        return currentType;
    }
}
