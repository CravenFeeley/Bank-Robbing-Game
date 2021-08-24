using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectScript : MonoBehaviour
{
    public int collectibleWeight;
    public TextMeshProUGUI Prompt;

    public float pickupTimer;
    public Image actionTimer;
    public GameManager GM;

    public Transform Position;

    public enum Collectabletype
    { 
        BOOST,
        SHOUT
    }
    public Collectabletype collectabletype;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (GM.Robbers.Contains(other.gameObject))
        {
            if (collectibleWeight == 1)
            {
                if (collectabletype == Collectabletype.SHOUT)
                {
                    if (other.gameObject.GetComponent<RobberController>().shoutAmount < other.gameObject.GetComponent<RobberController>().shoutLimit)
                    {
                        other.gameObject.GetComponent<RobberController>().shoutAmount += 1;
                        other.gameObject.GetComponent<RobberController>().shoutbar.fillAmount = other.gameObject.GetComponent<RobberController>().shoutAmount / 3;
                    }
                }
                GM.PowerUpPoints.Add(Position);
                Destroy(gameObject);
            }  
        }    
    }
    private void OnTriggerStay(Collider other)
    {
        if (GM.Robbers.Contains(other.gameObject))
        {
            //Prompt.gameObject.transform.position = other.gameObject.transform.position;
            
            switch (collectibleWeight)
            {
                case 1:
                    break;
                case 2:
                    Prompt.gameObject.SetActive(true);
                    if (other.GetComponent<RobberController>().Player.GetComponent<PlayerScript>().keyboardcontroller == true)
                    {
                        Prompt.text = "K";
                        if (Input.GetKeyDown(KeyCode.K))
                        {
                            Destroy(gameObject);
                            Prompt.gameObject.SetActive(false);
                        }
                    }
                    else
                    {

                        Prompt.text = "RB";
                        switch (other.GetComponent<RobberController>().Player.GetComponent<PlayerScript>().controllernumber)
                        {
                            case 1:
                                if (Input.GetKeyDown(KeyCode.Joystick1Button5))
                                {
                                    Destroy(gameObject);
                                    Prompt.gameObject.SetActive(false);
                                }
                                break;
                            case 2:
                                if (Input.GetKeyDown(KeyCode.Joystick2Button5))
                                {
                                    Destroy(gameObject);
                                    Prompt.gameObject.SetActive(false);
                                }
                                break;
                            case 3:
                                if (Input.GetKeyDown(KeyCode.Joystick3Button5))
                                {
                                    Destroy(gameObject);
                                    Prompt.gameObject.SetActive(false);
                                }
                                break;
                            case 4:
                                if (Input.GetKeyDown(KeyCode.Joystick4Button5))
                                {
                                    Destroy(gameObject);
                                    Prompt.gameObject.SetActive(false);
                                }
                                break;
                        }
                    }
                    break;
                case 3:
                    Prompt.gameObject.SetActive(true);

                    if (other.GetComponent<RobberController>().Player.GetComponent<PlayerScript>().keyboardcontroller == true)
                    {
                        Prompt.text = "K";
                        if (Input.GetKey(KeyCode.K))
                        {
                            pickupTimer += Time.deltaTime;
                            float calc_cooldown = pickupTimer / 1;
                            actionTimer.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                            actionTimer.gameObject.SetActive(true);
                            if (pickupTimer > 1)
                            {
                                Destroy(gameObject);
                                Prompt.gameObject.SetActive(false);
                                actionTimer.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            pickupTimer = 0;
                            actionTimer.gameObject.SetActive(false);
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
                                    pickupTimer += Time.deltaTime;
                                    float calc_cooldown = pickupTimer / 1;
                                    actionTimer.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                                    actionTimer.gameObject.SetActive(true);
                                    if (pickupTimer > 1)
                                    {
                                        Destroy(gameObject);
                                        Prompt.gameObject.SetActive(false);
                                        actionTimer.gameObject.SetActive(false);
                                    }
                                }
                                else
                                {
                                    pickupTimer = 0;
                                    actionTimer.gameObject.SetActive(false);
                                }
                                break;
                            case 2:
                                if (Input.GetKey(KeyCode.Joystick2Button5))
                                {
                                    pickupTimer += Time.deltaTime;
                                    float calc_cooldown = pickupTimer / 1;
                                    actionTimer.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                                    actionTimer.gameObject.SetActive(true);
                                    if (pickupTimer > 1)
                                    {
                                        Destroy(gameObject);
                                        Prompt.gameObject.SetActive(false);
                                        actionTimer.gameObject.SetActive(false);
                                    }
                                }
                                else
                                {
                                    pickupTimer = 0;
                                    actionTimer.gameObject.SetActive(false);
                                }
                                break;
                            case 3:
                                if (Input.GetKey(KeyCode.Joystick3Button5))
                                {
                                    pickupTimer += Time.deltaTime;
                                    float calc_cooldown = pickupTimer / 1;
                                    actionTimer.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                                    actionTimer.gameObject.SetActive(true);
                                    if (pickupTimer > 1)
                                    {
                                        Destroy(gameObject);
                                        Prompt.gameObject.SetActive(false);
                                        actionTimer.gameObject.SetActive(false);
                                    }
                                }
                                else
                                {
                                    pickupTimer = 0;
                                    actionTimer.gameObject.SetActive(false);
                                }
                                break;
                            case 4:
                                if (Input.GetKey(KeyCode.Joystick4Button5))
                                {
                                    pickupTimer += Time.deltaTime;
                                    float calc_cooldown = pickupTimer / 1;
                                    actionTimer.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                                    actionTimer.gameObject.SetActive(true);
                                    if (pickupTimer > 1)
                                    {
                                        Destroy(gameObject);
                                        Prompt.gameObject.SetActive(false);
                                        actionTimer.gameObject.SetActive(false);
                                    }
                                }
                                else
                                {
                                    pickupTimer = 0;
                                    actionTimer.gameObject.SetActive(false);
                                }
                                break;
                        }
                    }
                    break;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (GM.Robbers.Contains(other.gameObject))
        {
            if (collectibleWeight > 1)
            {
                Prompt.gameObject.SetActive(false);
                actionTimer.gameObject.SetActive(false);
                pickupTimer = 0;
            }

        }
    }
}
