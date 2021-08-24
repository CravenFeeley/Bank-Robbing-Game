using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellerDoor : MonoBehaviour
{
    public GameManager GM;

    private Quaternion startingrotation;
    private Quaternion finishingrotation;
    public bool DoorOpen;

    public Animator anim;
    public Animation Opening;
    public Animation Closing;

    public bool doorLocked;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        startingrotation = transform.rotation;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if (DoorOpen == false)
        {
            anim.SetBool("DoorClosing", false);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GM.Robbers.Contains(other.gameObject) || GM.HostagesControlled.Contains(other.gameObject))
        {
            if(doorLocked == false)
            {
                if (DoorOpen == false)
                {
                    DoorOpen = true;
                    anim.SetBool("Open", true);
                }
            }


        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(GM.Hostages.Contains(other.gameObject))
        {


            if (other.GetComponent<HostageController>().keycardowner == true)
            {
                if (other.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().keyboardcontroller == true)
                {
                    if (doorLocked == false)
                    {
                        if (Input.GetKeyDown(KeyCode.N))
                        {
                            anim.SetBool("Open", false);
                            doorLocked = true;
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.N))
                        {
                            anim.SetBool("Open", true);
                            doorLocked = false;
                        }
                    }
                }
                else
                {
                    switch (other.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().controllernumber)
                    {
                        case 1:
                            if (doorLocked == false)
                            {
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    anim.SetBool("Open", false);
                                    doorLocked = true;
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    anim.SetBool("Open", true);
                                    doorLocked = false;
                                }
                            }
                            break;
                        case 2:
                            if (doorLocked == false)
                            {
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    anim.SetBool("Open", false);
                                    doorLocked = true;
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    anim.SetBool("Open", true);
                                    doorLocked = false;
                                }
                            }
                            break;
                        case 3:
                            if (doorLocked == false)
                            {
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    anim.SetBool("Open", false);
                                    doorLocked = true;
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    anim.SetBool("Open", true);
                                    doorLocked = false;
                                }
                            }
                            break;
                        case 4:
                            if (doorLocked == false)
                            {
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    anim.SetBool("Open", false);
                                    doorLocked = true;
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    anim.SetBool("Open", true);
                                    doorLocked = false;
                                }
                            }
                            break;
                    }
                }
                Debug.Log(GM.keycardowner);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (GM.Robbers.Contains(other.gameObject) || GM.HostagesControlled.Contains(other.gameObject))
        {
            if(DoorOpen == true)
            {
                anim.SetBool("Open", false);
                DoorOpen = false;
            }

        }
    }

    

}
