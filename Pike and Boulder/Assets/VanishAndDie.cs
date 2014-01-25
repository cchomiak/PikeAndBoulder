using UnityEngine;
using System.Collections;

public class VanishAndDie : MonoBehaviour {

    Timer vanishTimer, destroyTimer, waitingTime;
    bool isVisible = true;

	// Use this for initialization
	void Start () 
    {
        destroyTimer= new Timer(5);
        vanishTimer = new Timer(0.5f, true, false);
        waitingTime = new Timer();
	}
	
	// Update is called once per frame
	void Update () 
    {
        TimerState ts = destroyTimer.Update();
        if (ts == TimerState.FINISHED)
            Destroy(gameObject);
        else if (ts == TimerState.ONGOING)
        {
            if (waitingTime.Update() == TimerState.FINISHED)
                if (vanishTimer.Update() == TimerState.FINISHED)
                {
                    isVisible = !isVisible;
                    gameObject.SetVisualRecursively(isVisible);
                }
        }
	}
}
