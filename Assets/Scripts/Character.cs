using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float health = 100f;

    public float Health {  get { return health; } }

}

public class Player : Character
{

}

public class Enemy : Character
{
    private float detectionRange = 10f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

}