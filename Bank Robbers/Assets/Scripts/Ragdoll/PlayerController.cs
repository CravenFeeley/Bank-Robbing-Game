using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Ragdoll;
    public GameManager GM;

    public float speed;
    public float strafeSpeed;

    public float jumpForce;

    public Rigidbody hips;
    public Rigidbody ragdoll;

    public bool isGrounded;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public GameObject character;

    public int player;

    public ConfigurableJoint hipjoint;

    public GameObject Shoutradius;

    public float shoutDuration;
    public float shoutAmount;
    public float shoutLimit;
    public float shoutCooldown;
    public bool shoutReady;
    public bool shouting = false;
    public Image shoutbar;
    void Start()
    {
        hips = GetComponent<Rigidbody>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame

    private void Update()
    {
            character.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

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
    void FixedUpdate()
    {

        /*float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
        float vertical = Input.GetAxisRaw("Vertical Controller 1");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            GameObject.Move(direction * speed * Time.deltaTime);
        }*/

        if(player == 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                hips.AddForce(hips.transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                hips.AddForce(-hips.transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                hips.AddForce(-hips.transform.right * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                hips.AddForce(hips.transform.right * speed);
            }
        }

            if(player == 2)
        {
            float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
            float vertical = Input.GetAxisRaw("Vertical Controller 1");


            if (horizontal > 0.1)
            {
                hips.AddRelativeForce(hips.transform.forward * speed);
            }
            if (horizontal < -0.1)
            {
                hips.AddRelativeForce(-hips.transform.forward * speed);
            }   
            if (vertical > 0.1)
            {
                hips.AddRelativeForce(hips.transform.right * speed);

            }
            if (vertical < -0.1)
            {
                hips.AddRelativeForce(-hips.transform.right * speed);
            }

        }


        //ragdoll.transform.rotation = Quaternion.LookRotation(ragdoll.velocity, transform.forward);

    }







    private void OnTriggerStay(Collider other)
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
                            if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(Ragdoll))
                            {
                                if (other.GetComponent<HostageController>().Protected == false)
                                {
                                    GM.HostagesControlled.Remove(other.gameObject);
                                    GM.HostagesScared.Add(other.gameObject);
                                    other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().ControlledCharacter = null;
                                    other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().hostageselector = PlayerScript.HostageSelection.WAITING;
                                    other.gameObject.GetComponent<HostageController>().Player = null;
                                    //other.gameObject.GetComponent<HostageController>().ScaredSelector.SetActive(true);
                                    other.gameObject.GetComponent<HostageController>().Controlled = false;
                                    other.gameObject.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
                                    other.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
                                    GM.TransformPoints.Remove(other.gameObject.GetComponent<HostageController>().TransportPoint);
                                    other.gameObject.GetComponent<HostageController>().TransportPointInUse = true;
                                    //other.gameObject.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
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
                                    if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(Ragdoll))
                                    {

                                        if (other.GetComponent<HostageController>().Protected == false)
                                        {
                                            GM.HostagesControlled.Remove(other.gameObject);
                                            GM.HostagesScared.Add(other.gameObject);
                                            other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().ControlledCharacter = null;
                                            other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().hostageselector = PlayerScript.HostageSelection.WAITING;
                                            other.gameObject.GetComponent<HostageController>().Player = null;
                                            //other.gameObject.GetComponent<HostageController>().ScaredSelector.SetActive(true);
                                            other.gameObject.GetComponent<HostageController>().Controlled = false;
                                            other.gameObject.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
                                            other.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
                                            GM.TransformPoints.Remove(other.gameObject.GetComponent<HostageController>().TransportPoint);
                                            other.gameObject.GetComponent<HostageController>().TransportPointInUse = true;
                                            //other.gameObject.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
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
                                    if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(Ragdoll))
                                    {

                                        if (other.GetComponent<HostageController>().Protected == false)
                                        {
                                            GM.HostagesControlled.Remove(other.gameObject);
                                            GM.HostagesScared.Add(other.gameObject);
                                            other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().ControlledCharacter = null;
                                            other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().hostageselector = PlayerScript.HostageSelection.WAITING;
                                            other.gameObject.GetComponent<HostageController>().Player = null;
                                            //other.gameObject.GetComponent<HostageController>().ScaredSelector.SetActive(true);
                                            other.gameObject.GetComponent<HostageController>().Controlled = false;
                                            other.gameObject.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
                                            other.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
                                            GM.TransformPoints.Remove(other.gameObject.GetComponent<HostageController>().TransportPoint);
                                            other.gameObject.GetComponent<HostageController>().TransportPointInUse = true;
                                            //other.gameObject.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
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
                                    if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(Ragdoll))
                                    {

                                        if (other.GetComponent<HostageController>().Protected == false)
                                        {
                                            GM.HostagesControlled.Remove(other.gameObject);
                                            GM.HostagesScared.Add(other.gameObject);
                                            other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().ControlledCharacter = null;
                                            other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().hostageselector = PlayerScript.HostageSelection.WAITING;
                                            other.gameObject.GetComponent<HostageController>().Player = null;
                                            //other.gameObject.GetComponent<HostageController>().ScaredSelector.SetActive(true);
                                            other.gameObject.GetComponent<HostageController>().Controlled = false;
                                            other.gameObject.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
                                            other.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
                                            GM.TransformPoints.Remove(other.gameObject.GetComponent<HostageController>().TransportPoint);
                                            other.gameObject.GetComponent<HostageController>().TransportPointInUse = true;
                                            //other.gameObject.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
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

                                    if (GM.HostagesControlled.Contains(other.gameObject) && GM.Robbers.Contains(Ragdoll))
                                    {

                                        if (other.GetComponent<HostageController>().Protected == false)
                                        {
                                            GM.HostagesControlled.Remove(other.gameObject);
                                            GM.HostagesScared.Add(other.gameObject);
                                            other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().ControlledCharacter = null;
                                            other.gameObject.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().hostageselector = PlayerScript.HostageSelection.WAITING;
                                            other.gameObject.GetComponent<HostageController>().Player = null;
                                            //other.gameObject.GetComponent<HostageController>().ScaredSelector.SetActive(true);
                                            other.gameObject.GetComponent<HostageController>().Controlled = false;
                                            other.gameObject.GetComponent<HostageController>().TransportPoint = GM.TransformPoints[Random.Range(0, GM.TransformPoints.Count)];
                                            other.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
                                            GM.TransformPoints.Remove(other.gameObject.GetComponent<HostageController>().TransportPoint);
                                            other.gameObject.GetComponent<HostageController>().TransportPointInUse = true;
                                            //other.gameObject.transform.position = other.gameObject.GetComponent<HostageController>().TransportPoint.position;
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
