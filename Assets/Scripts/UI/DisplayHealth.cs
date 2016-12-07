using UnityEngine;
using UnityEngine.UI;
public class DisplayHealth : MonoBehaviour {

    [SerializeField]
    private Image[] heartImages;

    public void UpdateDisplay(int lives)
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i <= lives-1)
                heartImages[i].gameObject.SetActive(true);
            else
                heartImages[i].gameObject.SetActive(false);
        }
    }
}
