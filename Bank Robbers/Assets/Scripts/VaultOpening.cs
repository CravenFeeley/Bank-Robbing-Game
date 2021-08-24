using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VaultOpening : MonoBehaviour
{

    public GameObject Drill;
    public bool drillActive;
    public TextMeshProUGUI prompt;

    public float startingdrillTimer;
    public float currentdrillTimer;
    public float drillStage;
    public int drillBroken;
    public Image timer;
    public GameManager GM;

    public GameObject Alarm;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentdrillTimer = startingdrillTimer;
    }

    void Update()
    {
        if(Alarm.GetComponent<AlarmPanel>().drillDisabled == false)
        {
        if (drillActive == true)
        {
            currentdrillTimer -= Time.deltaTime * 0.5f;
            float calc_cooldown = currentdrillTimer / startingdrillTimer;
            timer.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
        }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (GM.Robbers.Contains(other.gameObject))
        {
            if(drillActive == false)
            {
                prompt.gameObject.SetActive(true);
                if (other.GetComponent<RobberController>().Player.GetComponent<PlayerScript>().keyboardcontroller == true)
                {
                    prompt.text = "K";

                    if (Input.GetKey(KeyCode.K))
                    {
                        Drill.SetActive(true);
                        drillActive = true;
                        prompt.gameObject.SetActive(false);
                        timer.gameObject.SetActive(true);

                    }
                }

                else
                {
                    prompt.text = "RB";

                    switch (other.GetComponent<RobberController>().Player.GetComponent<PlayerScript>().controllernumber)
                    {
                        case 1:
                            if (Input.GetKey(KeyCode.Joystick1Button5))
                            {
                                Drill.SetActive(true);
                                drillActive = true;
                                prompt.gameObject.SetActive(false);
                                timer.gameObject.SetActive(true);

                            }
                            break;
                        case 2:
                            if (Input.GetKey(KeyCode.Joystick2Button5))
                            {
                                Drill.SetActive(true);
                                drillActive = true;
                                prompt.gameObject.SetActive(false);
                                timer.gameObject.SetActive(true);

                            }
                            break;
                        case 3:
                            if (Input.GetKey(KeyCode.Joystick3Button5))
                            {
                                Drill.SetActive(true);
                                drillActive = true;
                                prompt.gameObject.SetActive(false);
                                timer.gameObject.SetActive(true);

                            }
                            break;
                        case 4:
                            if (Input.GetKey(KeyCode.Joystick4Button5))
                            {
                                Drill.SetActive(true);
                                drillActive = true;
                                prompt.gameObject.SetActive(false);
                                timer.gameObject.SetActive(true);

                            }
                            break;
                    }
                }
            }
            else
            {
                if (Alarm.GetComponent<AlarmPanel>().drillDisabled == false)
                {
                    currentdrillTimer -= Time.deltaTime;
                    if(currentdrillTimer <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    currentdrillTimer = currentdrillTimer;
                }
            }
        }    

    }
}
