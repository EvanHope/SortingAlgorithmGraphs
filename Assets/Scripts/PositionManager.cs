using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public float stepTime;

    public float startPos;
    public float incremntDist;
    public GameObject bar;

    GameObject[] bars = new GameObject[150];
    Vector2[] positions = new Vector2[150];

    public SelectionSort selectionSortScript;
    public BubbleSort bubbleSortScript;

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

    void DebugBarArray()
    {
        for(int i = 0; i < bars.Length;i++)
        {
            Debug.Log(bars[i].transform.localScale.y);
        }
    }

    void BarCreator()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i] = Instantiate(bar, positions[i], Quaternion.identity);
            bars[i].transform.localScale = new Vector3(.1f, Random.Range(.5f, 19f));
        }
    }

    void BarRandomizer()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i].transform.localScale = new Vector3(.1f, Random.Range(.5f, 19f));
        }
    }

    public void UpdateAllBars()
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
            StartCoroutine(selectionSortScript.SelectionSorter(bars));
            //UpdateAllBars();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(bubbleSortScript.BubbleSorter(bars));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DebugBarArray();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            BarRandomizer();
        }
    }
}