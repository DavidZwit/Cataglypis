using UnityEngine;
using System.Collections;
using System;

public class Health : MonoBehaviour {

    private int lives;
    [SerializeField]
    private int maxLives = 3;
    [SerializeField]
    private DisplayHealth display;
    [SerializeField]
    private GameObject deathParticle;
    public static Action Lost;
	void Start () {

        lives = maxLives;
        display.UpdateDisplay(lives);

        PlayerMerge.LosingHealth += HealthLost;
	}

    public void HealthLost()
    {
        lives--;
        display.UpdateDisplay(lives);

        if (lives <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Lost();
            Destroy(gameObject);
        }
    }
}
