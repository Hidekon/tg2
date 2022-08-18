using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 60f;
    public RespawnTarget RT;

    [SerializeField] TextMeshProUGUI countdownText;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
     
        
        if (RT.isCounting == true)
           {
            if (currentTime >= 0)
            {
                currentTime -= 1 * Time.deltaTime;
                countdownText.text = currentTime.ToString("00.00");
            }
            else
            {
                countdownText.text = "STOP";
                RT.isCounting = false;
            }
        }
    }
}
