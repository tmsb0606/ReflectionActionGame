using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class AarrowController : MonoBehaviour
{

    public GameObject targetObj;
    private float direction = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = targetObj.transform.position ;

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenMousePos = new Vector3(mousePos.x, mousePos.y, 10);
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);

        Vector3 vec = (worldMousePos - targetObj.transform.position).normalized;
        this.transform.position = targetObj.transform.position + vec * direction;
        
        float angle =  Vector3.Angle(new Vector3(0,1,0), this.transform.position - targetObj.transform.position);
        if(this.transform.localPosition.x > 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angle*-1);
            
        }
        else
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angle);
        }
        
        
    }
}
