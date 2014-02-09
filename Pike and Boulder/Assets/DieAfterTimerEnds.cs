using UnityEngine;
using System.Collections;

public class DieAfterTimerEnds : MonoBehaviour 
{
    Timer timer;

    public float lifetime;

	// Use this for initialization
	void Start () 
    {
        timer = new Timer(lifetime);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (timer.Update() == TimerState.FINISHED)
            Destroy(gameObject);
	}
}
