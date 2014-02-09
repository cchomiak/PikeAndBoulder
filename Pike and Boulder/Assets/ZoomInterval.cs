using UnityEngine;
using System.Collections;

public class ZoomInterval : MonoBehaviour 
{

    Timer timer;

    public float lifetime;

    public float minW, maxW, minH, maxH;

    public float currentPercentage;

    // Use this for initialization
    void Start()
    {
        timer = new Timer(lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        timer.Update();
        
        if (timer.CurrentState == TimerState.FINISHED)
            return;

        currentPercentage = timer.PercentageRemaining;


        float width = Mathf.Lerp(minW, maxW, 1 - currentPercentage);
        float height = Mathf.Lerp(minH, maxH, 1 - currentPercentage);

        transform.localScale = new Vector3(width, height, 1);
    }

}
