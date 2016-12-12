using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    private int lives;
    [SerializeField]
    private int maxLives = 3;
    [SerializeField]
    private DisplayHealth display;
    [SerializeField]
    private GameObject deathParticle;
	void Start () {

        lives = maxLives;
        display.UpdateDisplay(lives);

        PlayerMerge.IFailedToMerge += HealthLost;
	}

    public void HealthLost(GameObject temp)
    {
        lives--;
        display.UpdateDisplay(lives);

        if (lives <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
