using UnityEngine;
using System.Collections;

public class NoChangeZone : MonoBehaviour 
{
    Player player;

    public GameObject hint;


	// Use this for initialization
	void Start () 
    {
        hint.SetActive(false);
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
            hint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider cInfo)
    {
        if (cInfo.gameObject.tag == player.gameObject.tag)
        {
            player.canChange = true;
            hint.SetActive(false);
        }
    }

}
