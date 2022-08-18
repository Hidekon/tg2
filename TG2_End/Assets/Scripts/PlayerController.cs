using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController playerControl;
    Vector3 moveVector;
    Vector3 rotateVector;
    public Transform trans;
    [SerializeField] float speed = 10f;

    
    private void Start()
    {
        playerControl = GetComponent<CharacterController>();
        
    }

    private void FixedUpdate()
    {
        
        playerControl.Move(moveVector * speed * Time.fixedDeltaTime);
        trans.Rotate(rotateVector * Time.fixedDeltaTime * 8 * speed);
                        
        Debug.Log(trans.rotation);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
    }

    public void MoveArms(InputAction.CallbackContext context)
    {
        Vector3 rotation = context.ReadValue<Vector3>();
        rotateVector = new Vector3(rotation.x, rotation.y, rotation.z);
    }

}
