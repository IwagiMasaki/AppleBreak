using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スタートからしばらくしてからリンゴが流れるように空のレーンを最初に流す
/// </summary>
/// 
public class StartLineTransform : MonoBehaviour
{

    public float LaneSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaneMove();

        if(transform.position.x == 20)
        {
            Destroy(gameObject);
        }
    }

    void LaneMove()
    {
        transform.Translate(LaneSpeed * Time.deltaTime , 0, 0);
    }
}
