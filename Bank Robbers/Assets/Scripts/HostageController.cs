using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostageController : MonoBehaviour
{

    public CharacterController controller;

    public GameObject Body;
    public Material newMaterial;
    //public Renderer rend;

    public float speed;
    public float defaultSpeed = 10f;

    private bool boost = false;
    public float boostSpeed = 15f;
    public float boostTimer = 1f;

    public Image StaminaBar;
    public Image StaminaEmpty;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public GameManager GM;

    public GameObject Selector1;
    public GameObject Selector2;
    public GameObject Selector3;
    public GameObject Selector4;
    public GameObject Selector5;

    public GameObject ScaredSelector;
    public bool Controlled;
    public bool Protected;
    public float ProtectedTimer;

    public GameObject Player;

    public float scaredtimer = 15f;

    public Transform TransportPoint;
    public bool openingDoor;
    //public List<Transform> TransformPoints = new List<Transform>();
    public bool TransportPointInUse;

    public bool keycardowner;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.Hostages.Add(gameObject);
        GM.HostagesAvailable.Add(gameObject);

        //rend = Body.GetComponent<Renderer>();
        scaredtimer = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.HostagesScared.Contains(gameObject))
        {
            scaredtimer -= Time.deltaTime;
            Selector1.SetActive(false);
            Selector2.SetActive(false);
            Selector3.SetActive(false);
            Selector4.SetActive(false);
            Selector5.SetActive(false);
            ScaredSelector.SetActive(true);
            //rend.sharedMaterial = GM.Materials[4];
            StaminaBar.gameObject.SetActive(false);
            StaminaEmpty.gameObject.SetActive(false);

            if (scaredtimer <= 0)
            {
                GM.HostagesAvailable.Add(gameObject);
                GM.HostagesScared.Remove(gameObject);
                scaredtimer = 15;
                ScaredSelector.SetActive(false); 
                StaminaBar.gameObject.SetActive(true);
                StaminaEmpty.gameObject.SetActive(true);
                //rend.sharedMaterial = GM.Materials[5];

            }
        }
        if (GM.HostagesControlled.Contains(gameObject))
        {
            if (Player.GetComponent<PlayerScript>().keyboardcontroller == true)
            {
                HostageMovementControlsKeyboard();
            }
            else
            {
                switch (Player.GetComponent<PlayerScript>().controllernumber)
                {
                    case 1:
                        HostageMovementControls1();
                        break;
                    case 2:
                        HostageMovementControls2();
                        break;
                    case 3:
                        HostageMovementControls3();
                        break;
                    case 4:
                        HostageMovementControls4();
                        break;

                }
            }
        }
        if (Protected == true)
        {
            ProtectedTimer -= Time.deltaTime;
            if(ProtectedTimer <= 0)
            {
                ProtectedTimer = 2;
                Protected = false;
            }
        }
    }

    public void HostageMovementControls1()
    {
        if(this.gameObject == GM.keycardowner)
        {
            if(Input.GetKey(KeyCode.Joystick1Button3))
            {
                GM.Keycard.gameObject.SetActive(true);
            }
            else
            {
                GM.Keycard.gameObject.SetActive(false);
            }
        }

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


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }
    public void HostageMovementControls2()
    {
        {
            if (this.gameObject == GM.keycardowner)
            {
                if (Input.GetKey(KeyCode.Joystick2Button3))
                {
                    GM.Keycard.gameObject.SetActive(true);
                }
                else
                {
                    GM.Keycard.gameObject.SetActive(false);
                }
            }
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
    }
    public void HostageMovementControls3()
    {
        if (this.gameObject == GM.keycardowner)
        {
            if (Input.GetKey(KeyCode.Joystick3Button3))
            {
                GM.Keycard.gameObject.SetActive(true);
            }
            else
            {
                GM.Keycard.gameObject.SetActive(false);
            }
        }
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
    public void HostageMovementControls4()
    {
        if (this.gameObject == GM.keycardowner)
        {
            if (Input.GetKey(KeyCode.Joystick4Button3))
            {
                GM.Keycard.gameObject.SetActive(true);
            }
            else
            {
                GM.Keycard.gameObject.SetActive(false);
            }
        }
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
    public void HostageMovementControlsKeyboard()
    {
        if (this.gameObject == GM.keycardowner)
        {
            if (Input.GetKey(KeyCode.M))
            {
                GM.Keycard.gameObject.SetActive(true);
            }
            else
            {
                GM.Keycard.gameObject.SetActive(false);
            }
        }
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
            if (Input.GetKey(KeyCode.Space) && boostTimer > 0f)
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
}
