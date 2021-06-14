using System.Collections;
using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    public float waitTime;

    public PositionManager positionManagerScript;
    private SoundManager soundManagerScript;

    private void Start()
    {
        soundManagerScript = GetComponent<SoundManager>();
    }

    public IEnumerator SelectionSorter(GameObject[] bars)
    {
        while (true)
        {
            int tempI = 0;
            GameObject minBar = null;
            Bar bar1 = null;
            Bar bar2 = null;
            for (int i = 0; i < bars.Length; i++)
            {
                positionManagerScript.UpdateAllBars();
                yield return new WaitForSeconds(waitTime);
                if (bar1 != null && bar2 != null)
                {
                    bar1.ColorSetUnselect();
                    bar2.ColorSetUnselect();
                }

                float min = bars[i].transform.localScale.y;
                for (int j = i + 1; j < bars.Length; j++)
                {
                    if (bars[j].transform.localScale.y < min)
                    {
                        minBar = bars[j];
                        min = bars[j].transform.localScale.y;
                        tempI = j;
                    }
                }

                if (min != bars[i].transform.localScale.y) //if a lower value if found
                {
                    bar1 = bars[i].GetComponent<Bar>();
                    bar2 = bars[tempI].GetComponent<Bar>();
                    bar1.ColorSetSelect();
                    bar2.ColorSetSelect();
                    soundManagerScript.PlaySound(bars[tempI].transform.localScale.y);

                    var lowerValue = bars[tempI];
                    bars[tempI] = bars[i];
                    bars[i] = lowerValue;
                }
            }
            yield break;
        }
    }
}
