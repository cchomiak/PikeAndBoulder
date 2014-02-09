using UnityEngine;
using System.Collections;

public class MoveDoor : MonoBehaviour 
{
    public Transform targetPosition;

    bool mustMove = false;
    bool finishedMoving = false;

    public float movingSpeed = 1.0f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (mustMove && !finishedMoving)
        {
            Vector3 direction = targetPosition.position - transform.position;
            
            if (direction.magnitude < 0.5f)
            {
                finishedMoving = true;
                return;
            }

            direction.Normalize();

            transform.position += movingSpeed * direction;
        }
	}

    public void MoveTheDoor()
    {
        mustMove = true;
    }
}
