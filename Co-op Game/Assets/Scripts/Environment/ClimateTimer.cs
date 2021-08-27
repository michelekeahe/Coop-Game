using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClimateTimer : MonoBehaviour
{
    #region Component
    public Image tempBar;
    #endregion

    #region Serialized Variables
    [SerializeField]
    private float currentTempTime = 60f;
    [SerializeField]
    private float totalTempTime = 60f;
    #endregion

    #region private variables
    private float timeRemaining;
    private bool timerIsOn;
    #endregion


    private void Update()
    {
        TempCountDown();
    }

    //starts tempature countdown
    public void TempCountDown()
    {
        if (timerIsOn && currentTempTime > 0)
        {
            currentTempTime = currentTempTime - Time.deltaTime;
        }
        timeRemaining = currentTempTime / totalTempTime;
        tempBar.fillAmount = timeRemaining;
    }


    //can be deleted later. When button is pressed, toggles countdown.
    public void StartCountDown()
    {
        timerIsOn = !timerIsOn;
    }


}
