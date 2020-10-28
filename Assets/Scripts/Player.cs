using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    //[SerializeField] private "exposes" the variable to the unity UI but can not be accessed by other scripts
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start() {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        // Make player jump when space is pressed
        if( Input.GetKeyDown(KeyCode.Space) )
            jumpKeyPressed = true;

        horizontalInput = Input.GetAxis("Horizontal");
    }

    //Called once every physics update
    private void FixedUpdate() {
        
        rigidbodyComponent.velocity = new Vector3(horizontalInput,rigidbodyComponent.velocity.y,0); 

        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
            return;


        if( jumpKeyPressed ) {
           rigidbodyComponent.AddForce(Vector3.up*4, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }

    }

}
