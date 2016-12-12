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
        playerWaste.transform.Translate(new Vector3(Random.Range(-1,1) , Random.Range(-1, 1), 0));
        
        foreach (MonoBehaviour script in playerWaste.GetComponents<MonoBehaviour>())
            Destroy(script);

        foreach (Transform child in playerWaste.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject != playerWaste) 
                Destroy(child.gameObject);
        }

        IsMergeable mergeScript = playerWaste.AddComponent<IsMergeable>();
        mergeScript.size = playerObject.size;


        ChangeToSize sizeScript = playerWaste.AddComponent<ChangeToSize>();
        sizeScript.SizeMultiplier = playerObject.gameObject.GetComponent<ChangeToSize>().SizeMultiplier;

        playerWaste.AddComponent<DisplaySize>();

        sizeScript.ChangeSize(mergeScript.size);


    }
}
