using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonsterCard : MonoBehaviour
{

    [SerializeField]
    public Text points;
    [SerializeField]
    GameObject gameMaster;
    [SerializeField]
    int attack;
    [SerializeField]
    public Button attackButton;

    private Transform myTransform;
    private Transform pointsTransform;
    private Vector3 upPos;
    private Vector3 originalPos;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
}
