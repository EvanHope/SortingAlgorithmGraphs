using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Color selectedColor;
    public Color unselectedColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorSetSelect()
    {
        gameObject.GetComponent<SpriteRenderer>().color = selectedColor;
    }
    public void ColorSetUnselect()
    {
        gameObject.GetComponent<SpriteRenderer>().color = unselectedColor;
    }
}
