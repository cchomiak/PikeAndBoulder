using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchZone : MonoBehaviour 
{
    Player player;

    bool showHint = false;
    public GameObject hint;
    
    public GameObject SwitchSoundPrefab;
    public MoveDoor door;

    //Objeto que se modifica con este switch
    //
    
    // Use this for initialization
    void Start()
    {
        hint.SetActive(false);
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        hint.SetActive(false);
    }

    void OnTriggerEnter(Collider cInfo)
    {
        if (cInfo.gameObject.tag == player.gameObject.tag)
        {
            showHint = true;
            hint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider cInfo)
    {
        if (cInfo.gameObject.tag == player.gameObject.tag)
        {
            showHint = false;
            hint.SetActive(false);
        }
    }

    void OnTriggerStay(Collider cInfo)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchSoundPrefab.Clone(transform.parent);
            hint.SetActive(false);
            door.MoveTheDoor();
            Destroy(this);
        }
    }

    /*void OnGUI()
    {
        if (!showHint)
            return;


    }*/

}
