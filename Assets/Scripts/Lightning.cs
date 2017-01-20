using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Lightning : MonoBehaviour {

    [SerializeField]
    private float duration = 0.2f;
    [SerializeField]
    private GameObject lightningImage;
    private int maxLightning;
    private int index;
	public void Strike(int amountOfLightning)
    {
        index = 1;
        maxLightning = amountOfLightning;
        StartCoroutine(Striking());
    }
    IEnumerator Striking()
    {
        lightningImage.SetActive(true);
        yield return new WaitForSeconds(duration);
        lightningImage.SetActive(false);
        yield return new WaitForSeconds(duration);
        if (index <= maxLightning)
        {
            index++;
            StartCoroutine(Striking());
        }
    }
}
