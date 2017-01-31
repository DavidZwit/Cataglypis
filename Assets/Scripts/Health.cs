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
	}
    void OnEnable()
    {
        PlayerMerge.ChangeHealth += ChangeHealth;
    }

    void OnDisable()
    {
        PlayerMerge.ChangeHealth -= ChangeHealth;
    }

    public void ChangeHealth( int value )
    {
        lives += value;
        display.UpdateDisplay(lives);
        if (lives <= 0)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            SceneLoaderStatic.ReloadScene();
            Destroy(gameObject);
        }
        if (lives > maxLives)
            lives = maxLives;
    }
}
