using UnityEngine;
using System.Collections;

public class OnAndOff : MonoBehaviour 
{
    Timer onoffTimer;
    public float timeInterval = 1.0f;
    bool isOn = true;

	// Use this for initialization
	void Start () 
    {
        onoffTimer = new Timer(timeInterval, true, false);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (onoffTimer.Update() == TimerState.FINISHED)
        {
            isOn = !isOn;
            guiText.enabled = isOn;
        }
	}
}
