using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Lightning : MonoBehaviour {

    [SerializeField]
    private float duration = 0.2f;
    [SerializeField]
    private GameObject lightningImage;
    [SerializeField]
    private GameObject lightningAnimation;
    [SerializeField]
    private Transform spwanPosition;
    [SerializeField]
    private AudioSource thunderSound;
    private int maxLightning;
    private int index;
	public void Strike(int amountOfLightning)
    {
        index = 1;
        maxLightning = amountOfLightning;
        StartCoroutine(Striking());
        thunderSound.Play();
    }
    IEnumerator Striking()
    {
        Instantiate(lightningAnimation, new Vector3(spwanPosition.position.x + Random.Range(-2,3), spwanPosition.position.y, spwanPosition.position.z - 5f), Quaternion.identity);
        lightningImage.SetActive(true);
        yield return new WaitForSeconds(duration);
        lightningImage.SetActive(false);
        yield return new WaitForSeconds(duration);
        if (index < maxLightning)
        {
            index++;
            StartCoroutine(Striking());
        }
    }
}
