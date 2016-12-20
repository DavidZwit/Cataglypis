using UnityEngine;
using System.Collections;

public class Splitting : MonoBehaviour {

    void OnEnable()
    {
        PlayerMerge.IFailedToMerge += SplitInTwo;
    }

    void OnDisable()
    {
        PlayerMerge.IFailedToMerge -= SplitInTwo;
    }

    void SplitInTwo(IsMergeable playerObject)
    {
        playerObject.size /= 2;

        GameObject playerWaste = Instantiate(playerObject.gameObject) as GameObject;

        StartCoroutine(CloneBall(playerWaste.GetComponent<CircleCollider2D>()));

        playerWaste.GetComponent<Rigidbody2D>().velocity = playerObject.GetComponent<Rigidbody2D>().velocity.normalized;

        foreach (MonoBehaviour script in playerWaste.GetComponents<MonoBehaviour>())
            Destroy(script);

        foreach (Transform child in playerWaste.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject != playerWaste) 
                Destroy(child.gameObject);
        }

        playerWaste.AddComponent<RotateAroundWorld>();
        IsMergeable mergeScript = playerWaste.AddComponent<IsMergeable>();
        mergeScript.size = playerObject.size;


        ChangeToSize sizeScript = playerWaste.AddComponent<ChangeToSize>();
        sizeScript.SizeMultiplier = playerObject.gameObject.GetComponent<ChangeToSize>().SizeMultiplier;

        playerWaste.AddComponent<DisplaySize>();

        sizeScript.UpdateSize(mergeScript.size);
    }
    IEnumerator CloneBall(CircleCollider2D coll)
    {
        coll.isTrigger = true;
        yield return new WaitForSeconds(1f);
        coll.isTrigger = false;
    }
}
