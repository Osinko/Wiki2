using UnityEngine;
using System.Collections;

public class Test5 : MonoBehaviour
{

    //求めた確率の値が正しい事を検証する
    void Start()
    {
        //コインを３回投げて
        //「表が１枚以上出ている場合の数」を母数に
        //「表が３枚出ている場合の数」を分子にして
        //確率を10万回のサンプリングで求めている
        print("シミュレーション結果 : " + Pr(100000));
        print("二項分布の公式利用 : " + ((float)nCr(3, 0) / (float)(nCr(3, 0) + nCr(3, 1) + nCr(3, 2))));
    }

    //指定回数サンプリング後、確率を返す
    private float Pr(int Sampling)
    {
        float deno = 0;
        float nume = 0;
        for (int i = 0; i < Sampling; i++)
        {
            int coin = GetHead(0.5f, 3);
            if (coin >= 1) deno++;          //「表が１枚以上出ている場合の数」を母数に
            if (coin == 3) nume++;          //「表が３枚出ている場合の数」を分子にして
        }
        return (float)nume / (float)deno;    //確率を返す
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

    //組合せ計算
    public int nCr(int n, int r)
    {
        if (n == r || r == 0) return 1;

        int deno = n;
        int nume = 1;
        for (int i = 2; i <= r; n--, i++)
        {
            deno *= (n - 1);
            nume *= i;
        }
        return deno / nume;
    }

}
