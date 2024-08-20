using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI resultText;
    float time = 0f;
    public bool isStop = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            time += Time.deltaTime;
        }
        else
        {
            timeText.gameObject.SetActive(false);
        }
        
        timeText.text = ((int)time).ToString();
        resultText.text = timeText.text+"sec";
    }
}
