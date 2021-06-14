using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public float waitTime;

    public PositionManager positionManagerScript;
    private SoundManager soundManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        soundManagerScript = GetComponent<SoundManager>();
    }

    public IEnumerator BubbleSorter(GameObject[] bars)
    {
        bool objectMoved = false;
        Bar bar1 = null;
        Bar bar2 = null;
        while (true)
        {

            do
            {
                objectMoved = false;
                for (int i = 0; i < bars.Length - 1; i++)
                {
                    yield return new WaitForSeconds(waitTime);
                    positionManagerScript.UpdateAllBars();
                    if (bar1 != null && bar2 != null)
                    {
                        bar1.ColorSetUnselect();
                        bar2.ColorSetUnselect();
                    }

                    if (bars[i].transform.localScale.y > bars[i + 1].transform.localScale.y)
                    {
                        var lowerValue = bars[i + 1];
                        bars[i + 1] = bars[i];
                        bars[i] = lowerValue;
                        objectMoved = true;
                        bar1 = bars[i].GetComponent<Bar>();
                        bar2 = bars[i + 1].GetComponent<Bar>();
                        bar1.ColorSetSelect();
                        bar2.ColorSetSelect();
                        soundManagerScript.PlaySound(bars[i + 1].transform.localScale.y);
                    }
                }
            } while (objectMoved);
            yield break;
        }
    }
}