using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Camera Variables
    public Camera cam;
    private Vector3 look_input = Vector3.zero;
    private float look_speed = 60;
    private float horizontal_look_angle = 0f;
    public bool invert_x = false;
    public bool invert_y = false;
    private int invert_factor_x = 1;
    private int invert_factor_y = 1;

    // Update is called once per frame
    private void Start()
    {
        //Hide the mouse.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        //Left/Right
        transform.Rotate(Vector3.up, look_input.x * look_speed * Time.deltaTime);

        //Up/Down
        float angle = look_input.y * look_speed * Time.deltaTime;
        horizontal_look_angle -= angle;
        horizontal_look_angle = Mathf.Clamp(horizontal_look_angle, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(horizontal_look_angle, 0,0);

        //Inverting Camera
        if (invert_x) invert_factor_x = -1;
        if (invert_y) invert_factor_y = -1;
    }


    public void GetLookInput(InputAction.CallbackContext context)
    {
        look_input = context.ReadValue<Vector2>();
        
    }

    
   

}
