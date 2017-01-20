using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomizeWeights : MonoBehaviour {

	
}

class Area
{
    private List<IsMergeable> _mergables;

    private void RandomizeValues(int _in, int _out)
    {
        var rnd = new System.Random();
        var result = _mergables.OrderBy(item => rnd.Next());

        int tot = _in;
        int margin = 2;
        int lastRand = 0;

        

        foreach (var mergeScript in result)
        {
            lastRand = Mathf.RoundToInt(Random.Range(-margin, margin));

            tot += lastRand;
            mergeScript.size = lastRand + tot;
        }
    }
}
