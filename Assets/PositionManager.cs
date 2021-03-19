using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public float startPos;
    public float incremntDist;
    public GameObject bar;

    GameObject[] bars = new GameObject[150];
    Vector2[] positions = new Vector2[150];

    // Start is called before the first frame update
    void Start()
    {
        PositionSetter();
        BarCreator();
        UpdateAllBars();
    }

    void PositionSetter()
    {
        float tempPos = startPos;
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = new Vector2(tempPos, -5);
            tempPos += incremntDist;
        }
    }

    void BarCreator()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i] = Instantiate(bar, positions[i], Quaternion.identity);
            bars[i].transform.localScale = new Vector3(.025f, Random.Range(.1f, 4.9f));
        }
    }

    void UpdateAllBars()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i].transform.position = positions[i];
        }
    }
    void UpdateSingleBar(int i)
    {
        bars[i].transform.position = positions[i];
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SelectionSort();
            UpdateAllBars();
        }
    }


    //Sorting Functions
    void SelectionSort()
    {
        float min = 10;
        int tempI = 0;
        GameObject minBar = null;
        for (int i = 0; i < bars.Length - 1; i++)
        {
            min = 10;
            for (int j = i + 1; j < bars.Length; j++)
            {
                if(bars[j].transform.localScale.y < min)
                {
                    minBar = bars[j];
                    min = bars[j].transform.localScale.y;
                    tempI = j;
                }
            }
            //swap
            bars[tempI] = bars[i];
            bars[i] = minBar;
        }
    }
}