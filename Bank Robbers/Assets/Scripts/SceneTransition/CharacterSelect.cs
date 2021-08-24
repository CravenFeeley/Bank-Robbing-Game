using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public MenuButtons Mb;

    public GameObject characterSelect;
    public GameObject demolitionHighlight1;
    public GameObject demolitionHighlight2;
    public GameObject houseburglarHighlight1;
    public GameObject houseburglarHighlight2;
    public GameObject mastermindHighlight1;
    public GameObject mastermindHighlight2;

    public GameObject FourPlayerMastermind1;
    public GameObject FourPlayerMastermind2;
    public GameObject FourPlayerMastermind3;
    public GameObject FourPlayerMastermind4;

    public GameObject FourPlayerDemolition1;
    public GameObject FourPlayerDemolition2;
    public GameObject FourPlayerDemolition3;
    public GameObject FourPlayerDemolition4;

    public GameObject FourPlayerHouseBurglar1;
    public GameObject FourPlayerHouseBurglar2;
    public GameObject FourPlayerHouseBurglar3;
    public GameObject FourPlayerHouseBurglar4;

    public GameObject FourPlayercharacterselect1;
    public GameObject FourPlayercharacterselect2;
    public GameObject FourPlayercharacterselect3;
    public GameObject FourPlayercharacterselect4;

    public GameObject player1characterselect;
    public GameObject player2characterselect;
    public bool player1ready;
    public bool player2ready;
    public bool player3ready;
    public bool player4ready;

    public float startingTimer;
    public float selectTimerPlayer1;
    public bool coolingdownPlayer1;
    public float selectTimerPlayer2;
    public bool coolingdownPlayer2;
    public float selectTimerPlayer3;
    public bool coolingdownPlayer3;
    public float selectTimerPlayer4;
    public bool coolingdownPlayer4;

    // Start is called before the first frame update
    void Start()
    {
        Mb = GameObject.Find("LevelLoader").GetComponent<MenuButtons>();
        selectTimerPlayer1 = startingTimer;
        selectTimerPlayer2 = startingTimer;
    }

    // Update is called once per frame
    void Update()
    {

        if (coolingdownPlayer1 == true)
        {
            selectTimerPlayer1 -= Time.deltaTime;
        }
        if (coolingdownPlayer2 == true)
        {
            selectTimerPlayer2 -= Time.deltaTime;
        }
        Timecooldown();

        if (Mb.settings == MenuButtons.Settings.CharacterSelect)
        {
            switch (GameDetails.Players)
            {

                case 2:


                    if (GameDetails.player2.controllerNumber == 0)
                    {
                        if (GameDetails.player2.team == PlayerStats.PlayerTeam.Heister)
                        {
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                player2characterselect.SetActive(true);
                                player2ready = true;
                            }

                            if (Input.GetKeyDown(KeyCode.S))
                            {
                                switch (GameDetails.player2.character)
                                {
                                    case (PlayerStats.PlayerCharacter.Balanced):
                                        mastermindHighlight2.SetActive(false);
                                        demolitionHighlight2.SetActive(true);
                                        GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;


                                        break;
                                    case (PlayerStats.PlayerCharacter.Heavy):
                                        demolitionHighlight2.SetActive(false);
                                        houseburglarHighlight2.SetActive(true);
                                        GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                        break;
                                    case (PlayerStats.PlayerCharacter.Light):
                                        houseburglarHighlight2.SetActive(false);
                                        mastermindHighlight2.SetActive(true);
                                        GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                        break;
                                }
                            }

                            if (Input.GetKeyDown(KeyCode.W))
                            {
                                switch (GameDetails.player2.character)
                                {
                                    case (PlayerStats.PlayerCharacter.Balanced):
                                        mastermindHighlight2.SetActive(false);
                                        houseburglarHighlight2.SetActive(true);
                                        GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;


                                        break;
                                    case (PlayerStats.PlayerCharacter.Heavy):
                                        demolitionHighlight2.SetActive(false);
                                        mastermindHighlight2.SetActive(true);
                                        GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                        break;
                                    case (PlayerStats.PlayerCharacter.Light):
                                        houseburglarHighlight2.SetActive(false);
                                        demolitionHighlight2.SetActive(true);
                                        GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                        break;
                                }
                            }

                        }
                        else if (GameDetails.player2.team == PlayerStats.PlayerTeam.Hostage)
                        {
                            houseburglarHighlight2.SetActive(false);
                            demolitionHighlight2.SetActive(false);
                            mastermindHighlight2.SetActive(false);
                            player2characterselect.SetActive(true);
                            player2ready = true;
                        }
                    }

                    if (GameDetails.player1.controllerNumber == 0)
                    {
                        if (GameDetails.player1.team == PlayerStats.PlayerTeam.Heister)
                        {
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                player1characterselect.SetActive(true);
                                player1ready = true;
                            }

                            if (Input.GetKeyDown(KeyCode.S))
                            {
                                switch (GameDetails.player1.character)
                                {
                                    case (PlayerStats.PlayerCharacter.Balanced):
                                        mastermindHighlight1.SetActive(false);
                                        demolitionHighlight1.SetActive(true);
                                        GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;


                                        break;
                                    case (PlayerStats.PlayerCharacter.Heavy):
                                        demolitionHighlight1.SetActive(false);
                                        houseburglarHighlight1.SetActive(true);
                                        GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                        break;
                                    case (PlayerStats.PlayerCharacter.Light):
                                        houseburglarHighlight1.SetActive(false);
                                        mastermindHighlight1.SetActive(true);
                                        GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                        break;
                                }
                            }

                            if (Input.GetKeyDown(KeyCode.W))
                            {
                                switch (GameDetails.player1.character)
                                {
                                    case (PlayerStats.PlayerCharacter.Balanced):
                                        mastermindHighlight1.SetActive(false);
                                        houseburglarHighlight1.SetActive(true);
                                        GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;


                                        break;
                                    case (PlayerStats.PlayerCharacter.Heavy):
                                        demolitionHighlight1.SetActive(false);
                                        mastermindHighlight1.SetActive(true);
                                        GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                        break;
                                    case (PlayerStats.PlayerCharacter.Light):
                                        houseburglarHighlight1.SetActive(false);
                                        demolitionHighlight1.SetActive(true);
                                        GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                        break;
                                }
                            }

                        }
                        else if(GameDetails.player1.team == PlayerStats.PlayerTeam.Hostage)
                        {
                            houseburglarHighlight1.SetActive(false);
                            demolitionHighlight1.SetActive(false);
                            mastermindHighlight1.SetActive(false);
                            player1characterselect.SetActive(true);
                            player1ready = true;
                        }
                    }

                    if (GameDetails.player2.controllerNumber == 1)
                    {
                        if (GameDetails.player2.team == PlayerStats.PlayerTeam.Heister)
                        {
                            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                            {
                                player2characterselect.SetActive(true);
                                player2ready = true;

                            }

                            float teamvertical = Input.GetAxisRaw("Vertical Controller 1");

                            if (teamvertical < -0.1)
                            {

                                if (selectTimerPlayer2 == startingTimer)
                                {
                                    switch (GameDetails.player2.character)
                                    {

                                        case (PlayerStats.PlayerCharacter.Balanced):

                                            mastermindHighlight2.SetActive(false);
                                            demolitionHighlight2.SetActive(true);
                                            GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                            coolingdownPlayer2 = true;


                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):

                                            demolitionHighlight2.SetActive(false);
                                            houseburglarHighlight2.SetActive(true);
                                            GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                            coolingdownPlayer2 = true;


                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):

                                            houseburglarHighlight2.SetActive(false);
                                            mastermindHighlight2.SetActive(true);
                                            GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                            coolingdownPlayer2 = true;


                                            break;
                                    }
                                }
                                else
                                {
                                }
                            }

                            if (teamvertical > 0.1)
                            {
                                if (selectTimerPlayer2 == startingTimer)
                                {
                                    switch (GameDetails.player2.character)
                                    {

                                        case (PlayerStats.PlayerCharacter.Balanced):

                                            mastermindHighlight2.SetActive(false);
                                            houseburglarHighlight2.SetActive(true);
                                            coolingdownPlayer2 = true;
                                            GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;


                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):

                                            demolitionHighlight2.SetActive(false);
                                            mastermindHighlight2.SetActive(true);
                                            coolingdownPlayer2 = true;
                                            GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):

                                            houseburglarHighlight2.SetActive(false);
                                            demolitionHighlight2.SetActive(true);
                                            coolingdownPlayer2 = true;
                                            GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;

                                            break;
                                    }
                                }
                                else
                                {
                                }
                            }

                        }
                        else if (GameDetails.player2.team == PlayerStats.PlayerTeam.Hostage)
                        {
                            houseburglarHighlight2.SetActive(false);
                            demolitionHighlight2.SetActive(false);
                            mastermindHighlight2.SetActive(false);
                            player2characterselect.SetActive(true);
                            player2ready = true;
                        }
                    }

                    if (GameDetails.player1.controllerNumber == 1)
                    {
                        if (GameDetails.player1.team == PlayerStats.PlayerTeam.Heister)
                        {
                            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                            {
                                player1characterselect.SetActive(true);
                                player1ready = true;
                            }

                            switch (GameDetails.player1.character)
                            {
                                case (PlayerStats.PlayerCharacter.Balanced):
                                    mastermindHighlight1.SetActive(true);
                                    demolitionHighlight1.SetActive(false);
                                    houseburglarHighlight1.SetActive(false);
                                    break;
                                case (PlayerStats.PlayerCharacter.Heavy):
                                    mastermindHighlight1.SetActive(false);
                                    demolitionHighlight1.SetActive(true);
                                    houseburglarHighlight1.SetActive(false);
                                    break;
                                case (PlayerStats.PlayerCharacter.Light):
                                    mastermindHighlight1.SetActive(false);
                                    demolitionHighlight1.SetActive(false);
                                    houseburglarHighlight1.SetActive(true);
                                    break;

                            }


                            float teamvertical = Input.GetAxisRaw("Vertical Controller 1");

                            if (teamvertical < -0.1)
                            {
                                if (selectTimerPlayer1 == startingTimer)
                                {
                                    switch (GameDetails.player1.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):


                                            GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                            coolingdownPlayer1 = true;


                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):


                                            GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                            coolingdownPlayer1 = true;

                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):


                                            GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                            coolingdownPlayer1 = true;
                                            break;
                                    }
                                }
                                else
                                {
                                }
                            }

                            if (teamvertical > 0.1)
                            {
                                if (selectTimerPlayer1 == startingTimer)
                                {
                                    switch (GameDetails.player1.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):


                                            GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                            coolingdownPlayer1 = true;



                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):


                                            GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                            coolingdownPlayer1 = true;

                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):


                                            GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                            coolingdownPlayer1 = true;


                                            break;
                                    }
                                }
                                else
                                {
                                }
                            }

                        }
                        else if (GameDetails.player1.team == PlayerStats.PlayerTeam.Hostage)
                        {
                            houseburglarHighlight1.SetActive(false);
                            demolitionHighlight1.SetActive(false);
                            mastermindHighlight1.SetActive(false);
                            player1characterselect.SetActive(true);
                            player1ready = true;
                        }
                    }


                    break;

                case 4:

                    switch (GameDetails.player1.controllerNumber)
                    {
                        case 0:
                            switch(GameDetails.player1.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Space))
                                    {
                                        FourPlayercharacterselect1.SetActive(true);
                                        player1ready = true;
                                    }

                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        switch (GameDetails.player1.character)
                                        {
                                            case (PlayerStats.PlayerCharacter.Balanced):
                                                FourPlayerMastermind1.SetActive(false);
                                                FourPlayerDemolition1.SetActive(true);
                                                GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;


                                                break;
                                            case (PlayerStats.PlayerCharacter.Heavy):
                                                FourPlayerDemolition1.SetActive(false);
                                                FourPlayerHouseBurglar1.SetActive(true);
                                                GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                                break;
                                            case (PlayerStats.PlayerCharacter.Light):
                                                FourPlayerHouseBurglar1.SetActive(false);
                                                FourPlayerMastermind1.SetActive(true);
                                                GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                                break;
                                        }
                                    }

                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        switch (GameDetails.player1.character)
                                        {
                                            case (PlayerStats.PlayerCharacter.Balanced):
                                                FourPlayerMastermind1.SetActive(false);
                                                FourPlayerHouseBurglar1.SetActive(true);
                                                GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;


                                                break;
                                            case (PlayerStats.PlayerCharacter.Heavy):
                                                FourPlayerDemolition1.SetActive(false);
                                                FourPlayerMastermind1.SetActive(true);
                                                GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                                break;
                                            case (PlayerStats.PlayerCharacter.Light):
                                                FourPlayerHouseBurglar1.SetActive(false);
                                                FourPlayerDemolition1.SetActive(true);
                                                GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                                break;
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:
                                    FourPlayerHouseBurglar1.SetActive(false);
                                    FourPlayerDemolition1.SetActive(false);
                                    FourPlayerMastermind1.SetActive(false);
                                    FourPlayercharacterselect1.SetActive(true);
                                    player1ready = true;
                                    break;
                            }


                            break;
                        case 1:

                            switch (GameDetails.player1.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                    {
                                        FourPlayercharacterselect1.SetActive(true);
                                        player1ready = true;
                                    }

                                    switch (GameDetails.player1.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind1.SetActive(true);
                                            FourPlayerDemolition1.SetActive(false);
                                            FourPlayerHouseBurglar1.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind1.SetActive(false);
                                            FourPlayerDemolition1.SetActive(true);
                                            FourPlayerHouseBurglar1.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind1.SetActive(false);
                                            FourPlayerDemolition1.SetActive(false);
                                            FourPlayerHouseBurglar1.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 1");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer1 == startingTimer)
                                        {
                                            switch (GameDetails.player1.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer1 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer1 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer1 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer1 == startingTimer)
                                        {
                                            switch (GameDetails.player1.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer1 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer1 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer1 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar1.SetActive(false);
                                    FourPlayerDemolition1.SetActive(false);
                                    FourPlayerMastermind1.SetActive(false);
                                    FourPlayercharacterselect1.SetActive(true);
                                    player1ready = true;

                                    break;
                            }


                            break;
                        case 2:
                            switch (GameDetails.player1.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                    {
                                        FourPlayercharacterselect1.SetActive(true);
                                        player1ready = true;
                                    }

                                    switch (GameDetails.player1.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind1.SetActive(true);
                                            FourPlayerDemolition1.SetActive(false);
                                            FourPlayerHouseBurglar1.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind1.SetActive(false);
                                            FourPlayerDemolition1.SetActive(true);
                                            FourPlayerHouseBurglar1.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind1.SetActive(false);
                                            FourPlayerDemolition1.SetActive(false);
                                            FourPlayerHouseBurglar1.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 2");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer1 == startingTimer)
                                        {
                                            switch (GameDetails.player1.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer1 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer1 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer1 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer1 == startingTimer)
                                        {
                                            switch (GameDetails.player1.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer1 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer1 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer1 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar1.SetActive(false);
                                    FourPlayerDemolition1.SetActive(false);
                                    FourPlayerMastermind1.SetActive(false);
                                    FourPlayercharacterselect1.SetActive(true);
                                    player1ready = true;

                                    break;
                            }
                            break;
                        case 3:
                            switch (GameDetails.player1.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                    {
                                        FourPlayercharacterselect1.SetActive(true);
                                        player1ready = true;
                                    }

                                    switch (GameDetails.player1.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind1.SetActive(true);
                                            FourPlayerDemolition1.SetActive(false);
                                            FourPlayerHouseBurglar1.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind1.SetActive(false);
                                            FourPlayerDemolition1.SetActive(true);
                                            FourPlayerHouseBurglar1.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind1.SetActive(false);
                                            FourPlayerDemolition1.SetActive(false);
                                            FourPlayerHouseBurglar1.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 3");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer1 == startingTimer)
                                        {
                                            switch (GameDetails.player1.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer1 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer1 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer1 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer1 == startingTimer)
                                        {
                                            switch (GameDetails.player1.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer1 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer1 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer1 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar1.SetActive(false);
                                    FourPlayerDemolition1.SetActive(false);
                                    FourPlayerMastermind1.SetActive(false);
                                    FourPlayercharacterselect1.SetActive(true);
                                    player1ready = true;

                                    break;
                            }
                            break;


                    }


                    switch (GameDetails.player2.controllerNumber)
                    {
                        case 0:
                            switch (GameDetails.player2.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Space))
                                    {
                                        FourPlayercharacterselect2.SetActive(true);
                                        player2ready = true;
                                    }

                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        switch (GameDetails.player2.character)
                                        {
                                            case (PlayerStats.PlayerCharacter.Balanced):
                                                FourPlayerMastermind2.SetActive(false);
                                                FourPlayerDemolition2.SetActive(true);
                                                GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;


                                                break;
                                            case (PlayerStats.PlayerCharacter.Heavy):
                                                FourPlayerDemolition2.SetActive(false);
                                                FourPlayerHouseBurglar2.SetActive(true);
                                                GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                                break;
                                            case (PlayerStats.PlayerCharacter.Light):
                                                FourPlayerHouseBurglar2.SetActive(false);
                                                FourPlayerMastermind2.SetActive(true);
                                                GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                                break;
                                        }
                                    }

                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        switch (GameDetails.player2.character)
                                        {
                                            case (PlayerStats.PlayerCharacter.Balanced):
                                                FourPlayerMastermind2.SetActive(false);
                                                FourPlayerHouseBurglar2.SetActive(true);
                                                GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;


                                                break;
                                            case (PlayerStats.PlayerCharacter.Heavy):
                                                FourPlayerDemolition2.SetActive(false);
                                                FourPlayerMastermind2.SetActive(true);
                                                GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                                break;
                                            case (PlayerStats.PlayerCharacter.Light):
                                                FourPlayerHouseBurglar2.SetActive(false);
                                                FourPlayerDemolition2.SetActive(true);
                                                GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                                break;
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:
                                    FourPlayerHouseBurglar2.SetActive(false);
                                    FourPlayerDemolition2.SetActive(false);
                                    FourPlayerMastermind2.SetActive(false);
                                    FourPlayercharacterselect2.SetActive(true);
                                    player2ready = true;
                                    break;
                            }


                            break;
                        case 1:

                            switch (GameDetails.player2.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                    {
                                        FourPlayercharacterselect2.SetActive(true);
                                        player2ready = true;
                                    }

                                    switch (GameDetails.player2.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind2.SetActive(true);
                                            FourPlayerDemolition2.SetActive(false);
                                            FourPlayerHouseBurglar2.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind2.SetActive(false);
                                            FourPlayerDemolition2.SetActive(true);
                                            FourPlayerHouseBurglar2.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind2.SetActive(false);
                                            FourPlayerDemolition2.SetActive(false);
                                            FourPlayerHouseBurglar2.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 1");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer2 == startingTimer)
                                        {
                                            switch (GameDetails.player2.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer2 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer2 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer2 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer2 == startingTimer)
                                        {
                                            switch (GameDetails.player2.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer2 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer2 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer2 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar2.SetActive(false);
                                    FourPlayerDemolition2.SetActive(false);
                                    FourPlayerMastermind2.SetActive(false);
                                    FourPlayercharacterselect2.SetActive(true);
                                    player2ready = true;

                                    break;
                            }


                            break;
                        case 2:
                            switch (GameDetails.player2.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                    {
                                        FourPlayercharacterselect2.SetActive(true);
                                        player2ready = true;
                                    }

                                    switch (GameDetails.player2.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind2.SetActive(true);
                                            FourPlayerDemolition2.SetActive(false);
                                            FourPlayerHouseBurglar2.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind2.SetActive(false);
                                            FourPlayerDemolition2.SetActive(true);
                                            FourPlayerHouseBurglar2.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind2.SetActive(false);
                                            FourPlayerDemolition2.SetActive(false);
                                            FourPlayerHouseBurglar2.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 2");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer2 == startingTimer)
                                        {
                                            switch (GameDetails.player2.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer2 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer2 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer2 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer2 == startingTimer)
                                        {
                                            switch (GameDetails.player2.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer2 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer2 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer2 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar2.SetActive(false);
                                    FourPlayerDemolition2.SetActive(false);
                                    FourPlayerMastermind2.SetActive(false);
                                    FourPlayercharacterselect2.SetActive(true);
                                    player2ready = true;

                                    break;
                            }
                            break;
                        case 3:
                            switch (GameDetails.player2.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                    {
                                        FourPlayercharacterselect2.SetActive(true);
                                        player2ready = true;
                                    }

                                    switch (GameDetails.player2.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind2.SetActive(true);
                                            FourPlayerDemolition2.SetActive(false);
                                            FourPlayerHouseBurglar2.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind2.SetActive(false);
                                            FourPlayerDemolition2.SetActive(true);
                                            FourPlayerHouseBurglar2.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind2.SetActive(false);
                                            FourPlayerDemolition2.SetActive(false);
                                            FourPlayerHouseBurglar2.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 3");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer2 == startingTimer)
                                        {
                                            switch (GameDetails.player2.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer2 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer2 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer2 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer2 == startingTimer)
                                        {
                                            switch (GameDetails.player2.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer2 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer2 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer2 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar2.SetActive(false);
                                    FourPlayerDemolition2.SetActive(false);
                                    FourPlayerMastermind2.SetActive(false);
                                    FourPlayercharacterselect2.SetActive(true);
                                    player2ready = true;

                                    break;
                            }
                            break;


                    }

                    
                    switch (GameDetails.player3.controllerNumber)
                    {
                        case 0:
                            switch (GameDetails.player3.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Space))
                                    {
                                        FourPlayercharacterselect3.SetActive(true);
                                        player3ready = true;
                                    }

                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        switch (GameDetails.player3.character)
                                        {
                                            case (PlayerStats.PlayerCharacter.Balanced):
                                                FourPlayerMastermind3.SetActive(false);
                                                FourPlayerDemolition3.SetActive(true);
                                                GameDetails.player3.character = PlayerStats.PlayerCharacter.Heavy;


                                                break;
                                            case (PlayerStats.PlayerCharacter.Heavy):
                                                FourPlayerDemolition3.SetActive(false);
                                                FourPlayerHouseBurglar3.SetActive(true);
                                                GameDetails.player3.character = PlayerStats.PlayerCharacter.Light;
                                                break;
                                            case (PlayerStats.PlayerCharacter.Light):
                                                FourPlayerHouseBurglar3.SetActive(false);
                                                FourPlayerMastermind3.SetActive(true);
                                                GameDetails.player3.character = PlayerStats.PlayerCharacter.Balanced;
                                                break;
                                        }
                                    }

                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        switch (GameDetails.player3.character)
                                        {
                                            case (PlayerStats.PlayerCharacter.Balanced):
                                                FourPlayerMastermind3.SetActive(false);
                                                FourPlayerHouseBurglar3.SetActive(true);
                                                GameDetails.player3.character = PlayerStats.PlayerCharacter.Light;


                                                break;
                                            case (PlayerStats.PlayerCharacter.Heavy):
                                                FourPlayerDemolition3.SetActive(false);
                                                FourPlayerMastermind3.SetActive(true);
                                                GameDetails.player3.character = PlayerStats.PlayerCharacter.Balanced;
                                                break;
                                            case (PlayerStats.PlayerCharacter.Light):
                                                FourPlayerHouseBurglar3.SetActive(false);
                                                FourPlayerDemolition3.SetActive(true);
                                                GameDetails.player3.character = PlayerStats.PlayerCharacter.Heavy;
                                                break;
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:
                                    FourPlayerHouseBurglar3.SetActive(false);
                                    FourPlayerDemolition3.SetActive(false);
                                    FourPlayerMastermind3.SetActive(false);
                                    FourPlayercharacterselect3.SetActive(true);
                                    player3ready = true;
                                    break;
                            }


                            break;
                        case 1:

                            switch (GameDetails.player3.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                    {
                                        FourPlayercharacterselect3.SetActive(true);
                                        player3ready = true;
                                    }

                                    switch (GameDetails.player3.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind3.SetActive(true);
                                            FourPlayerDemolition3.SetActive(false);
                                            FourPlayerHouseBurglar3.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind3.SetActive(false);
                                            FourPlayerDemolition3.SetActive(true);
                                            FourPlayerHouseBurglar3.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind3.SetActive(false);
                                            FourPlayerDemolition3.SetActive(false);
                                            FourPlayerHouseBurglar3.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 1");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer3 == startingTimer)
                                        {
                                            switch (GameDetails.player3.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer3 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer3 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer3 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer3 == startingTimer)
                                        {
                                            switch (GameDetails.player3.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer3 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer3 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer3 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar3.SetActive(false);
                                    FourPlayerDemolition3.SetActive(false);
                                    FourPlayerMastermind3.SetActive(false);
                                    FourPlayercharacterselect3.SetActive(true);
                                    player3ready = true;

                                    break;
                            }


                            break;
                        case 3:
                            switch (GameDetails.player3.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                    {
                                        FourPlayercharacterselect3.SetActive(true);
                                        player3ready = true;
                                    }

                                    switch (GameDetails.player3.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind3.SetActive(true);
                                            FourPlayerDemolition3.SetActive(false);
                                            FourPlayerHouseBurglar3.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind3.SetActive(false);
                                            FourPlayerDemolition3.SetActive(true);
                                            FourPlayerHouseBurglar3.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind3.SetActive(false);
                                            FourPlayerDemolition3.SetActive(false);
                                            FourPlayerHouseBurglar3.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 2");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer3 == startingTimer)
                                        {
                                            switch (GameDetails.player3.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer3 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer3 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer3 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer3 == startingTimer)
                                        {
                                            switch (GameDetails.player3.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer3 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer3 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer3 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar3.SetActive(false);
                                    FourPlayerDemolition3.SetActive(false);
                                    FourPlayerMastermind3.SetActive(false);
                                    FourPlayercharacterselect3.SetActive(true);
                                    player3ready = true;

                                    break;
                            }
                            break;
                        case 2:
                            switch (GameDetails.player3.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                    {
                                        FourPlayercharacterselect3.SetActive(true);
                                        player3ready = true;
                                    }

                                    switch (GameDetails.player3.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind3.SetActive(true);
                                            FourPlayerDemolition3.SetActive(false);
                                            FourPlayerHouseBurglar3.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind3.SetActive(false);
                                            FourPlayerDemolition3.SetActive(true);
                                            FourPlayerHouseBurglar3.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind3.SetActive(false);
                                            FourPlayerDemolition3.SetActive(false);
                                            FourPlayerHouseBurglar3.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 3");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer3 == startingTimer)
                                        {
                                            switch (GameDetails.player3.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer3 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer3 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer3 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer3 == startingTimer)
                                        {
                                            switch (GameDetails.player3.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer3 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer3 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player3.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer3 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar3.SetActive(false);
                                    FourPlayerDemolition3.SetActive(false);
                                    FourPlayerMastermind3.SetActive(false);
                                    FourPlayercharacterselect3.SetActive(true);
                                    player3ready = true;

                                    break;
                            }
                            break;


                    }


                    switch (GameDetails.player4.controllerNumber)
                    {
                        case 0:
                            switch (GameDetails.player4.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Space))
                                    {
                                        FourPlayercharacterselect4.SetActive(true);
                                        player4ready = true;
                                    }

                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        switch (GameDetails.player4.character)
                                        {
                                            case (PlayerStats.PlayerCharacter.Balanced):
                                                FourPlayerMastermind4.SetActive(false);
                                                FourPlayerDemolition4.SetActive(true);
                                                GameDetails.player4.character = PlayerStats.PlayerCharacter.Heavy;


                                                break;
                                            case (PlayerStats.PlayerCharacter.Heavy):
                                                FourPlayerDemolition4.SetActive(false);
                                                FourPlayerHouseBurglar4.SetActive(true);
                                                GameDetails.player4.character = PlayerStats.PlayerCharacter.Light;
                                                break;
                                            case (PlayerStats.PlayerCharacter.Light):
                                                FourPlayerHouseBurglar4.SetActive(false);
                                                FourPlayerMastermind4.SetActive(true);
                                                GameDetails.player4.character = PlayerStats.PlayerCharacter.Balanced;
                                                break;
                                        }
                                    }

                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        switch (GameDetails.player4.character)
                                        {
                                            case (PlayerStats.PlayerCharacter.Balanced):
                                                FourPlayerMastermind4.SetActive(false);
                                                FourPlayerHouseBurglar4.SetActive(true);
                                                GameDetails.player4.character = PlayerStats.PlayerCharacter.Light;


                                                break;
                                            case (PlayerStats.PlayerCharacter.Heavy):
                                                FourPlayerDemolition4.SetActive(false);
                                                FourPlayerMastermind4.SetActive(true);
                                                GameDetails.player4.character = PlayerStats.PlayerCharacter.Balanced;
                                                break;
                                            case (PlayerStats.PlayerCharacter.Light):
                                                FourPlayerHouseBurglar4.SetActive(false);
                                                FourPlayerDemolition4.SetActive(true);
                                                GameDetails.player4.character = PlayerStats.PlayerCharacter.Heavy;
                                                break;
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:
                                    FourPlayerHouseBurglar4.SetActive(false);
                                    FourPlayerDemolition4.SetActive(false);
                                    FourPlayerMastermind4.SetActive(false);
                                    FourPlayercharacterselect4.SetActive(true);
                                    player4ready = true;
                                    break;
                            }


                            break;
                        case 1:

                            switch (GameDetails.player4.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                    {
                                        FourPlayercharacterselect4.SetActive(true);
                                        player4ready = true;
                                    }

                                    switch (GameDetails.player4.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind4.SetActive(true);
                                            FourPlayerDemolition4.SetActive(false);
                                            FourPlayerHouseBurglar4.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind4.SetActive(false);
                                            FourPlayerDemolition4.SetActive(true);
                                            FourPlayerHouseBurglar4.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind4.SetActive(false);
                                            FourPlayerDemolition4.SetActive(false);
                                            FourPlayerHouseBurglar4.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 1");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer4 == startingTimer)
                                        {
                                            switch (GameDetails.player4.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer4 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer4 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer4 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer4 == startingTimer)
                                        {
                                            switch (GameDetails.player4.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer4 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer4 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer4 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar4.SetActive(false);
                                    FourPlayerDemolition4.SetActive(false);
                                    FourPlayerMastermind4.SetActive(false);
                                    FourPlayercharacterselect4.SetActive(true);
                                    player4ready = true;

                                    break;
                            }


                            break;
                        case 2:
                            switch (GameDetails.player4.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                    {
                                        FourPlayercharacterselect4.SetActive(true);
                                        player4ready = true;
                                    }

                                    switch (GameDetails.player4.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind4.SetActive(true);
                                            FourPlayerDemolition4.SetActive(false);
                                            FourPlayerHouseBurglar4.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind4.SetActive(false);
                                            FourPlayerDemolition4.SetActive(true);
                                            FourPlayerHouseBurglar4.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind4.SetActive(false);
                                            FourPlayerDemolition4.SetActive(false);
                                            FourPlayerHouseBurglar4.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 2");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer4 == startingTimer)
                                        {
                                            switch (GameDetails.player4.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer4 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer4 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer4 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer4 == startingTimer)
                                        {
                                            switch (GameDetails.player4.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer4 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer4 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer4 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar4.SetActive(false);
                                    FourPlayerDemolition4.SetActive(false);
                                    FourPlayerMastermind4.SetActive(false);
                                    FourPlayercharacterselect4.SetActive(true);
                                    player4ready = true;

                                    break;
                            }
                            break;
                        case 3:
                            switch (GameDetails.player4.team)
                            {
                                case PlayerStats.PlayerTeam.Heister:

                                    if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                    {
                                        FourPlayercharacterselect4.SetActive(true);
                                        player4ready = true;
                                    }

                                    switch (GameDetails.player4.character)
                                    {
                                        case (PlayerStats.PlayerCharacter.Balanced):
                                            FourPlayerMastermind4.SetActive(true);
                                            FourPlayerDemolition4.SetActive(false);
                                            FourPlayerHouseBurglar4.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Heavy):
                                            FourPlayerMastermind4.SetActive(false);
                                            FourPlayerDemolition4.SetActive(true);
                                            FourPlayerHouseBurglar4.SetActive(false);
                                            break;
                                        case (PlayerStats.PlayerCharacter.Light):
                                            FourPlayerMastermind4.SetActive(false);
                                            FourPlayerDemolition4.SetActive(false);
                                            FourPlayerHouseBurglar4.SetActive(true);
                                            break;

                                    }


                                    float teamvertical = Input.GetAxisRaw("Vertical Controller 3");

                                    if (teamvertical < -0.1)
                                    {
                                        if (selectTimerPlayer4 == startingTimer)
                                        {
                                            switch (GameDetails.player4.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer4 = true;


                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer4 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer4 = true;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    if (teamvertical > 0.1)
                                    {
                                        if (selectTimerPlayer4 == startingTimer)
                                        {
                                            switch (GameDetails.player4.character)
                                            {
                                                case (PlayerStats.PlayerCharacter.Balanced):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Light;
                                                    coolingdownPlayer4 = true;



                                                    break;
                                                case (PlayerStats.PlayerCharacter.Heavy):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Balanced;
                                                    coolingdownPlayer4 = true;

                                                    break;
                                                case (PlayerStats.PlayerCharacter.Light):


                                                    GameDetails.player4.character = PlayerStats.PlayerCharacter.Heavy;
                                                    coolingdownPlayer4 = true;


                                                    break;
                                            }
                                        }
                                    }

                                    break;

                                case PlayerStats.PlayerTeam.Hostage:

                                    FourPlayerHouseBurglar4.SetActive(false);
                                    FourPlayerDemolition4.SetActive(false);
                                    FourPlayerMastermind4.SetActive(false);
                                    FourPlayercharacterselect4.SetActive(true);
                                    player4ready = true;

                                    break;
                            }
                            break;


                    }
                    break;

            }


            switch(GameDetails.Players)
            {
                case 2:
                    if (player1ready == true && player2ready == true)
                    {
                        Mb.settings = MenuButtons.Settings.LoadGame;
                        if (GameDetails.player1.team == PlayerStats.PlayerTeam.Heister)
                        {
                            GameDetails.Heisters.Add(GameDetails.player1);
                        }
                        if (GameDetails.player2.team == PlayerStats.PlayerTeam.Heister)
                        {
                            GameDetails.Heisters.Add(GameDetails.player2);
                        }
                    }
                    break;
                case 4:
                    if (player1ready == true && player2ready == true && player3ready == true && player4ready == true)
                    {
                        if(GameDetails.player1.team == PlayerStats.PlayerTeam.Heister)
                        {
                            GameDetails.Heisters.Add(GameDetails.player1);
                        }
                        if (GameDetails.player2.team == PlayerStats.PlayerTeam.Heister)
                        {
                            GameDetails.Heisters.Add(GameDetails.player2);
                        }
                        if (GameDetails.player3.team == PlayerStats.PlayerTeam.Heister)
                        {
                            GameDetails.Heisters.Add(GameDetails.player3);
                        }
                        if (GameDetails.player4.team == PlayerStats.PlayerTeam.Heister)
                        {
                            GameDetails.Heisters.Add(GameDetails.player4);
                        }


                        Mb.settings = MenuButtons.Settings.LoadGame;
                    }
                    break;
            }


        }
    }

    public void Timecooldown()
    {
        if (selectTimerPlayer1 <= 0)
        {
            selectTimerPlayer1 = startingTimer;
            coolingdownPlayer1 = false;


        }
        if (selectTimerPlayer2 <= 0)
        {
            selectTimerPlayer2 = startingTimer;
            coolingdownPlayer2 = false;


        }
    }
}
