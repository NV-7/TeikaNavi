using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour
{
    GameObject[] bkg;
    public GameObject backPrefab;
    public float pivotPoint;
    public float speed;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        bkg = new GameObject[3];
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
        
    }
}
