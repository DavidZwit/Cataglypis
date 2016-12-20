using UnityEngine;
using System.Collections;

public class PlayerParticles : MonoBehaviour {

    [SerializeField]
    private GameObject collissionParticle;

    [SerializeField]
    private GameObject mergeParticle;

    [SerializeField]
    private GameObject mergeFailParticle;

    void OnEnable()
    {
        PlayerMerge.IFailedToMerge += FailingToMerge;
        PlayerMerge.IMerged += SucceedsToMerge;
    }

    void OnDisable()
    {
        PlayerMerge.IFailedToMerge -= FailingToMerge;
        PlayerMerge.IMerged -= SucceedsToMerge;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Instantiate(collissionParticle, transform.position, Quaternion.identity);
    }

    void FailingToMerge(IsMergeable temp)
    {
        Instantiate(mergeFailParticle, transform.position, Quaternion.identity);
    }
    void SucceedsToMerge(IsMergeable temp)
    {
        Instantiate(mergeParticle, transform.position, Quaternion.identity);
    }

}
