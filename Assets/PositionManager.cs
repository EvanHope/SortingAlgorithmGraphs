using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public float startPos;
    public float incremntDist;

    GameObject[] bars = new GameObject[150];
    Vector2[] positions = new Vector2[150];
    // Start is called before the first frame update
    void Start()
    {
        PositionSetter();
    }

    void PositionSetter()
    {
        float tempPos = startPos;
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = new Vector2(tempPos, -5);
            tempPos += incremntDist;
            i++;
        }
    }

    //Depending on whether I do it will all bars being updated at once or updating every time one bar is moved I will delete comments.
    void DisplayBars(int i)
    {
        //for (int i = 0; i < bars.Length; i++)
        //{
            bars[i].transform.position = positions[i];
        //}
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
