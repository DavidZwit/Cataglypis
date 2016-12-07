using UnityEngine;
using System.Collections;

public class ConvertWeigth : MonoBehaviour {

    static float toMili (float val) { return val * .001f; }
    static float toCenti (float val) { return val * .01f; }
    static float toDeci (float val) { return val * .1f; }

	static float toDeca (float val) { return val * 10; }
    static float toHecto (float val) { return val * 100; }
    static float toKilo (float val) { return val * 1000; }
}
