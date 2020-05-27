using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing=5f;
    Vector3 offset;
    // Start is called before the first frame update
    void Awake(){
        //当没有放入assest的时候其会报错
        Assert.IsNotNull(target);
    }
    void Start()
    {
        //offset=相机地址-人物地址
        offset=transform.position-target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //其目的地是要保持距离不变
        Vector3 targetCamPos =target.position+offset;
        //Lerp的主要用途 smooth 整个动画移动过程
        transform.position=Vector3.Lerp(transform.position,targetCamPos,smoothing*Time.deltaTime);
        
    }
}
