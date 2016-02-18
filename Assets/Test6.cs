using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Test6 : MonoBehaviour
{

    void Start()
    {
        print("計算で求めた値：" + (10f / (3f + 1f) + 3f / (10f + 1f)));
        print("シミュレーション値:"+Sampling(10, 3, 100000));

        print("計算で求めた値：" + (100f / (2f + 1f) + 2f / (100f + 1f)));
        print("シミュレーション値:" + Sampling(100, 2, 100000));

        //Rest(10, 3,true);
    }

    //サンプリングして平均値を返す
    float Sampling(int whiteBall, int blackBall, int loopCount)
    {
        int rest = 0;
        for (int i = 0; i < loopCount; i++)
        {
            rest += Rest(whiteBall, blackBall);
        }
        return (float)rest / (float)loopCount;
    }

    //シミュレーション。残り個数を返す
    int Rest(int whiteBall, int blackBall,bool debug=false)
    {
        int whiteCount = 0;
        int blackCount = 0;
        int pointer = 0;

        bool[] quary = ShuffleBall(whiteBall, blackBall);
        for (int i = 0; i < quary.Length; i++)
        {
            pointer++;
            if (quary[i] == true) whiteCount++;
            else blackCount++;

            if (whiteCount >= whiteBall) break;
            if (blackCount >= blackBall) break;
        }

        //参考用（中身を視覚的に確認できる）
        if (debug)
        {
            foreach (var item in quary)
            {
                print(item);
            }
            print(quary.Length);
            print(pointer);
            print(quary.Length - pointer);
        }

        return quary.Length - pointer;
    }

    //標本空間上のボールをシャッフル
    bool[] ShuffleBall(int whiteBall, int blackBall)
    {
        bool[] query = GetBall(whiteBall, blackBall).ToArray();

        //書籍「ゲームの作り方unityで覚える遊びのアルゴリズム」よりP114のシャッフルアルゴリズムの応用
        //念のため３回全体シャッフルしている
        //（３回以下だとこのアルゴリズムでは偏りがあった）
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < query.Length - 1; i++)
            {
                int pointer = Random.Range(i + 1, query.Length);
                bool temp = query[pointer];
                query[pointer] = query[i];
                query[i] = temp;
            } 
        }

        return query;
    }

    //白玉と黒玉の標本空間を作成
    IEnumerable<bool> GetBall(int whiteBall, int blackBall)
    {
        for (int i = 0; i < whiteBall; i++)
        {
            yield return true;  //trueが白玉
        }

        for (int i = 0; i < blackBall; i++)
        {
            yield return false;  //falseが黒玉
        }
    }
}
