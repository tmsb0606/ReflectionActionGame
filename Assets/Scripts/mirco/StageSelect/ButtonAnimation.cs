using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] Button btn;

    [SerializeField] Vector3 upScale;


    public void ScaleUpAnim()
    {
        LeanTween.scale(this.gameObject, upScale, 0.1f);
    }

    public void ScaleDownAnim()
    {
        LeanTween.scale(this.gameObject, Vector3.one, 0.1f);
    }

    public void Rotate()
    {
        LeanTween.rotateAround(this.gameObject, Vector3.forward, -360, 10f).setLoopClamp();
    }

    public void ReverseRotate()
    {
        LeanTween.cancel(this.gameObject);
        LeanTween.rotate(this.gameObject, Vector3.zero, 0.1f);
    }
}
