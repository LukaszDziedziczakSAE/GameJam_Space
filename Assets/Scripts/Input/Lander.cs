using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lander : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] InputReader input;
    [SerializeField] float jumpForce;
    [SerializeField] ParticleSystem engineExhaust;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float heightOffset;
    [SerializeField] float maxTilt;
    [SerializeField] float tiltSpeed;

    private void Update()
    {
        if (input.JumpPressed && DistanceToGround < 100f)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Acceleration);
            if (!engineExhaust.isPlaying) engineExhaust.Play();
        }

        else if (!input.JumpPressed && engineExhaust.isPlaying) engineExhaust.Stop();


        if (input.Movement.magnitude > 0)
        {
            Vector3 shipRotation = transform.eulerAngles;

            if (input.Movement.y > 0)
            {
                /*if (shipRotation.x < maxTilt)*/ shipRotation.x += input.Movement.y * tiltSpeed * Time.deltaTime;
            }

            else if (input.Movement.y < 0)
            {
                
                /*if (shipRotation.x > -maxTilt)*/ shipRotation.x += input.Movement.y * tiltSpeed * Time.deltaTime;
            }

            if (input.Movement.x > 0)
            {
                /*if (shipRotation.z < maxTilt)*/ shipRotation.z -= input.Movement.x * tiltSpeed * Time.deltaTime;
            }

            else if (input.Movement.x < 0)
            {
                /*if (shipRotation.z > -maxTilt)*/ shipRotation.z -= input.Movement.x * tiltSpeed * Time.deltaTime;
            }

            transform.eulerAngles = shipRotation;
        }
    }

    public float DistanceToGround
    {
        get
        {
            if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out RaycastHit hit, 1000, groundLayer))
            {
                float distance = Vector3.Distance(transform.position, hit.point);
                return distance - heightOffset;
            }

            return 0;
        }
    }
}

