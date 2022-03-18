using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camAxis;
    public Transform cam;
    public float camSpeed;

    public Transform playerAxis;
    public Transform player;
    public Vector3 playerDir;
    public float playerSpeed;

    Animator anim;

    float mouseX;
    float mouseY;
    float mouseWheel;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float v = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");

        playerDir = new Vector3(v, 0, h);

        if(playerDir != Vector3.zero)
        {
            playerAxis.rotation = Quaternion.Euler(new Vector3(0, camAxis.rotation.y + mouseX, 0) * camSpeed);
            playerAxis.Translate(playerDir * playerSpeed * Time.deltaTime);
            player.localRotation = Quaternion.Slerp(player.localRotation, Quaternion.LookRotation(playerDir), 5 * Time.deltaTime);

            anim.SetBool("isRun", true);
        }
        if(playerDir.Equals(Vector3.zero))
        {
            anim.SetBool("isRun", false);
        }
    }
    void LateUpdate()
    {
        CamMove();
        CamZoom();
        camAxis.position = new Vector3(player.position.x, player.position.y + 4, player.position.z);
    }
    void CamMove()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y") * -1;

        if(mouseY > 10)
        {
            mouseY = 10;
        }
        if (mouseY < 0)
        {
            mouseY = 0;
        }

        camAxis.rotation = Quaternion.Euler(new Vector3(camAxis.rotation.x + mouseY, camAxis.rotation.y + mouseX, 0) * camSpeed);
    }

    void CamZoom()
    {
        mouseWheel += Input.GetAxis("Mouse ScrollWheel") * 10;

        if (mouseWheel >= -10)
        {
            mouseWheel = -10;
        }
        if (mouseWheel <= -20)
        {
            mouseWheel = -20;
        }
        cam.localPosition = new Vector3(0, 0, mouseWheel);
    }
}
