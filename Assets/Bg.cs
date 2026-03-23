using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Bg : MonoBehaviour
{
    GameObject[] bkg;
    public GameObject backPrefab;
    private float pivotPoint;
    public float speed;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        backPrefab.transform.localScale = new Vector3(scale, scale, scale);
        bkg = new GameObject[3];
        pivotPoint = -0.32f * 16 * scale;

        for(int i = 0; i < 3; i++)
        {
            float yPos = pivotPoint - (pivotPoint / 2 * i);
            float xPos = pivotPoint - (pivotPoint / 2 * i);
            Vector2 pos = new Vector2(xPos, yPos);
            bkg[i] = Instantiate(backPrefab, pos, Quaternion.identity);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            float xPos = bkg[i].transform.position.x + speed;
            float yPos = bkg[i].transform.position.y + speed;
            Vector3 newPos = new Vector3(xPos, yPos, 0f);
            bkg[i].transform.position = newPos;
            if(xPos > -pivotPoint / 2)
            {
                Vector3 pivot = new Vector3(pivotPoint, pivotPoint, 0f);
                bkg[i].transform.position = pivot;
            }
        }
    }
}
