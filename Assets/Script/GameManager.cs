using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private string playerTag;

    public Transform player { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }
}
