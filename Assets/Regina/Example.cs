using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public GameObject panel;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject npc4;
    public GameObject npc5;
    public GameObject button;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>(); 
    }

    void OnCollisionEnter(Collision col)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (col.gameObject.tag == "npc1")
        {
            Debug.Log("kena objek");
            panel.SetActive(true);
            npc1.SetActive(true);
            button.SetActive(true);
        }
        else if (col.gameObject.tag == "npc2")
        {
            Debug.Log("kena objek");
            panel.SetActive(true);
            npc2.SetActive(true);
            button.SetActive(true);

        }
        else if (col.gameObject.tag == "npc3")
        {
            Debug.Log("kena objek");
            panel.SetActive(true);
            npc3.SetActive(true);
            button.SetActive(true);

        }
        else if (col.gameObject.tag == "npc4")
        {
            Debug.Log("kena objek");
            panel.SetActive(true);
            npc4.SetActive(true);
            button.SetActive(true);

        }
        else if (col.gameObject.tag == "npc5")
        {
            Debug.Log("kena objek");
            panel.SetActive(true);
            npc5.SetActive(true);
            button.SetActive(true);

        }
    }
    public void Interaksi()
    {
        Debug.Log("button ok");
        panel.SetActive(false);
        npc1.SetActive(false);
        npc2.SetActive(false);
        npc3.SetActive(false);
        npc4.SetActive(false);
        npc5.SetActive(false);
        button.SetActive(false);

    }
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}