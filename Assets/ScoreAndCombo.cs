using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAndCombo : MonoBehaviour
{
    //スコアの表示テキスト
    [SerializeField] private TextMeshProUGUI scoreUI;
    //スコア
    //public static int gameScore;
    public int gameScore;
    //減点数
    private const int DEDUCT = 100;
    //加点数
    private const int ADD = 100;
    //コンボ数
    public int combo;
    //コンボボーナス
    private const int COMBO_BONUS = 3000;

    //Timerスクリプト
    public TimerCopy TimerScript;

    //怒りゲージのスクリプト
    public AngerGaugeCopy AngerGaugeScript;

    // Start is called before the first frame update
    void Start()
    {

        //初期化
        gameScore = 0;
        combo = 0;
        scoreUI.text = gameScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //スコア加算
    public void addScore()
    {
        //Debug.Log("スコア加算");
        //コンボを加算する
        combo += 1;
        //スコアを100加算する
        gameScore += ADD;

        if(combo % 5 == 0 && combo != 0)
        {
            if (!AngerGaugeScript.AngerFlag)
            {
                TimerScript.CountAdd();
                AngerGaugeScript.DownGauge();
            }
        }

        if (combo % 30 == 0)
        {
            gameScore += COMBO_BONUS;
        }
        //スコアの文字色を黄緑に変更
        scoreUI.color = new Color(0.5f, 0.8f, 0.0f, 0.9f);
        //スコアの表示
        scoreUI.text = gameScore.ToString();
    }

    //スコア減算(スコアは0より小さくならない)
    public void poisonApple()
    {
        //毒りんごを流してしまった
        //コンボが切れる
        combo = 0;
        //Debug.Log("スコア減算");
        //スコアが減点量より少ない場合スコアは0とする
        if (gameScore < DEDUCT)
        {
            gameScore = 0;
        }//スコアが減点より高い場合減点する
        else
        {
            gameScore -= DEDUCT;
        }
        //スコアの文字色を赤色にする
        scoreUI.color = new Color(1.0f, 0.0f, 0.0f, 0.7f);
        //スコアの表示
        scoreUI.text = gameScore.ToString();
    }

    //スコア減算(スコアは0より小さくならない)
    public void bugApple()
    {    //虫食いりんごを流してしまった場合
        //コンボが切れる
        //combo = 0;
        //スコアが減点量より少ない場合スコアは0にする
        if (gameScore < (DEDUCT / 2))
        {
            gameScore = 0;
        }
        //スコアが減点量より高い場合減点量の半分の減点
        else
        {
            gameScore -= (DEDUCT / 2);
        }
        //スコアの文字色を赤色にする
        scoreUI.color = new Color(1.0f, 0.0f, 0.0f, 0.7f);
        //スコアの表示
        scoreUI.text = gameScore.ToString();
    }

}
