using UnityEngine;
using System.Collections;

public class Test3 : MonoBehaviour {

    void Start () {
        print("期待値の検証");
        int totalGuarantee = 0;
        int loop= 1000000;  //試行回数

        for (int i = 0; i < loop; i++)
        {
            int guaranty = Random.Range(1, 7) * 100;    //1～6のサイコロを振って、出目に100倍
            totalGuarantee += guaranty;
        }

        float result= (float)totalGuarantee / (float)loop;
        print(result);

        print("理論値" + ((100f * (1f / 6f)) +
            (200f * (1f / 6f)) +
            (300f * (1f / 6f)) +
            (400f * (1f / 6f)) +
            (500f * (1f / 6f)) +
            (600f * (1f / 6f))));
    }
	
}
