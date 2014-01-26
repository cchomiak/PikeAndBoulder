using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HintZone : MonoBehaviour 
{
    Player player;

    bool showHint = false;
    public GameObject hint;

    public List<ExplodableBox> objectsToExploded;

    // Use this for initialization
    void Start()
    {
        hint.SetActive(false);
        
        
        if (objectsToExploded == null)
            objectsToExploded = new List<ExplodableBox>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        hint.SetActive(false);
    }

    void OnTriggerEnter(Collider cInfo)
    {
        if (!player.isFat)
            return;

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
        if (!player.isFat)
            return;

        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (ExplodableBox eb in objectsToExploded)
            {
                if (eb != null)
                    eb.Explode();
            }
            objectsToExploded.Clear();
            hint.SetActive(false);
            Destroy(gameObject);
        }
    }

    /*void OnGUI()
    {
        if (!showHint)
            return;


    }*/

}
