using UnityEngine;
using System.Collections;

public class SettingTimeScale : MonoBehaviour {

	void Start () {
        SetTimeScale(1f);
	}
	
    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
