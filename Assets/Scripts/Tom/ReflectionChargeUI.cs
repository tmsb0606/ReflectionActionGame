using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReflectionChargeUI : MonoBehaviour
{
    public Image chargeImage;
    public Image frameImage;
    public TextMeshProUGUI boundCountText;
    public PlayerStateManager playerStateManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(playerStateManager.currentState.boundCount);
        chargeImage.fillAmount = (float)playerStateManager.currentState.boundCount / 5;
        boundCountText.text = playerStateManager.currentState.boundCount.ToString();
        if (playerStateManager.currentState.boundCount == 0)
        {
            chargeImage.color = new Color(255, 255, 255);
            //frameImage.color = new Color(255, 255, 255);
        }
        if (playerStateManager.currentState.boundCount == 1)
        {
            chargeImage.color = new Color(0,0,255);
           // frameImage.color = new Color(0, 0, 255);
        }
        if (playerStateManager.currentState.boundCount == 2)
        {
            chargeImage.color = new Color(255, 255, 0);
           // frameImage.color = new Color(255, 255, 0);
        }
        if (playerStateManager.currentState.boundCount == 3)
        {
            chargeImage.color = new Color(0, 255, 0);
           // frameImage.color = new Color(0, 255, 0);
        }
        if (playerStateManager.currentState.boundCount == 4)
        {
            chargeImage.color = new Color(255, 0, 0);
            //frameImage.color = new Color(255, 0, 0);
        }
        if (playerStateManager.currentState.boundCount == 5)
        {
            chargeImage.color = new Color(255, 0, 255);
           // frameImage.color = new Color(255, 0, 255);
        }
    }
}
