using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePop : MonoBehaviour
{

    //乱数を格納する変数
    public int RandomInt;

    //悪いリンゴが出現する確率
    public int PoisonRandomPop;

    //虫食いリンゴが出現する確率
    public int BugRandomPop;

    private GameObject _appleOBJ;   //リンゴobject
    public GameObject GoodApple; 　 //良いリンゴ
    public GameObject PoisonApple;　//毒リンゴ
    public GameObject BugApple;     //虫食いリンゴ

    // Start is called before the first frame update
    void Start()
    {
        AppleRamPop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ランダムでリンゴをポップする
    public void AppleRamPop()
    {
        RandomInt = 0;
        RandomInt = Random.Range(1,6);
        switch(RandomInt)
        {
            case 1:
                _appleOBJ = (GameObject)Instantiate(PoisonApple, transform.position, Quaternion.identity);
                break;

            case 2:
                _appleOBJ = (GameObject)Instantiate(BugApple, transform.position, Quaternion.identity);
                break;
            default:
                _appleOBJ = (GameObject)Instantiate(GoodApple, transform.position, Quaternion.identity);
                break;
        }

        _appleOBJ.transform.parent = gameObject.transform;
    }
}
