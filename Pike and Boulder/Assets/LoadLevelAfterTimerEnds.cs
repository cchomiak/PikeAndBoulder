using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LoadLevelAfterTimerEnds : MonoBehaviour 
{
    Timer timer, logoTimer;
    public float totalTime = 3f;
    public float timeForEachLogo = 1.5f;

    public List<Texture2D> logos;
    int currentLogo = -1;

	// Use this for initialization
	void Start () 
    {
        timer = new Timer(totalTime);
        logoTimer = new Timer(timeForEachLogo, true, false);

        if (logos != null && logos.Count > 0)
            currentLogo = -1;

        ChangeLogo();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (timer.Update() == TimerState.FINISHED)
        {
            Application.LoadLevel(1);
            return;
        }

        if (logoTimer.Update() == TimerState.FINISHED)
        {
            ChangeLogo();
        }
	}

    void ChangeLogo()
    {
        if (currentLogo >= logos.Count - 1)
            return;

        currentLogo = Mathf.Min(currentLogo + 1, logos.Count - 1);

        Debug.Log("Current: " + currentLogo);

        renderer.material.mainTexture = logos[currentLogo];
    }
}
