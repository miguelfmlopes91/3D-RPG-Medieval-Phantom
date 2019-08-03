using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public InteractbleObject focus;
    Camera cam;
    PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICKED");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit , 100, movementMask))
            {
                //Move out player to what we hit
                motor.MoveToPoint(hit.point);
                //Stop focusing any objects
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("CLICKED");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit , 100, movementMask))
            {
                //Check if we hit an interactabçe
                InteractbleObject interactable =  hit.collider.GetComponent<InteractbleObject>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                //If we did, set it to as our focus

            }
        }
    }

    private void RemoveFocus()
    {
        focus = null;
        motor.StopFollowingTarget();
    }

    private void SetFocus(InteractbleObject newFocus)
    {
        focus = newFocus;
        motor.FollowTarget(newFocus);
    }
}
