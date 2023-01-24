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
    private Animator anim;
    private int direction = 0;
    void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        anim = GetComponent<Animator>();

        moveAction = inputs.actions.FindAction("Move");     //Récupère l'Action de déplacement présent dans l'input action du GameManager
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 _moveValue = moveAction.ReadValue<Vector2>();   //Récupère la direction sur laquelle le joueur veut aller
        direction = SetDirection(_moveValue);

        velocity = _moveValue * speed;

        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0); //Transforme mètres par frame en mètres par seconde et applique la force au joueur

        anim.SetInteger("direction", direction); 
    }

    private int SetDirection(Vector2 _vector)   //Renvoie un nombre suivant la direction du joueur servant a jouer la bonne animation
    {
        if(_vector.x > 0)   //Si le joueur vas a droite
        {
            return 6;
        }
        else if(_vector.x < 0)  //Si le joueur vas a gauche
        {
            return 4;
        }

        if(_vector.y > 0)   //Si le joueur vas en haut
        {
            return 8;
        }
        else if(_vector.y < 0)  //Si le joueur vas en bas
        {
            return 2;
        }

        return 0;
    }
}
