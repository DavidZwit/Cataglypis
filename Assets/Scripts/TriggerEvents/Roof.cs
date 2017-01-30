using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour {

    Color color;
    bool behindObject = false;

    [SerializeField]
    private float minAlpha = 0.1f;
    [SerializeField]
    private float fadeSpeed = 0.02f;
    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
    }
    void OnTriggerEnter2D()
    {
        behindObject = true;
        StartCoroutine(BehindObject());
    }
    void OnTriggerExit2D()
    {
        behindObject = false;
        StartCoroutine(OutOfObject());
    }
    IEnumerator BehindObject()
    {
        WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
        while (behindObject && color.a > minAlpha)
        {
            color.a -= fadeSpeed;
            GetComponent<SpriteRenderer>().color = color;
            yield return fixedUpdate;
        }
    }
    IEnumerator OutOfObject()
    {
        WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
        while (!behindObject && color.a < 1)
        {
            color.a += fadeSpeed;
            GetComponent<SpriteRenderer>().color = color;
            yield return fixedUpdate;
        }
    }

}
