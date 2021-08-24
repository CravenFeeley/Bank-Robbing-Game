using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpening : MonoBehaviour
{

    public int stage;
    public TextMeshProUGUI prompt;

    public float openTimer;
    //public Image progressBackground;
    public Image progressTimer1;
    public Image progressTimer2;
    public Image progressTimer3;
    public Image progressTimer4;
    public Image progressTimer5;
    public GameManager GM;
    public List<GameObject> OpeningDoor = new List<GameObject>();


    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        if(openTimer > 0)
        {
            if (OpeningDoor.Count == 0)
            {
                switch (stage)
                {
                    case 1:
                        openTimer -= Time.deltaTime * 0.5f;
                        float calc_cooldown = openTimer / 5;
                        progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown, 0, 1);

                        break;
                    case 2:
                        openTimer -= Time.deltaTime * 0.5f;
                        float calc_cooldown2 = openTimer / 5;
                        progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                        break;
                    case 3:
                        openTimer -= Time.deltaTime * 0.5f;
                        float calc_cooldown3 = openTimer / 5;
                        progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                        break;
                    case 4:
                        openTimer -= Time.deltaTime * 0.5f;
                        float calc_cooldown4 = openTimer / 5;
                        progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                        break;
                    case 5:
                        openTimer -= Time.deltaTime * 0.5f;
                        float calc_cooldown5 = openTimer / 5;
                        progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                        break;
                }
                if (openTimer <= 0)
                {
                    prompt.gameObject.SetActive(false);
                    //progressBackground.gameObject.SetActive(false);
                    switch(stage)
                    {
                        case 1:
                            progressTimer1.gameObject.SetActive(false);
                            break;
                        case 2:
                            progressTimer2.gameObject.SetActive(false);
                            break;
                        case 3:
                            progressTimer3.gameObject.SetActive(false);
                            break;
                        case 4:
                            progressTimer4.gameObject.SetActive(false);
                            break;
                        case 5:
                            progressTimer5.gameObject.SetActive(false);
                            break;
                    }
                    openTimer = 0;
                }
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (GM.Hostages.Contains(other.gameObject))
        {
            //progressBackground.gameObject.SetActive(true);

            switch (stage)
            {
                case 1:
                    break;
                case 2:
                    progressTimer1.gameObject.SetActive(true);
                    break;
                case 3:
                    progressTimer1.gameObject.SetActive(true);
                    progressTimer2.gameObject.SetActive(true);
                    break;
                case 4:
                    progressTimer1.gameObject.SetActive(true);
                    progressTimer2.gameObject.SetActive(true);
                    progressTimer3.gameObject.SetActive(true);
                    break;
                case 5:
                    progressTimer1.gameObject.SetActive(true);
                    progressTimer2.gameObject.SetActive(true);
                    progressTimer3.gameObject.SetActive(true);
                    progressTimer4.gameObject.SetActive(true);
                    break;
            }

            prompt.gameObject.SetActive(true);

            if (other.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().keyboardcontroller == true)
            {
                prompt.text = "K";
                if (Input.GetKey(KeyCode.K))
                {
                    if(other.GetComponent<HostageController>().openingDoor == false)
                    {
                        OpeningDoor.Add(other.gameObject);
                        other.GetComponent<HostageController>().openingDoor = true;
                    }


                    switch (OpeningDoor.Count)
                    {
                        case 1:
                            switch (stage)
                            {
                                case 1:
                                    openTimer += Time.deltaTime;
                                    float calc_cooldown1 = openTimer / 5;
                                    progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        stage = 2;
                                    }
                                    break;
                                case 2:
                                    openTimer += Time.deltaTime;
                                    float calc_cooldown2 = openTimer / 5;
                                    progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    progressTimer2.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        stage = 3;
                                    }
                                    break;

                                case 3:
                                    openTimer += Time.deltaTime;
                                    float calc_cooldown3 = openTimer / 5;
                                    progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    progressTimer2.gameObject.SetActive(true);
                                    progressTimer3.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        stage = 4;
                                    }
                                    break;

                                case 4:
                                    openTimer += Time.deltaTime;
                                    float calc_cooldown4 = openTimer / 5;
                                    progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    progressTimer2.gameObject.SetActive(true);
                                    progressTimer3.gameObject.SetActive(true);
                                    progressTimer4.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        stage = 5;
                                    }
                                    break;

                                case 5:
                                    openTimer += Time.deltaTime;
                                    float calc_cooldown5 = openTimer / 5;
                                    progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    progressTimer2.gameObject.SetActive(true);
                                    progressTimer3.gameObject.SetActive(true);
                                    progressTimer4.gameObject.SetActive(true);
                                    progressTimer5.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        Destroy(gameObject);
                                        progressTimer1.gameObject.SetActive(false);
                                        progressTimer2.gameObject.SetActive(false);
                                        progressTimer3.gameObject.SetActive(false);
                                        progressTimer4.gameObject.SetActive(false);
                                        progressTimer5.gameObject.SetActive(false);
                                    }
                                    break;
                            }
                            break;

                        case 2:
                            switch (stage)
                            {
                                case 1:
                                    openTimer += Time.deltaTime * 0.75f;
                                    float calc_cooldown1 = openTimer / 5;
                                    progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        stage = 2;
                                    }
                                    break;
                                case 2:
                                    openTimer += Time.deltaTime * 0.75f;
                                    float calc_cooldown2 = openTimer / 5;
                                    progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    progressTimer2.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        stage = 3;
                                    }
                                    break;

                                case 3:
                                    openTimer += Time.deltaTime * 0.75f;
                                    float calc_cooldown3 = openTimer / 5;
                                    progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    progressTimer2.gameObject.SetActive(true);
                                    progressTimer3.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        stage = 4;
                                    }
                                    break;

                                case 4:
                                    openTimer += Time.deltaTime * 0.75f;
                                    float calc_cooldown4 = openTimer / 5;
                                    progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    progressTimer2.gameObject.SetActive(true);
                                    progressTimer3.gameObject.SetActive(true);
                                    progressTimer4.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        stage = 5;
                                    }
                                    break;

                                case 5:
                                    openTimer += Time.deltaTime * 0.75f;
                                    float calc_cooldown5 = openTimer / 5;
                                    progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                    progressTimer1.gameObject.SetActive(true);
                                    progressTimer2.gameObject.SetActive(true);
                                    progressTimer3.gameObject.SetActive(true);
                                    progressTimer4.gameObject.SetActive(true);
                                    progressTimer5.gameObject.SetActive(true);
                                    if (openTimer > 5)
                                    {
                                        openTimer = 0;
                                        Destroy(gameObject);
                                        progressTimer1.gameObject.SetActive(false);
                                        progressTimer2.gameObject.SetActive(false);
                                        progressTimer3.gameObject.SetActive(false);
                                        progressTimer4.gameObject.SetActive(false);
                                        progressTimer5.gameObject.SetActive(false);
                                    }
                                    break;
                            }
                            break;



                    }
                    

                }
            }

            else
            {
                prompt.text = "RB";
                switch (other.GetComponent<HostageController>().Player.GetComponent<PlayerScript>().controllernumber)
                {
                    case 1:
                        if (Input.GetKey(KeyCode.Joystick1Button5))
                        {
                            {
                                if (other.GetComponent<HostageController>().openingDoor == false)
                                {
                                    OpeningDoor.Add(other.gameObject);
                                    other.GetComponent<HostageController>().openingDoor = true;
                                }

                                switch (OpeningDoor.Count)
                                {
                                    case 1:
                                        switch (stage)
                                        {
                                            case 1:
                                                openTimer += Time.deltaTime;
                                                float calc_cooldown1 = openTimer / 5;
                                                progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    stage = 2;
                                                }
                                                break;
                                            case 2:
                                                openTimer += Time.deltaTime;
                                                float calc_cooldown2 = openTimer / 5;
                                                progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                progressTimer2.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    stage = 3;
                                                }
                                                break;

                                            case 3:
                                                openTimer += Time.deltaTime;
                                                float calc_cooldown3 = openTimer / 5;
                                                progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                progressTimer2.gameObject.SetActive(true);
                                                progressTimer3.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    stage = 4;
                                                }
                                                break;

                                            case 4:
                                                openTimer += Time.deltaTime;
                                                float calc_cooldown4 = openTimer / 5;
                                                progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                progressTimer2.gameObject.SetActive(true);
                                                progressTimer3.gameObject.SetActive(true);
                                                progressTimer4.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    stage = 5;
                                                }
                                                break;

                                            case 5:
                                                openTimer += Time.deltaTime;
                                                float calc_cooldown5 = openTimer / 5;
                                                progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                progressTimer2.gameObject.SetActive(true);
                                                progressTimer3.gameObject.SetActive(true);
                                                progressTimer4.gameObject.SetActive(true);
                                                progressTimer5.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    Destroy(gameObject);
                                                    progressTimer1.gameObject.SetActive(false);
                                                    progressTimer2.gameObject.SetActive(false);
                                                    progressTimer3.gameObject.SetActive(false);
                                                    progressTimer4.gameObject.SetActive(false);
                                                    progressTimer5.gameObject.SetActive(false);
                                                }
                                                break;
                                        }
                                        break;

                                    case 2:
                                        switch (stage)
                                        {
                                            case 1:
                                                openTimer += Time.deltaTime * 0.75f;
                                                float calc_cooldown1 = openTimer / 5;
                                                progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    stage = 2;
                                                }
                                                break;
                                            case 2:
                                                openTimer += Time.deltaTime * 0.75f;
                                                float calc_cooldown2 = openTimer / 5;
                                                progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                progressTimer2.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    stage = 3;
                                                }
                                                break;

                                            case 3:
                                                openTimer += Time.deltaTime * 0.75f;
                                                float calc_cooldown3 = openTimer / 5;
                                                progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                progressTimer2.gameObject.SetActive(true);
                                                progressTimer3.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    stage = 4;
                                                }
                                                break;

                                            case 4:
                                                openTimer += Time.deltaTime * 0.75f;
                                                float calc_cooldown4 = openTimer / 5;
                                                progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                progressTimer2.gameObject.SetActive(true);
                                                progressTimer3.gameObject.SetActive(true);
                                                progressTimer4.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    stage = 5;
                                                }
                                                break;

                                            case 5:
                                                openTimer += Time.deltaTime * 0.75f;
                                                float calc_cooldown5 = openTimer / 5;
                                                progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                                progressTimer1.gameObject.SetActive(true);
                                                progressTimer2.gameObject.SetActive(true);
                                                progressTimer3.gameObject.SetActive(true);
                                                progressTimer4.gameObject.SetActive(true);
                                                progressTimer5.gameObject.SetActive(true);
                                                if (openTimer > 5)
                                                {
                                                    openTimer = 0;
                                                    Destroy(gameObject);
                                                    progressTimer1.gameObject.SetActive(false);
                                                    progressTimer2.gameObject.SetActive(false);
                                                    progressTimer3.gameObject.SetActive(false);
                                                    progressTimer4.gameObject.SetActive(false);
                                                    progressTimer5.gameObject.SetActive(false);
                                                }
                                                break;
                                        }
                                        break;



                                }

                            }
                        }
                        break;
                    case 2:
                        if (Input.GetKey(KeyCode.Joystick2Button5))
                        {
                            if (other.GetComponent<HostageController>().openingDoor == false)
                            {
                                OpeningDoor.Add(other.gameObject);
                                other.GetComponent<HostageController>().openingDoor = true;
                            }


                            switch (OpeningDoor.Count)
                            {
                                case 1:
                                    switch (stage)
                                    {
                                        case 1:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown1 = openTimer / 5;
                                            progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 2;
                                            }
                                            break;
                                        case 2:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown2 = openTimer / 5;
                                            progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 3;
                                            }
                                            break;

                                        case 3:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown3 = openTimer / 5;
                                            progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 4;
                                            }
                                            break;

                                        case 4:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown4 = openTimer / 5;
                                            progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 5;
                                            }
                                            break;

                                        case 5:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown5 = openTimer / 5;
                                            progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            progressTimer5.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                Destroy(gameObject);
                                                progressTimer1.gameObject.SetActive(false);
                                                progressTimer2.gameObject.SetActive(false);
                                                progressTimer3.gameObject.SetActive(false);
                                                progressTimer4.gameObject.SetActive(false);
                                                progressTimer5.gameObject.SetActive(false);
                                            }
                                            break;
                                    }
                                    break;

                                case 2:
                                    switch (stage)
                                    {
                                        case 1:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown1 = openTimer / 5;
                                            progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 2;
                                            }
                                            break;
                                        case 2:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown2 = openTimer / 5;
                                            progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 3;
                                            }
                                            break;

                                        case 3:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown3 = openTimer / 5;
                                            progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 4;
                                            }
                                            break;

                                        case 4:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown4 = openTimer / 5;
                                            progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 5;
                                            }
                                            break;

                                        case 5:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown5 = openTimer / 5;
                                            progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            progressTimer5.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                Destroy(gameObject);
                                                progressTimer1.gameObject.SetActive(false);
                                                progressTimer2.gameObject.SetActive(false);
                                                progressTimer3.gameObject.SetActive(false);
                                                progressTimer4.gameObject.SetActive(false);
                                                progressTimer5.gameObject.SetActive(false);
                                            }
                                            break;
                                    }
                                    break;



                            }

                        }
                        break;
                    case 3:
                        if (Input.GetKey(KeyCode.Joystick3Button5))
                        {
                            if (other.GetComponent<HostageController>().openingDoor == false)
                            {
                                OpeningDoor.Add(other.gameObject);
                                other.GetComponent<HostageController>().openingDoor = true;
                            }


                            switch (OpeningDoor.Count)
                            {
                                case 1:
                                    switch (stage)
                                    {
                                        case 1:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown1 = openTimer / 5;
                                            progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 2;
                                            }
                                            break;
                                        case 2:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown2 = openTimer / 5;
                                            progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 3;
                                            }
                                            break;

                                        case 3:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown3 = openTimer / 5;
                                            progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 4;
                                            }
                                            break;

                                        case 4:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown4 = openTimer / 5;
                                            progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 5;
                                            }
                                            break;

                                        case 5:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown5 = openTimer / 5;
                                            progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            progressTimer5.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                Destroy(gameObject);
                                                progressTimer1.gameObject.SetActive(false);
                                                progressTimer2.gameObject.SetActive(false);
                                                progressTimer3.gameObject.SetActive(false);
                                                progressTimer4.gameObject.SetActive(false);
                                                progressTimer5.gameObject.SetActive(false);
                                            }
                                            break;
                                    }
                                    break;

                                case 2:
                                    switch (stage)
                                    {
                                        case 1:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown1 = openTimer / 5;
                                            progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 2;
                                            }
                                            break;
                                        case 2:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown2 = openTimer / 5;
                                            progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 3;
                                            }
                                            break;

                                        case 3:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown3 = openTimer / 5;
                                            progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 4;
                                            }
                                            break;

                                        case 4:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown4 = openTimer / 5;
                                            progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 5;
                                            }
                                            break;

                                        case 5:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown5 = openTimer / 5;
                                            progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            progressTimer5.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                Destroy(gameObject);
                                                progressTimer1.gameObject.SetActive(false);
                                                progressTimer2.gameObject.SetActive(false);
                                                progressTimer3.gameObject.SetActive(false);
                                                progressTimer4.gameObject.SetActive(false);
                                                progressTimer5.gameObject.SetActive(false);
                                            }
                                            break;
                                    }
                                    break;



                            }

                        }
                        break;
                    case 4:
                        if (Input.GetKey(KeyCode.Joystick4Button5))
                        {
                            if (other.GetComponent<HostageController>().openingDoor == false)
                            {
                                OpeningDoor.Add(other.gameObject);
                                other.GetComponent<HostageController>().openingDoor = true;
                            }


                            switch (OpeningDoor.Count)
                            {
                                case 1:
                                    switch (stage)
                                    {
                                        case 1:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown1 = openTimer / 5;
                                            progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 2;
                                            }
                                            break;
                                        case 2:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown2 = openTimer / 5;
                                            progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 3;
                                            }
                                            break;

                                        case 3:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown3 = openTimer / 5;
                                            progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 4;
                                            }
                                            break;

                                        case 4:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown4 = openTimer / 5;
                                            progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 5;
                                            }
                                            break;

                                        case 5:
                                            openTimer += Time.deltaTime;
                                            float calc_cooldown5 = openTimer / 5;
                                            progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            progressTimer5.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                Destroy(gameObject);
                                                progressTimer1.gameObject.SetActive(false);
                                                progressTimer2.gameObject.SetActive(false);
                                                progressTimer3.gameObject.SetActive(false);
                                                progressTimer4.gameObject.SetActive(false);
                                                progressTimer5.gameObject.SetActive(false);
                                            }
                                            break;
                                    }
                                    break;

                                case 2:
                                    switch (stage)
                                    {
                                        case 1:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown1 = openTimer / 5;
                                            progressTimer1.fillAmount = Mathf.Clamp(calc_cooldown1, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 2;
                                            }
                                            break;
                                        case 2:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown2 = openTimer / 5;
                                            progressTimer2.fillAmount = Mathf.Clamp(calc_cooldown2, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 3;
                                            }
                                            break;

                                        case 3:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown3 = openTimer / 5;
                                            progressTimer3.fillAmount = Mathf.Clamp(calc_cooldown3, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 4;
                                            }
                                            break;

                                        case 4:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown4 = openTimer / 5;
                                            progressTimer4.fillAmount = Mathf.Clamp(calc_cooldown4, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                stage = 5;
                                            }
                                            break;

                                        case 5:
                                            openTimer += Time.deltaTime * 0.75f;
                                            float calc_cooldown5 = openTimer / 5;
                                            progressTimer5.fillAmount = Mathf.Clamp(calc_cooldown5, 0, 1);
                                            progressTimer1.gameObject.SetActive(true);
                                            progressTimer2.gameObject.SetActive(true);
                                            progressTimer3.gameObject.SetActive(true);
                                            progressTimer4.gameObject.SetActive(true);
                                            progressTimer5.gameObject.SetActive(true);
                                            if (openTimer > 5)
                                            {
                                                openTimer = 0;
                                                Destroy(gameObject);
                                                progressTimer1.gameObject.SetActive(false);
                                                progressTimer2.gameObject.SetActive(false);
                                                progressTimer3.gameObject.SetActive(false);
                                                progressTimer4.gameObject.SetActive(false);
                                                progressTimer5.gameObject.SetActive(false);
                                            }
                                            break;
                                    }
                                    break;



                            }

                        }
                        break;
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GM.Hostages.Contains(other.gameObject))
        {
            if(other.GetComponent<HostageController>().openingDoor == true)
            {
                OpeningDoor.Remove(other.gameObject);
                other.GetComponent<HostageController>().openingDoor = false;
            }
        }
    }
}
