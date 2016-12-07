using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    private int lives;
    [SerializeField]
    private int maxLives = 3;
    [SerializeField]
    private DisplayHealth display;

	void Start () {
        lives = maxLives;
        display.UpdateDisplay(lives);
	}
}
