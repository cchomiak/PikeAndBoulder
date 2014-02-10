using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
        else if (!Input.GetKeyDown(KeyCode.Escape) && Input.anyKeyDown)
        {
            Application.LoadLevel(2);
        }
	}
}
