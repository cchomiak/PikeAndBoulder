using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour 
{
    Timer endingTimer;

	// Use this for initialization
	void Start () 
    {
        endingTimer = new Timer(5);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (endingTimer.Update() == TimerState.FINISHED)
        {
            Application.LoadLevel("Menu");
        }
	}
}
