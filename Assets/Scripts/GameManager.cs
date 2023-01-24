using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private PlayerInput inputs;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y as plus d'une instance de GameManager");
        }

        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public PlayerInput GetInputs()
    {
        return inputs;
    }
}
