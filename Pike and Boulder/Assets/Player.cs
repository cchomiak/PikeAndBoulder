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

    public float fatWalkSpeed, slimWalkSpeed;
    public float fatJump, slimJump;

    public float fatAspect, slimAspect;

    public float fatPushPower, slimPushPower;

    float pushPower;

    // Use this for initialization
    void Start()
    {
        currentTimer = 0.5f;

        if (isFat)
        {
            GetFat();
        }
        else if (!isFat)
        {
            GetSlim();
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

            GetSlim();
        }
        else if (!isFat && Input.GetKey(KeyCode.RightControl))
        {
            //theCamera.aspect = 24f / 9f;
            //targetAspect = 24f;
            GetFat();
        }
        //theCamera.aspect = desiredAspectW / desiredAspectH;	
    }

    void GetSlim()
    {
        minAspectTarget = fatAspect;
        maxAspectTarget = slimAspect;
        currentTimer = 0;
        isFat = false;

        fatWorker.localScale = fatWorkerScale / 10f; // new Vector3(0.6666f, 1, 0.6666f);
        GetComponent<CharacterController>().radius = slimRadius;

        GetComponent<ThirdPersonController>().walkSpeed = slimWalkSpeed;
        GetComponent<ThirdPersonController>().jumpHeight = slimJump;

        pushPower = slimPushPower;
    }

    void GetFat()
    {
        minAspectTarget = slimAspect;
        maxAspectTarget = fatAspect;
        currentTimer = 0;
        isFat = true;
        fatWorker.localScale = fatWorkerScale; // new Vector3(1.5f, 1, 1.5f);
        GetComponent<CharacterController>().radius = fatRadius;

        GetComponent<ThirdPersonController>().walkSpeed = fatWalkSpeed;
        GetComponent<ThirdPersonController>().jumpHeight = fatJump;

        pushPower = fatPushPower;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }

}
