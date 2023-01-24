using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput inputs;
    private GameManager manager;
    private InputAction moveAction;
    private Vector2 velocity = Vector2.zero;
    [SerializeField] private float speed = 5f;
    void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();

        moveAction = inputs.actions.FindAction("Move");     //Récupère l'Action de déplacement présent dans l'input action du GameManager
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 _moveValue = moveAction.ReadValue<Vector2>();   //Récupère la direction sur laquelle le joueur veut aller

        velocity = _moveValue * speed;

        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0); //Transforme mètres par frame en mètres par seconde et applique la force au joueur
    }
}
