using UnityEngine;
using System.Collections;

public class AddCoins : MonoBehaviour 
{

    public int numberOfCoins = 10;

    public Timer coinsAddTimer;

    Player player;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        coinsAddTimer = new Timer(0.25f, true, false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (coinsAddTimer.Update() == TimerState.FINISHED)
        {
            player.score += numberOfCoins;
        }
	}
}
