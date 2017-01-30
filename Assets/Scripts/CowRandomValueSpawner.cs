using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CowRandomValueSpawner : MonoBehaviour
{

    private List<float> numbers = new List<float> { };
    private float startValue = 1;
    [SerializeField]
    private float endValue = 20;
    [SerializeField]
    private GameObject cowObject;
    [SerializeField]
    private List<Transform> spawnPoints;
    [SerializeField]
    private PressurPlate plate;
    [SerializeField]
    private TextMesh levelText;
    void Start()
    {
        levelText.text = "lvl " + Dificulty.level;

        plate.MinWeight = (int)endValue;
        SpawnCows();
    }
    void SpawnCows()
    {
        float totalValue = startValue;
        while (totalValue < endValue)
        {
            float tempNumber = Mathf.Round(totalValue * Random.Range(10, 10)) / 10;
            numbers.Add(tempNumber);
            totalValue += tempNumber;
        }
        for (int i = 0; i < numbers.Count; i++)
        {
            int j = Random.Range(0, spawnPoints.Count);
            GameObject tempObject = Instantiate(cowObject, spawnPoints[j].position, Quaternion.identity) as GameObject;
            tempObject.GetComponent<IsMergeable>().size = numbers[i];
            spawnPoints.Remove(spawnPoints[j]);
        }
    }

}
