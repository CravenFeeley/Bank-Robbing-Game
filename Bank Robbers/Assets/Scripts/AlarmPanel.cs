using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlarmPanel : MonoBehaviour
{

    public GameObject vaultDoor;
    public GameManager GM;
    public bool drillDisabled;
    public TextMeshProUGUI Prompt;

    public float AlarmTimer;
    public TextMeshProUGUI AlarmText;
    public bool AlarmStarted;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AlarmStarted == true)
        {
            AlarmTimer -= Time.deltaTime;
            AlarmText.gameObject.SetActive(true);
            AlarmText.text = "" + (AlarmTimer).ToString("F0");
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (drillDisabled == false)
        {
            if (GM.HostagesControlled.Contains(other.gameObject))
            {
                Prompt.gameObject.SetActive(true);
                if (other.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().keyboardcontroller == true)
                {
                    Prompt.text = "K";
                    if (Input.GetKey(KeyCode.K))
                    {
                        drillDisabled = true;
                        Prompt.gameObject.SetActive(false);
                        if(AlarmStarted == false)
                        {
                            AlarmStarted = true;

                        }
                    }
                }
                else
                {
                    Prompt.text = "RB";
                    switch (other.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().controllernumber)
                    {

                        case 1:
                            if (Input.GetKey(KeyCode.Joystick1Button5))
                            {
                                drillDisabled = true;
                                Prompt.gameObject.SetActive(false);
                                if (AlarmStarted == false)
                                {
                                    AlarmTimer -= Time.deltaTime;
                                    AlarmText.gameObject.SetActive(true);
                                    AlarmText.text = "" + (AlarmTimer).ToString("F0");
                                }
                            }
                            break;
                        case 2:
                            if (Input.GetKey(KeyCode.Joystick2Button5))
                            {
                                drillDisabled = true;
                                Prompt.gameObject.SetActive(false);
                                if (AlarmStarted == false)
                                {
                                    AlarmTimer -= Time.deltaTime;
                                    AlarmText.gameObject.SetActive(true);
                                    AlarmText.text = "" + (AlarmTimer).ToString("F0");
                                }
                            }
                            break;
                        case 3:
                            if (Input.GetKey(KeyCode.Joystick3Button5))
                            {
                                drillDisabled = true;
                                Prompt.gameObject.SetActive(false);
                                if (AlarmStarted == false)
                                {
                                    AlarmTimer -= Time.deltaTime;
                                    AlarmText.gameObject.SetActive(true);
                                    AlarmText.text = "" + (AlarmTimer).ToString("F0");
                                }
                            }
                            break;
                        case 4:
                            if (Input.GetKey(KeyCode.Joystick4Button5))
                            {
                                drillDisabled = true;
                                Prompt.gameObject.SetActive(false);
                                if (AlarmStarted == false)
                                {
                                    AlarmTimer -= Time.deltaTime;
                                    AlarmText.gameObject.SetActive(true);
                                    AlarmText.text = "" + (AlarmTimer).ToString("F0");
                                }
                            }
                            break;
                    }
                }
            }
        }
        else if (drillDisabled == true)
        {    
            if (GM.Robbers.Contains(other.gameObject))
            {
                Prompt.gameObject.SetActive(true);
                if (other.GetComponent<RobberController>().Player.GetComponent<PlayerScript>().keyboardcontroller == true)
                {
                    Prompt.text = "K";
                    if (Input.GetKey(KeyCode.K))
                    {
                        drillDisabled = false;
                        Prompt.gameObject.SetActive(false);
                        Debug.Log("haha");
                    }
                }
                else
                {
                    Prompt.text = "RB";
                    switch (other.GetComponent<RobberController>().Player.GetComponent<PlayerScript>().controllernumber)
                    {
                        case 1:
                            if (Input.GetKey(KeyCode.Joystick1Button5))
                            {
                                drillDisabled = false;
                                Prompt.gameObject.SetActive(false);
                            }
                            break;
                        case 2:
                            if (Input.GetKey(KeyCode.Joystick2Button5))
                            {
                                drillDisabled = false;
                                Prompt.gameObject.SetActive(false);
                            }
                            break;
                        case 3:
                            if (Input.GetKey(KeyCode.Joystick3Button5))
                            {
                                drillDisabled = false;
                                Prompt.gameObject.SetActive(false);
                            }
                            break;
                        case 4:
                            if (Input.GetKey(KeyCode.Joystick4Button5))
                            {
                                drillDisabled = false;
                                Prompt.gameObject.SetActive(false);
                            }
                            break;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Prompt.gameObject.SetActive(false);
    }
}
