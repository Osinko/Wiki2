using UnityEngine;
using System.Collections;

public class test1 : MonoBehaviour
{
    void Start()
    {
        print(Digit(123456789, 6));     //７桁目を表示（変数digは0を含んでカウントしている）
    }

    public  int Digit(int value, int dig) {
        int n=1;
        for (int i = 0; i < dig; i++) { n *= 10; }
        int temp = value / n;
        return temp%10;
    }
}
