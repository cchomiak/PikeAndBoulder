using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float desiredAspectW;
    public float desiredAspectH;

    public float currentTimer;

    public float targetAspect;
    public float minAspectTarget = 12.9f, maxAspectTarget = 24f;
    public bool isFat = false;

    public Transform fatWorker;
    public Vector3 fatWorkerScale = new Vector3(1.3f, 1.48f, 1.3f);

    public float fatRadius, slimRadius;
    public Camera theCamera;

    // Use this for initialization
    void Start()
    {
        currentTimer = 0.5f;

        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        float targetaspect = desiredAspectW / desiredAspectH; // 16.0f / 9.0f;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain theCamera component so we can modify its viewport
        //theCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (isFat)
        {
            //theCamera.aspect = 12.9f / 9f;
            //targetAspect = 12.9f;
            minAspectTarget = 24f;
            maxAspectTarget = 12.9f;
            currentTimer = 0;
            isFat = false;

            fatWorker.localScale = fatWorkerScale / 10f; // new Vector3(0.6666f, 1, 0.6666f);
            GetComponent<CharacterController>().radius = slimRadius;
        }
        else if (!isFat)
        {
            //theCamera.aspect = 24f / 9f;
            //targetAspect = 24f;
            minAspectTarget = 12.9f;
            maxAspectTarget = 24f;
            currentTimer = 0;
            isFat = true;
            fatWorker.localScale = fatWorkerScale; // new Vector3(1.5f, 1, 1.5f);
            GetComponent<CharacterController>().radius = fatRadius;
        }

        if (true)
        {
            theCamera.aspect = targetaspect;
            return;
        }

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = theCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            theCamera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = theCamera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            theCamera.rect = rect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float targetAspect = 0f;

        currentTimer += Time.deltaTime;
        currentTimer = Mathf.Min(0.5f, currentTimer);

        float timeProgress = currentTimer / 0.5f;

        if (currentTimer < 0.5f)
        {
            targetAspect = Mathf.Lerp(minAspectTarget, maxAspectTarget, timeProgress);
            Debug.Log("targetAspect: " + targetAspect);

            theCamera.aspect = targetAspect / 9f;
        }

        if (isFat && Input.GetKey(KeyCode.LeftControl))
        {
            //theCamera.aspect = 12.9f / 9f;
            //targetAspect = 12.9f;
            minAspectTarget = 24f;
            maxAspectTarget = 12.9f;
            currentTimer = 0;
            isFat = false;

            fatWorker.localScale = fatWorkerScale / 10f; // new Vector3(0.6666f, 1, 0.6666f);
            GetComponent<CharacterController>().radius = slimRadius;
        }
        else if (!isFat && Input.GetKey(KeyCode.RightControl))
        {
            //theCamera.aspect = 24f / 9f;
            //targetAspect = 24f;
            minAspectTarget = 12.9f;
            maxAspectTarget = 24f;
            currentTimer = 0;
            isFat = true;
            fatWorker.localScale = fatWorkerScale; // new Vector3(1.5f, 1, 1.5f);
            GetComponent<CharacterController>().radius = fatRadius;
        }
        //theCamera.aspect = desiredAspectW / desiredAspectH;	
    }
}
