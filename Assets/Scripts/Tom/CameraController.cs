using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _targetObj;
    [SerializeField] private Vector3 offsetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの位置をキューブに合わせる
        Vector3 vecCameraPos = _targetObj.transform.position;
        vecCameraPos.y += 1.0f;
        vecCameraPos.z -= 10.0f;
        transform.position = vecCameraPos + offsetPos;
    }
}
