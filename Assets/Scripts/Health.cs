using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField]
    private int lives;

    [SerializeField]
    private int maxLives = 3;

    [SerializeField]
    private DisplayHealth display;
	void Start () {
        lives = maxLives;
	}
	
	void Update () {
	}
}
