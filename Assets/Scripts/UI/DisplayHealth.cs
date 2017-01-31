using UnityEngine;
using UnityEngine.UI;
public class DisplayHealth : MonoBehaviour {

    [SerializeField]
    private Image[] heartImages;

    public void UpdateDisplay(int lives)
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            Animation anim = heartImages[i].GetComponent<Animation>();
            if (i <= lives - 1)
                anim.Play("HeartGrow");
            else if (i == lives)
                anim.Play();
        }
    }
}
