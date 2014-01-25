using UnityEngine;
using System.Collections;

public class NoChangeZone : MonoBehaviour 
{
    Player player;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnTriggerEnter(Collider cInfo)
    {
        if (cInfo.gameObject.tag == player.gameObject.tag)
        {
            player.canChange = false;
        }
    }

    void OnTriggerExit(Collider cInfo)
    {
        if (cInfo.gameObject.tag == player.gameObject.tag)
        {
            player.canChange = true;
        }
    }

}
