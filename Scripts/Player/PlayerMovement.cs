using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody boxRigid;

    [SerializeField]
    private float horizontalInput, horizontalSpeed, verticalInput, verticalSpeed;


    private void Start()
    {
        boxRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = -1 * horizontalInput * horizontalSpeed * Time.fixedDeltaTime;
        float verticalVelocity = -1 * verticalInput * verticalSpeed * Time.fixedDeltaTime;

        Vector3 updateVelocity = new Vector3(horizontalVelocity, 0f, verticalVelocity);
        boxRigid.velocity = updateVelocity;
    }
}
