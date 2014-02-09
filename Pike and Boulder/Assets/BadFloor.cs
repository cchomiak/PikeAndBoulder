using UnityEngine;
using System.Collections;

public class BadFloor : MonoBehaviour 
{

    Player player;

    //Objeto que se modifica con este switch
    //

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter(Collider cInfo)
    {
        Application.LoadLevel(3);
        /*if (cInfo.gameObject.tag == player.gameObject.tag)
        {
        }*/
    }

}
