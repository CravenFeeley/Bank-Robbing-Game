using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RobberController : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;


    public RobberCharacterStats stats;
    public CharacterController controller;

    public string characterName;

    public GameObject Body;
    public Material newMaterial;
    public Renderer rend;

    public Transform TransportPoint;
    public bool TransportPointInUse;

    public float speed;
    public float defaultSpeed = 10f;

    public float forceSpeed;
    public Rigidbody hips;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private bool boost = false;
    public float boostSpeed = 15f;
    public float boostTimer = 1f;

    public float shoutDuration;
    public float shoutAmount;
    public float shoutLimit;
    public float shoutCooldown;
    public bool shoutReady;
    public bool shouting = false;
    public Image shoutbar;

    public Image StaminaBar;
    public Image StaminaEmpty;

    public GameManager GM;

    public GameObject Shoutradius;

    public GameObject Player;

    public GameObject Hostage;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        controller = this.gameObject.GetComponent<CharacterController>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        stats = gameObject.GetComponent<RobberCharacterStats>();
        if (gameObject.tag == "Robber")
        {
            GM.Robbers.Add(gameObject);
        }
        shoutReady = true;

        rend = Body.GetComponent<Renderer>();

        switch (stats.characterClass)
        {
            case (RobberCharacterStats.Class.Balanced):
                defaultSpeed = stats.baseSpeed;
                boostSpeed = stats.boostSpeed;
                characterName = stats.characterName;
                break;

            case (RobberCharacterStats.Class.Heavy):
                defaultSpeed = stats.baseSpeed;
                boostSpeed = stats.boostSpeed;
                characterName = stats.characterName;
                break;
            
            case (RobberCharacterStats.Class.Light):
                defaultSpeed = stats.baseSpeed;
                boostSpeed = stats.boostSpeed;
                characterName = stats.characterName;
                break;
        }

    }

    void Update()
    {
        if (GM.playerselect == GameManager.PlayerSelect.COMPLETED || GM.playerselect == GameManager.PlayerSelect.NOTHING)
        {
            if (GM.Robbers.Contains(gameObject))
            {
                if (Player != null)
                {
                    if (Player.GetComponent<PlayerScript>().keyboardcontroller == true)
                    {
                        RobberMovementControlsKeyboard();
                    }
                    else
                    {
                        switch (Player.GetComponent<PlayerScript>().controllernumber)
                        {
                            case 1:
                                RobberMovementControls1();
                                break;
                            case 2:
                                RobberMovementControls2();
                                break;
                            case 3:
                                RobberMovementControls3();
                                break;
                            case 4:
                                RobberMovementControls4();
                                break;
                        }
                    }
                }
            }
        }
        if (shoutDuration <= 0)
        {
            shoutCooldown -= Time.deltaTime;
            if (shoutCooldown <= 0)
            {
                shoutReady = true;
                shoutDuration = 1;
                shoutCooldown = 3;
            }
        }
    }

    public void RobberMovementControls1()
    {

        if (boost == true)
        {
            speed = boostSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }
        if (boostTimer < 1 && boost == false)
        {
            boostTimer += Time.deltaTime;
            float calc_cooldown = boostTimer * 1;
            StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
            if (boostTimer > 1)
            {
                boostTimer = 1;
            }
        }

        float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
        float vertical = Input.GetAxisRaw("Vertical Controller 1");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.Joystick1Button0) && boostTimer > 0f)
            {
                boost = true;
                boostTimer -= Time.deltaTime * 2;
                float calc_cooldown = boostTimer / 1;
                StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                if (boostTimer <= 0)
                {
                    boost = false;
                }
            }
            else
            {
                boost = false;
            }

            anim.SetBool("Walking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);

        }

        else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            ShakeUp();
        }
        else
        {
            anim.SetBool("ShakeUp", false);
        }

    }

    public void RobberMovementControls2()
    {

        if (boost == true)
        {
            speed = boostSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }
        if (boostTimer < 1 && boost == false)
        {
            boostTimer += Time.deltaTime;
            float calc_cooldown = boostTimer * 1;
            StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
            if (boostTimer > 1)
            {
                boostTimer = 1;
            }
        }

        float horizontal = Input.GetAxisRaw("Horizontal Controller 2");
        float vertical = Input.GetAxisRaw("Vertical Controller 2");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.Joystick2Button0) && boostTimer > 0f)
            {
                boost = true;
                boostTimer -= Time.deltaTime * 2;
                float calc_cooldown = boostTimer / 1;
                StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                if (boostTimer <= 0)
                {
                    boost = false;
                }
            }
            else
            {
                boost = false;
            }


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }
    public void RobberMovementControls3()
    {

        if (boost == true)
        {
            speed = boostSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }
        if (boostTimer < 1 && boost == false)
        {
            boostTimer += Time.deltaTime;
            float calc_cooldown = boostTimer * 1;
            StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
            if (boostTimer > 1)
            {
                boostTimer = 1;
            }
        }

        float horizontal = Input.GetAxisRaw("Horizontal Controller 3");
        float vertical = Input.GetAxisRaw("Vertical Controller 3");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.Joystick3Button0) && boostTimer > 0f)
            {
                boost = true;
                boostTimer -= Time.deltaTime * 2;
                float calc_cooldown = boostTimer / 1;
                StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                if (boostTimer <= 0)
                {
                    boost = false;
                }
            }
            else
            {
                boost = false;
            }


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }
    public void RobberMovementControls4()
    {

        if (boost == true)
        {
            speed = boostSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }
        if (boostTimer < 1 && boost == false)
        {
            boostTimer += Time.deltaTime;
            float calc_cooldown = boostTimer * 1;
            StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
            if (boostTimer > 1)
            {
                boostTimer = 1;
            }
        }

        float horizontal = Input.GetAxisRaw("Horizontal Controller 4");
        float vertical = Input.GetAxisRaw("Vertical Controller 4");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.Joystick4Button0) && boostTimer > 0f)
            {
                boost = true;
                boostTimer -= Time.deltaTime * 2;
                float calc_cooldown = boostTimer / 1;
                StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                if (boostTimer <= 0)
                {
                    boost = false;
                }
            }
            else
            {
                boost = false;
            }


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }
    public void RobberMovementControlsKeyboard()
    {

        if (boost == true)
        {
            speed = boostSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }
        if (boostTimer < 1 && boost == false)
        {
            boostTimer += Time.deltaTime;
            float calc_cooldown = boostTimer * 1;
            StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
            if (boostTimer > 1)
            {
                boostTimer = 1;
            }
        }

        float horizontal = Input.GetAxisRaw("HorizontalKeyboard");
        float vertical = Input.GetAxisRaw("VerticalKeyboard");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift) && boostTimer > 0f)
            {
                boost = true;
                boostTimer -= Time.deltaTime * 2;
                float calc_cooldown = boostTimer / 1;
                StaminaBar.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);
                if (boostTimer <= 0)
                {
                    boost = false;
                }
            }
            else
            {
                boost = false;
            }


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(GM.playerselect == GameManager.PlayerSelect.NOTHING)
        {
        if (Player != null)
        {
            if (shoutAmount > 0 && shoutReady == true)
            {
                    if (Player.GetComponent<PlayerScript>().keyboardcontroller == true)
                    {
                        if (Input.GetKey(KeyCode.Space))
                        {
                            Shoutradius.SetActive(true);
                            shouting = true;
                            shoutDuration -= Time.deltaTime;
                            if (shoutDuration <= 0)
                            {
                                shoutAmount -= 1;
                                shoutbar.fillAmount = shoutAmount / 3;
                                shouting = false;
                                shoutReady = false;
                                Shoutradius.SetActive(false);

                            }
                            Debug.Log("Shout");
                            if (shouting == true)
                            {
                                if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(gameObject))
                                {
                                    if (other.GetComponent<HostageController>().Protected == false)
                                    {
                                        Hostage = other.gameObject;
                                        Shout();
                                    }

                                }
                            }
                        }
                        else if (Input.GetKeyUp(KeyCode.Space))
                        {
                            Shoutradius.SetActive(false);
                            shoutAmount -= 1;
                            shoutbar.fillAmount = shoutAmount / 3;
                            shoutDuration = 0;
                            shouting = false;
                            shoutReady = false;
                        }
                        else
                        {
                            Shoutradius.SetActive(false);
                        }
                    }
                    else
                    {

                        switch (Player.GetComponent<PlayerScript>().controllernumber)
                        {
                            case 1:
                                if (Input.GetKey(KeyCode.Joystick1Button4))
                                {
                                    Shoutradius.SetActive(true);
                                    shouting = true;
                                    shoutDuration -= Time.deltaTime;
                                    if (shoutDuration <= 0)
                                    {
                                        shoutAmount -= 1;
                                        shoutbar.fillAmount = shoutAmount / 3;
                                        shouting = false;
                                        Shoutradius.SetActive(false);
                                        shoutReady = false;
                                    }
                                    if (shouting == true)
                                    {
                                        Debug.Log("Shout");
                                        if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(gameObject))
                                        {

                                            if (other.GetComponent<HostageController>().Protected == false)
                                            {
                                                Hostage = other.gameObject;
                                                Shout();
                                            }
                                        }
                                    }
                                }
                                else if (Input.GetKeyUp(KeyCode.Joystick1Button4))
                                {
                                    Shoutradius.SetActive(false);
                                    shoutAmount -= 1;
                                    shoutbar.fillAmount = shoutAmount / 3;
                                    shoutDuration = 0;
                                    shouting = false;
                                    shoutReady = false;
                                }
                                else
                                {
                                    Shoutradius.SetActive(false);
                                }
                                break;
                            case 2:
                                if (Input.GetKey(KeyCode.Joystick2Button4))
                                {
                                    Shoutradius.SetActive(true);
                                    shouting = true;
                                    shoutDuration -= Time.deltaTime;
                                    if (shoutDuration <= 0)
                                    {
                                        shoutAmount -= 1;
                                        shoutbar.fillAmount = shoutAmount / 3;
                                        shouting = false;
                                        Shoutradius.SetActive(false);
                                        shoutReady = false;
                                    }
                                    if (shouting == true)
                                    {
                                        Debug.Log("Shout");
                                        if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(gameObject))
                                        {

                                            if (other.GetComponent<HostageController>().Protected == false)
                                            {
                                                Hostage = other.gameObject;
                                                Shout();
                                            }
                                        }
                                    }
                                }
                                else if (Input.GetKeyUp(KeyCode.Joystick2Button4))
                                {
                                    Shoutradius.SetActive(false);
                                    shoutAmount -= 1;
                                    shoutbar.fillAmount = shoutAmount / 3;
                                    shoutDuration = 0;
                                    shouting = false;
                                    shoutReady = false;
                                }
                                else
                                {
                                    Shoutradius.SetActive(false);
                                }
                                break;
                            case 3:
                                if (Input.GetKey(KeyCode.Joystick3Button4))
                                {
                                    Shoutradius.SetActive(true);
                                    shouting = true;
                                    shoutDuration -= Time.deltaTime;
                                    if (shoutDuration <= 0)
                                    {
                                        shoutAmount -= 1;
                                        shoutbar.fillAmount = shoutAmount / 3;
                                        shouting = false;
                                        Shoutradius.SetActive(false);
                                        shoutReady = false;
                                    }
                                    if (shouting == true)
                                    {
                                        Debug.Log("Shout");
                                        if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(gameObject))
                                        {

                                            if (other.GetComponent<HostageController>().Protected == false)
                                            {
                                                Hostage = other.gameObject;
                                                Shout();
                                            }
                                        }
                                    }
                                }
                                else if (Input.GetKeyUp(KeyCode.Joystick3Button4))
                                {
                                    Shoutradius.SetActive(false);
                                    shoutAmount -= 1;
                                    shoutbar.fillAmount = shoutAmount / 3;
                                    shoutDuration = 0;
                                    shouting = false;
                                    shoutReady = false;
                                }
                                else
                                {
                                    Shoutradius.SetActive(false);
                                }
                                break;
                            case 4:
                                if (Input.GetKey(KeyCode.Joystick4Button4))
                                {
                                    Shoutradius.SetActive(true);
                                    shouting = true;
                                    shoutDuration -= Time.deltaTime;
                                    if (shoutDuration <= 0)
                                    {
                                        shoutAmount -= 1;
                                        shoutbar.fillAmount = shoutAmount / 3;
                                        shouting = false;
                                        Shoutradius.SetActive(false);
                                        shoutReady = false;
                                    }
                                    if (shouting == true)
                                    {
                                        Debug.Log("Shout");

                                        if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(gameObject))
                                        {

                                            if (other.GetComponent<HostageController>().Protected == false)
                                            {
                                                Hostage = other.gameObject;
                                                Shout();
                                            }
                                        }
                                    }
                                }
                                else if (Input.GetKeyUp(KeyCode.Joystick4Button4))
                                {
                                    Shoutradius.SetActive(false);
                                    shoutAmount -= 1;
                                    shoutbar.fillAmount = shoutAmount / 3;
                                    shoutDuration = 0;
                                    shouting = false;
                                    shoutReady = false;
                                }
                                else
                                {
                                    Shoutradius.SetActive(false);
                                }
                                break;
                        }
                    }
                }
            }

        }
    }

    private void Shout()
    {
        
        GM.HostagesScared.Add(Hostage.gameObject);
        GM.HostagesControlled.Remove(Hostage.gameObject);
        Hostage.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().ControlledCharacter = null;
        Hostage.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().hostageselector = PlayerScript.HostageSelection.WAITING;
        Hostage.gameObject.GetComponent<HostageController>().Player = null;
        Hostage.gameObject.GetComponent<HostageController>().Controlled = false;
        Hostage.gameObject.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
        Hostage.transform.position = Hostage.gameObject.GetComponent<HostageController>().TransportPoint.position;
        GM.TransformPoints.Remove(Hostage.gameObject.GetComponent<HostageController>().TransportPoint);
        Hostage.gameObject.GetComponent<HostageController>().TransportPointInUse = true;
    }

    public void ShakeUp()
    {
        anim.SetBool("ShakeUp", true);

    }
}
