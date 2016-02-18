using UnityEngine;
using System.Collections;

public class test2 : MonoBehaviour {

    public float a=0;

	void Start () {
        a = 9f - 3f / (1f / 3f) + 1f;
        print(a);
    }
	
}
