using UnityEngine;
using System.Collections;
using System.Threading;

public enum texType {
    cow = 0,
    hay = 1
}

public class MergePlayerTextures : MonoBehaviour {
    Material myMaterial;
    [SerializeField]
    Texture[] highlightTextures;

    void OnEnable()
    {
        PlayerMerge.IMerged += MergeTexture;
    }

    void OnDisable()
    {
        PlayerMerge.IMerged -= MergeTexture;
    }

    void Awake ()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
        myMaterial.mainTexture = Instantiate(myMaterial.mainTexture);
    }

    void MergeTexture (IsMergeable mergeScript)
    {
        Texture tex = mergeScript.tex;
        texType type = mergeScript.type;

        if (tex != null) {
            myMaterial.mainTexture = MergeNewTex(
                myMaterial.mainTexture as Texture2D,
                tex as Texture2D,
                highlightTextures[(int)type] as Texture2D
             ) as Texture;
        }
    }

    Texture2D MergeNewTex(Texture2D baseTex, Texture2D mergeTex, Texture2D highlightMap)
    {
        Vector2 offset = new Vector2();
        offset.x += Mathf.Round(Random.Range(0, 10));
        offset.y += Mathf.Round(Random.Range(0, 10));

       for (var x = 0; x < baseTex.width; x++) { 
            for (var y = 0; y < baseTex.height; y++)
            {
                offset.x = offset.x > baseTex.width ? -baseTex.width : offset.x;
                offset.y = offset.y > baseTex.height ? -baseTex.height : offset.y;
                float alpha = highlightMap.GetPixel(x + (int) offset.x, y + (int) offset.y).a;
                
                baseTex.SetPixel(x, y,
                    alpha > 0 ? mergeTex.GetPixel(x + (int)offset.x, y + (int)offset.y) * alpha : baseTex.GetPixel(x, y)
                );
            }
        }

        baseTex.Apply();

        return baseTex;
    }
}
