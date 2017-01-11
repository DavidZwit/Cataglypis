using UnityEngine;
using System.Collections;

public class MergePlayerModels : MonoBehaviour {

    Mesh myMesh;

	void OnEnable()
    {
        PlayerMerge.OnMerge += PlayerMerged;
    }

    void OnDisable()
    {
        PlayerMerge.OnMerge -= PlayerMerged;
    }

    void Awake()
    {
        myMesh = Instantiate(GetComponent<MeshFilter>().mesh);
    }

    void PlayerMerged(IsMergeable mergeScript)
    {
        myMesh = CreateNewMesh(myMesh, mergeScript.myMesh);
    }

    Mesh CreateNewMesh(Mesh original, Mesh merge)
    {

        for (var i = 0; i < original.vertexCount; i++) {
            if (original.vertices[i] != merge.vertices[i])
            {
                original.vertices[i] = merge.vertices[i];
                //original.uv[i] = merge.uv[i];

                //print(original.vertices[i]);
                print(i);
            }
        }
        

        return original;
    }
}
