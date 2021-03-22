using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region SystemSettings
    private float angleX;
    private float angleY;
    private CharacterController controller;
    RaycastHit hit;
    [SerializeField] GameManager gm;
    #endregion
    #region HackerCanUse)
    [SerializeField] private float speed;
    [SerializeField] [Range(0,90)] float MaxView;
    #endregion
    #region PlayerCanUse
    [SerializeField] private float sencivity;
    #endregion

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        #region Rotate
        var mouseX = Input.GetAxis("Mouse X") * sencivity;
        var mouseY = Input.GetAxis("Mouse Y") * sencivity;

        angleX -= mouseY;
        angleY += mouseX;

        angleX = Mathf.Clamp(angleX, -MaxView, MaxView);

        gameObject.transform.localRotation = Quaternion.Euler(0, angleY, 0);
        transform.GetChild(0).localRotation = Quaternion.Euler(angleX, 0, 0);
        #endregion
        #region Move
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;
        if (!Input.GetKey(KeyCode.LeftShift))
            controller.Move(move * speed * Time.deltaTime);
        else
            controller.Move(move * speed * Time.deltaTime * 1.5f);
        #endregion
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(gameObject.transform.GetChild(0).GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), gameObject.transform.GetChild(0).transform.forward, out hit)&& hit.transform.GetComponent<WhoIAm>())
        {
            if (hit.transform.GetComponent<WhoIAm>().myName == "VR") ;
            gm.LoadNextLevel();
        }
    }
}
