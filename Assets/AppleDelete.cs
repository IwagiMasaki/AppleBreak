using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleDelete : MonoBehaviour
{

    //コンボの加算減算ようにスクリプトを参照
    //public ConboScript ComboSC;

    public ScoreAndCombo ScoreScript;

    //コンボによってスピードを変えるためにスクリプトを参照
    public LaneTransform[] LaneTransformScript;

    //for用変数
    int i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "GoodApple":
                ScoreScript.addScore();
                for(i = 0; i < LaneTransformScript.Length; i++)
                {
                    LaneTransformScript[i].LaneSpeedUp();
                }
                Destroy(other.gameObject);
                break;

            case "PoisonApple":
                ScoreScript.poisonApple();
                for (i = 0; i < LaneTransformScript.Length; i++)
                {
                    LaneTransformScript[i].LaneSpeedReset();
                }
                Destroy(other.gameObject);
                break;

            case "BugApple":
                ScoreScript.bugApple();
                for (i = 0; i < LaneTransformScript.Length; i++)
                {
                    LaneTransformScript[i].LaneSpeedDown();
                }
                Destroy(other.gameObject);
                break;
        }
    }
}
