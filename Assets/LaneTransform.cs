using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneTransform : MonoBehaviour
{
    //レーンの移動速度（可変）
    public float LaneSpeed;

    //レーンの初期速度（リセット用）
    private float _startLaneSpeed;

    //レーンをリセットする座標
    public float RePositionPoint;

    //画面外にでたレーンをリセットする
    private Vector3 _RePosition;

    //リンゴを出現させるスクリプトたち
    public ApplePop[] ApopScripts;

    //コンボによってふえる速度の変数
    public float ComboLaneSpeed;

    //レーンが動くフラグ
    public bool MoveFlag;

    // Start is called before the first frame update
    void Start()
    {
        MoveFlag = true; //レーンが動き始める（任意のタイミングで可）
        _startLaneSpeed = LaneSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveFlag)
        {
            LaneMove();
        }
    }

    //レーンの移動
    void LaneMove()
    {
        transform.Translate(LaneSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x > RePositionPoint)
        {
            AppleRePosition();
            for(int i = 0; i < ApopScripts.Length; i++)
            {
                ApopScripts[i].AppleRamPop();
            }
        }
    }

    //レーンを巻き戻す
    void AppleRePosition()
    {
        _RePosition = new Vector3(-RePositionPoint, 0, 0);
        transform.position = _RePosition;
    }


    //コンボが加算するごとにレーンのスピードを上げる
    public void LaneSpeedUp()
    {
        LaneSpeed = LaneSpeed + ComboLaneSpeed;
    }

    public void LaneSpeedDown()
    {
        LaneSpeed = LaneSpeed - ComboLaneSpeed * 2;
    }

    //コンボが切れると元の速度に戻る
    public void LaneSpeedReset()
    {
        LaneSpeed = _startLaneSpeed;
    }
}
