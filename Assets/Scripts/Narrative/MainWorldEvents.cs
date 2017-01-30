using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWorldEvents : MonoBehaviour {
    [SerializeField]
    private TransitionBetweenScenes transition;

    void OnTriggerEnter2D () {
        StartCoroutine(Finish());
	}
	IEnumerator Finish()
    {
        transition.FadeToBlack();
        yield return new WaitForSeconds(2f);
        Dificulty.level++;
        SceneLoaderStatic.ReloadScene();
    }
}
