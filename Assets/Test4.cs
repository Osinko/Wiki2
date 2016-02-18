using UnityEngine;
using System.Collections;

public class Test4 : MonoBehaviour
{
    //二項分布をこのプログラムにより検証してみる
    void Start()
    {
        //表が60%の確率で出るコインを５回投げて表が３枚出る確率を10万回のサンプリングで求めている
        print("シミュレーション結果 : " + Pr(0.6f, 5, 3, 100000));
        print("二項分布の公式利用 : " + nCr(5, 2) * Mathf.Pow(0.6f, 3) * Mathf.Pow(0.4f, 2));
    }

    //組合せ計算
    public int nCr(int n, int r)
    {
        if (n == r || r == 1) return 1;

        int deno = n;
        int nume = 1;
        for (int i = 2; i <= r; n--, i++)
        {
            deno *= (n - 1);
            nume *= i;
        }
        return deno / nume;
    }

    //headCountで表が出る回数を指定しサンプリング後、確率を返す
    private float Pr(float headPercent, int tossCount, int headCount, int Sampling)
    {
        float result = 0;
        for (int i = 0; i < Sampling; i++)
        {
            if (GetHead(headPercent, tossCount) == headCount) result++;
        }
        return result / (float)Sampling;    //確率を返す
    }

    //指定した「表の確率」で試行回数コイントスし表が出た回数を返す
    private int GetHead(float headPercent, int tossCount)
    {
        int head = 0;
        for (int i = 0; i < tossCount; i++)
        {
            if (TossCoin(headPercent) == true) head++;
        }
        return head;
    }

    //指定した表の確率でコイントスして表が出たらtrue、裏でfalseを返す
    public bool TossCoin(float headPercent)
    {
        if (Random.value < headPercent) return true;
        return false;
    }
}
