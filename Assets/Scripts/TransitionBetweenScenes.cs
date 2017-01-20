using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TransitionBetweenScenes : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed = 0.1f;
    private Image fadeImage;
	void Start () {
        fadeImage = GetComponent<Image>();
        FadeToZero();
    }

    public void FadeToBlack()
    {
        StartCoroutine(FadingToBlack());
    }
    IEnumerator FadingToBlack()
    {
        Color a = fadeImage.color;
        Debug.Log(a.a);
        while (a.a < 1)
        {
            a.a += fadeSpeed;
            fadeImage.color = a;
            yield return new WaitForFixedUpdate();
        }
    }
    public void FadeToZero()
    {
        StartCoroutine(FadingToZero());
    }
    IEnumerator FadingToZero()
    {
        Color a = fadeImage.color;
        a.a = 1;
        while (a.a > 0)
        {
            a.a -= fadeSpeed;
            fadeImage.color = a;
            yield return new WaitForFixedUpdate();
        }
    }
}
