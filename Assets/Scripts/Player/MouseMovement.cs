using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float mouseSentivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    float topClamp = -90f;
    float bottomClamp = 90f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSentivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSentivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
}
