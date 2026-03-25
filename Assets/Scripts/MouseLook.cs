using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse look left/right and up/down
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);

        // E key to interact with instruments
        if (Input.GetKeyDown(KeyCode.E))
{
    Debug.Log("E pressed!");

    Ray ray = Camera.main.ScreenPointToRay(
        new Vector3(Screen.width / 2, Screen.height / 2, 0)
    );

    // THIS DRAWS A RED LINE IN SCENE VIEW showing exactly where ray goes
    Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);

    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 10f))
    {
        Debug.Log("Hit: " + hit.transform.name);
        InstrumentInteraction instrument =
            hit.transform.GetComponent<InstrumentInteraction>();
        if (instrument != null)
        {
            instrument.TogglePanel();
        }
        else
        {
            Debug.Log("No InstrumentInteraction on: " + hit.transform.name);
        }
    }
    else
    {
        Debug.Log("Raycast hit nothing!");
    }
}
    }
}