using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    [SerializeField]
    Button nextPhase;
    [SerializeField]
    Button endTurn;
    [SerializeField]
    Text enemyLP;
    [SerializeField]
    Text playerLP;
    [SerializeField]
    Text mainPhase;
    [SerializeField]
    Text battlePhase;
    [SerializeField]
    Text winOrLose;

    public static bool playerTurn = true;
    private bool phase = true;
    private int enemyPoints = 4000;
    private int playerPoints = 4000;

    // Use this for initialization
    void Start ()
    {
        mainPhase.color = Color.red;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
		if(!playerTurn)
        {
            nextPhase.enabled = false;
            nextPhase.GetComponent<Image>().enabled = false;
            nextPhase.GetComponentInChildren<Text>().enabled = false;
            endTurn.enabled = false;
            endTurn.GetComponent<Image>().enabled = false;
            endTurn.GetComponentInChildren<Text>().enabled = false;
        }
	}

    public bool getTurn()
    {
        return playerTurn;
    }

    public bool getPhase()
    {
        return phase;
    }

    public void changeTurn()
    {
        if (playerTurn)
        {
            playerTurn = false;
            battlePhase.color = Color.black;
        }
        else if (!playerTurn)
        {
            playerTurn = true;
            mainPhase.color = Color.red;
        }
    }

    public void changePhase()
    {
        if (phase)
        {
            phase = false;
            mainPhase.color = Color.black;
            battlePhase.color = Color.red;
        }
    }

    public void reduceEnemyLP(int damage)
    {
        if (!phase)
        {
            if (damage < enemyPoints)
                enemyPoints -= damage;
            else
            {
                enemyPoints = 0;
                winOrLose.text = "You Win!";
                winOrLose.enabled = true;
            }
            enemyLP.text = "Enemy LP: " + enemyPoints;
        }
    }

    public void gainPlayerLP(int points)
    {
        if (!phase)
        {
            playerPoints += points;
            playerLP.text = "Player LP: " + playerPoints;
        }
    }
}
