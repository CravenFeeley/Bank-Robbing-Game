using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameManager GM;

    public enum Team
    {
        HOSTAGE,
        ROBBER,
        NULL
    }
    public Team playerteam;

    public GameObject Highlighted;
    public int HighlightedCount;

    public GameObject ControlledCharacter;

    public int controllernumber;
    public bool keyboardcontroller;

    public enum HostageSelection
    {
        LOADING,
        WAITING,
        NOTHING,
        BEGINNING,
        SCROLLING,
        SELECTION
    }

    public float SelectCountdown;
    public float SelectBeginning;

    public bool playerselectionmade;
    public bool teamselectionmade;

    public HostageSelection hostageselector;

    void Start()
    {
        hostageselector = HostageSelection.LOADING;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //GM.HostageTeam.Add(gameObject);
        //GM.PlayerList.Add(gameObject);
    }


    void Update()
    {


        if (GM.playerselect == GameManager.PlayerSelect.NOTHING)
        {
            if (playerteam == Team.HOSTAGE)
            {

                switch (hostageselector)
                {

                    case HostageSelection.LOADING:

                        if(GM.playerselect == GameManager.PlayerSelect.NOTHING)
                        {
                            hostageselector = HostageSelection.BEGINNING;
                        }

                        break;

                    case HostageSelection.WAITING:
                        SelectCountdown -= Time.deltaTime;
                        if (SelectCountdown <= 0)
                        {
                            SelectCountdown = SelectBeginning;
                            hostageselector = HostageSelection.BEGINNING;
                        }

                        break;
                    case HostageSelection.BEGINNING:
                        Highlighted = GM.HostagesAvailable[0];
                        HighlightedCount = 1;
                        switch (controllernumber)
                        {
                            case 1:
                                Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(true);
                                break;
                            case 2:
                                Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(true);
                                break;
                            case 3:
                                Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(true);
                                break;
                            case 4:
                                Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(true);
                                break;
                            case 0:
                                Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(true);
                                break;
                        }
                        hostageselector = HostageSelection.SELECTION;
                        break;
                    case HostageSelection.SCROLLING:
                        if (Highlighted.GetComponent<HostageController>().Controlled == true || HighlightedCount > GM.HostagesAvailable.Count)
                        {
                            hostageselector = HostageSelection.BEGINNING;
                        }
                        switch (HighlightedCount)
                        {
                            case 1:
                                Highlighted = GM.HostagesAvailable[0];

                                switch (controllernumber)
                                {
                                    case 1:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(true);
                                        break;
                                    case 2:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(true);
                                        break;
                                    case 3:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(true);
                                        break;
                                    case 4:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(true);
                                        break;
                                    case 0:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(true);
                                        break;
                                }
                                hostageselector = HostageSelection.SELECTION;
                                break;
                            case 2:
                                Highlighted = GM.HostagesAvailable[1];
                                switch (controllernumber)
                                {
                                    case 1:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(true);
                                        break;
                                    case 2:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(true);
                                        break;
                                    case 3:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(true);
                                        break;
                                    case 4:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(true);
                                        break;
                                    case 0:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(true);
                                        break;
                                }
                                hostageselector = HostageSelection.SELECTION;
                                break;
                            case 3:
                                Highlighted = GM.HostagesAvailable[2];
                                switch (controllernumber)
                                {
                                    case 1:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(true);
                                        break;
                                    case 2:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(true);
                                        break;
                                    case 3:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(true);
                                        break;
                                    case 4:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(true);
                                        break;
                                    case 0:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(true);
                                        break;
                                }
                                hostageselector = HostageSelection.SELECTION;
                                break;
                            case 4:
                                Highlighted = GM.HostagesAvailable[3];
                                switch (controllernumber)
                                {
                                    case 1:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(true);
                                        break;
                                    case 2:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(true);
                                        break;
                                    case 3:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(true);
                                        break;
                                    case 4:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(true);
                                        break;
                                    case 0:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(true);
                                        break;
                                }
                                hostageselector = HostageSelection.SELECTION;
                                break;
                        }

                        break;

                    case HostageSelection.SELECTION:

                        if (keyboardcontroller == true)
                        {
                            if (Input.GetKeyDown(KeyCode.D))
                            {
                                if (HighlightedCount == GM.HostagesAvailable.Count)
                                {
                                    HighlightedCount = 1;
                                }
                                else
                                {
                                    HighlightedCount++;
                                }
                                switch (controllernumber)
                                {
                                    case 1:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                        break;
                                    case 2:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                        break;
                                    case 3:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                        break;
                                    case 4:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                        break;
                                    case 0:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                        break;
                                }

                                hostageselector = HostageSelection.SCROLLING;
                            }
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                if (HighlightedCount == 1)
                                {
                                    HighlightedCount = GM.HostagesAvailable.Count;
                                }
                                else
                                {
                                    HighlightedCount--;
                                }
                                switch (controllernumber)
                                {
                                    case 1:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                        break;
                                    case 2:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                        break;
                                    case 3:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                        break;
                                    case 4:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                        break;
                                    case 0:
                                        Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                        break;
                                }
                                hostageselector = HostageSelection.SCROLLING;
                            }
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                Debug.Log("Select");
                                GM.HostagesControlled.Add(Highlighted);
                                Highlighted.GetComponent<HostageController>().Protected = true;
                                GM.HostagesAvailable.Remove(Highlighted);
                                ControlledCharacter = Highlighted;
                                ControlledCharacter.GetComponent<HostageController>().Player = gameObject;
                                Highlighted.GetComponent<HostageController>().Controlled = true;
                                if (Highlighted.GetComponent<HostageController>().TransportPointInUse == true)
                                {
                                    GM.TransformPoints.Add(Highlighted.GetComponent<HostageController>().TransportPoint);
                                    Highlighted.GetComponent<HostageController>().TransportPointInUse = false;
                                }
                                hostageselector = HostageSelection.NOTHING;
                            }
                        }

                        switch (controllernumber)
                        {
                            case 1:
                                if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                                {
                                    if (HighlightedCount == GM.HostagesAvailable.Count)
                                    {
                                        HighlightedCount = 1;
                                    }
                                    else
                                    {
                                        HighlightedCount++;
                                    }
                                    switch (controllernumber)
                                    {
                                        case 1:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                            break;
                                        case 2:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                            break;
                                        case 3:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                            break;
                                        case 4:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                            break;
                                        case 0:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                            break;
                                    }

                                    hostageselector = HostageSelection.SCROLLING;
                                }
                                if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                                {
                                    if (HighlightedCount == 1)
                                    {
                                        HighlightedCount = GM.HostagesAvailable.Count;
                                    }
                                    else
                                    {
                                        HighlightedCount--;
                                    }
                                    switch (controllernumber)
                                    {
                                        case 1:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                            break;
                                        case 2:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                            break;
                                        case 3:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                            break;
                                        case 4:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                            break;
                                        case 0:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                            break;
                                    }
                                    hostageselector = HostageSelection.SCROLLING;
                                }
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    Debug.Log("Select");
                                    GM.HostagesControlled.Add(Highlighted);
                                    Highlighted.GetComponent<HostageController>().Protected = true;
                                    GM.HostagesAvailable.Remove(Highlighted);
                                    ControlledCharacter = Highlighted;
                                    ControlledCharacter.GetComponent<HostageController>().Player = gameObject;
                                    Highlighted.GetComponent<HostageController>().Controlled = true;
                                    if (Highlighted.GetComponent<HostageController>().TransportPointInUse == true)
                                    {
                                        GM.TransformPoints.Add(Highlighted.GetComponent<HostageController>().TransportPoint);
                                        Highlighted.GetComponent<HostageController>().TransportPointInUse = false;
                                    }
                                    hostageselector = HostageSelection.NOTHING;
                                }
                                break;
                            case 2:
                                if (Input.GetKeyDown(KeyCode.Joystick2Button1))
                                {

                                    if (HighlightedCount == GM.HostagesAvailable.Count)
                                    {
                                        HighlightedCount = 1;
                                    }
                                    else
                                    {
                                        HighlightedCount++;
                                    }
                                    switch (controllernumber)
                                    {
                                        case 1:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                            break;
                                        case 2:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                            break;
                                        case 3:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                            break;
                                        case 4:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                            break;
                                        case 0:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                            break;
                                    }
                                    hostageselector = HostageSelection.SCROLLING;
                                }
                                if (Input.GetKeyDown(KeyCode.Joystick2Button2))
                                {
                                    if (HighlightedCount == 1)
                                    {
                                        HighlightedCount = GM.HostagesAvailable.Count;
                                    }
                                    else
                                    {
                                        HighlightedCount--;
                                    }
                                    switch (controllernumber)
                                    {
                                        case 1:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                            break;
                                        case 2:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                            break;
                                        case 3:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                            break;
                                        case 4:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                            break;
                                        case 0:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                            break;
                                    }
                                    hostageselector = HostageSelection.SCROLLING;
                                }
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    Debug.Log("Select");
                                    GM.HostagesControlled.Add(Highlighted);
                                    Highlighted.GetComponent<HostageController>().Protected = true;
                                    GM.HostagesAvailable.Remove(Highlighted);
                                    ControlledCharacter = Highlighted;
                                    ControlledCharacter.GetComponent<HostageController>().Player = gameObject;
                                    Highlighted.GetComponent<HostageController>().Controlled = true;
                                    if (Highlighted.GetComponent<HostageController>().TransportPointInUse == true)
                                    {
                                        GM.TransformPoints.Add(Highlighted.GetComponent<HostageController>().TransportPoint);
                                        Highlighted.GetComponent<HostageController>().TransportPointInUse = false;
                                    }
                                    hostageselector = HostageSelection.NOTHING;
                                }
                                break;
                            case 3:
                                if (Input.GetKeyDown(KeyCode.Joystick3Button1))
                                {

                                    if (HighlightedCount == GM.HostagesAvailable.Count)
                                    {
                                        HighlightedCount = 1;
                                    }
                                    else
                                    {
                                        HighlightedCount++;
                                    }
                                    switch (controllernumber)
                                    {
                                        case 1:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                            break;
                                        case 2:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                            break;
                                        case 3:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                            break;
                                        case 4:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                            break;
                                        case 0:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                            break;
                                    }
                                    hostageselector = HostageSelection.SCROLLING;
                                }
                                if (Input.GetKeyDown(KeyCode.Joystick3Button2))
                                {
                                    if (HighlightedCount == 1)
                                    {
                                        HighlightedCount = GM.HostagesAvailable.Count;
                                    }
                                    else
                                    {
                                        HighlightedCount--;
                                    }
                                    switch (controllernumber)
                                    {
                                        case 1:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                            break;
                                        case 2:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                            break;
                                        case 3:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                            break;
                                        case 4:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                            break;
                                        case 0:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                            break;
                                    }
                                    hostageselector = HostageSelection.SCROLLING;
                                }
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    Debug.Log("Select");
                                    GM.HostagesControlled.Add(Highlighted);
                                    Highlighted.GetComponent<HostageController>().Protected = true;
                                    GM.HostagesAvailable.Remove(Highlighted);
                                    ControlledCharacter = Highlighted;
                                    ControlledCharacter.GetComponent<HostageController>().Player = gameObject;
                                    Highlighted.GetComponent<HostageController>().Controlled = true;
                                    if (Highlighted.GetComponent<HostageController>().TransportPointInUse == true)
                                    {
                                        GM.TransformPoints.Add(Highlighted.GetComponent<HostageController>().TransportPoint);
                                        Highlighted.GetComponent<HostageController>().TransportPointInUse = false;
                                    }
                                    hostageselector = HostageSelection.NOTHING;
                                }
                                break;
                            case 4:
                                if (Input.GetKeyDown(KeyCode.Joystick4Button1))
                                {

                                    if (HighlightedCount == GM.HostagesAvailable.Count)
                                    {
                                        HighlightedCount = 1;
                                    }
                                    else
                                    {
                                        HighlightedCount++;
                                    }
                                    switch (controllernumber)
                                    {
                                        case 1:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                            break;
                                        case 2:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                            break;
                                        case 3:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                            break;
                                        case 4:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                            break;
                                        case 0:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                            break;
                                    }
                                    hostageselector = HostageSelection.SCROLLING;
                                }
                                if (Input.GetKeyDown(KeyCode.Joystick4Button2))
                                {
                                    if (HighlightedCount == 1)
                                    {
                                        HighlightedCount = GM.HostagesAvailable.Count;
                                    }
                                    else
                                    {
                                        HighlightedCount--;
                                    }
                                    switch (controllernumber)
                                    {
                                        case 1:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector1.SetActive(false);
                                            break;
                                        case 2:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector2.SetActive(false);
                                            break;
                                        case 3:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector3.SetActive(false);
                                            break;
                                        case 4:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector4.SetActive(false);
                                            break;
                                        case 0:
                                            Highlighted.gameObject.GetComponent<HostageController>().Selector5.SetActive(false);
                                            break;
                                    }
                                    hostageselector = HostageSelection.SCROLLING;
                                }
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    Debug.Log("Select");
                                    GM.HostagesControlled.Add(Highlighted);
                                    Highlighted.GetComponent<HostageController>().Protected = true;
                                    GM.HostagesAvailable.Remove(Highlighted);
                                    ControlledCharacter = Highlighted;
                                    ControlledCharacter.GetComponent<HostageController>().Player = gameObject;
                                    Highlighted.GetComponent<HostageController>().Controlled = true;
                                    if (Highlighted.GetComponent<HostageController>().TransportPointInUse == true)
                                    {
                                        GM.TransformPoints.Add(Highlighted.GetComponent<HostageController>().TransportPoint);
                                        Highlighted.GetComponent<HostageController>().TransportPointInUse = false;
                                    }
                                    hostageselector = HostageSelection.NOTHING;
                                }
                                break;
                        }

                        break;

                    case HostageSelection.NOTHING:
                        break;
                }
            }
        }
    }

        public void RenderChecker()
        {


            switch (GM.PlayerList.Count)
            {
                case 1:
                    if (gameObject == GM.PlayerList[0] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[0];
                    }
                    break;
                case 2:
                    if (gameObject == GM.PlayerList[0] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[0];
                    }
                    if (gameObject == GM.PlayerList[1] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[1];
                    }
                    break;
                case 3:
                    if (gameObject == GM.PlayerList[0] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[0];
                    }
                    if (gameObject == GM.PlayerList[1] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[1];
                    }
                    if (gameObject == GM.PlayerList[2] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[2];
                    }
                    break;
                case 4:
                    if (gameObject == GM.PlayerList[0] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[0];
                    }
                    if (gameObject == GM.PlayerList[1] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[1];
                    }
                    if (gameObject == GM.PlayerList[2] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[2];
                    }
                    if (gameObject == GM.PlayerList[3] && playerteam == Team.HOSTAGE)
                    {
                        //Highlighted.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[3];
                    }
                    break;
            }

            foreach (GameObject hostage in GM.HostagesAvailable)
            {
                if (hostage == Highlighted)
                {
                    //hostage.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[5];
                }
                else
                {
                    //hostage.GetComponent<HostageController>().rend.sharedMaterial = GM.Materials[5];
                }
            }
        }
    }


