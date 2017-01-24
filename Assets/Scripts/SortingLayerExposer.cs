using UnityEngine;
using System.Collections;

public class SortingLayerExposer : MonoBehaviour
{
    [SerializeField]
    private int SortingOrder = 1;

    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().sortingOrder = SortingOrder;
    }
}


