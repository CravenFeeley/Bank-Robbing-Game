using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelect : MonoBehaviour
{
    public MenuButtons Mb;
    public CharacterSelect Cs;

    public GameObject FourPlayerConfirmPlayer1;
    public GameObject FourPlayerConfirmPlayer2;
    public GameObject FourPlayerConfirmPlayer3;
    public GameObject FourPlayerConfirmPlayer4;

    public GameObject TeamSelector;
    public GameObject TeamSelector4Player;

    public GameObject PlayerOneConfirm;
    public GameObject PlayerTwoConfirm;

    public GameObject Player1HeisterHighlight;
    public GameObject Player1HostageHighlight;
    public GameObject Player2HeisterHighlight;
    public GameObject Player2HostageHighlight;

    public GameObject FourPlayerHostage1;
    public GameObject FourPlayerHostage2;
    public GameObject FourPlayerHostage3;
    public GameObject FourPlayerHostage4;

    public GameObject FourPlayerHeister1;
    public GameObject FourPlayerHeister2;
    public GameObject FourPlayerHeister3;
    public GameObject FourPlayerHeister4;

    public List<int> Heisters = new List<int>();
    public List<int> Hostages = new List<int>();

    public bool Loading;
    public float LoadingTime;


    // Start is called before the first frame update
    void Start()
    {
        Mb = GameObject.Find("LevelLoader").GetComponent<MenuButtons>();
        Cs = GameObject.Find("LevelLoader").GetComponent<CharacterSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Loading == true)
        {
            LoadingTime -= Time.deltaTime;
            if (LoadingTime <= 0)
            {
                LoadingTime = 0;
                Mb.settings = MenuButtons.Settings.CharacterSelect;
            }

        }


        if (Mb.settings == MenuButtons.Settings.TeamSelect)
        {
            switch (GameDetails.Players)
            {
                #region 2playerteamselect
                case 2:
                    TeamSelector.SetActive(true);

                    if (GameDetails.player1.controllerNumber == 0)
                    {
                        switch (GameDetails.player1team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                Player1HostageHighlight.SetActive(false);
                                Player1HeisterHighlight.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        PlayerOneConfirm.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                Player1HostageHighlight.SetActive(true);
                                Player1HeisterHighlight.SetActive(false);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        PlayerOneConfirm.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player2.controllerNumber == 0)
                    {
                        switch (GameDetails.player2team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                Player2HostageHighlight.SetActive(false);
                                Player2HeisterHighlight.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        PlayerTwoConfirm.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                Player2HostageHighlight.SetActive(true);
                                Player2HeisterHighlight.SetActive(false);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        PlayerTwoConfirm.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }



                    if (GameDetails.player1.controllerNumber == 1)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
                        switch (GameDetails.player1team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                Player1HostageHighlight.SetActive(false);
                                Player1HeisterHighlight.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        PlayerOneConfirm.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                Player1HostageHighlight.SetActive(true);
                                Player1HeisterHighlight.SetActive(false);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        PlayerOneConfirm.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player2.controllerNumber == 1)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
                        switch (GameDetails.player2team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                Player2HostageHighlight.SetActive(false);
                                Player2HeisterHighlight.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        PlayerTwoConfirm.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                Player2HostageHighlight.SetActive(true);
                                Player2HeisterHighlight.SetActive(false);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        PlayerTwoConfirm.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Hostage;
                                    }


                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }



                    break;
                #endregion 2playerteamselect
                case 4:

                    TeamSelector4Player.SetActive(true);
                    #region 4PlayerKeyboardTeamSelect
                    if (GameDetails.player1.controllerNumber == 0)
                    {
                        switch (GameDetails.player1team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage1.SetActive(false);
                                FourPlayerHeister1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister1.SetActive(false);
                                FourPlayerHostage1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player2.controllerNumber == 0)
                    {
                        switch (GameDetails.player2team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage2.SetActive(false);
                                FourPlayerHeister2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister2.SetActive(false);
                                FourPlayerHostage2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }

                    if (GameDetails.player3.controllerNumber == 0)
                    {
                        switch (GameDetails.player3team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage3.SetActive(false);
                                FourPlayerHeister3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister3.SetActive(false);
                                FourPlayerHostage3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player4.controllerNumber == 0)
                    {
                        switch (GameDetails.player4team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage4.SetActive(false);
                                FourPlayerHeister4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister4.SetActive(false);
                                FourPlayerHostage4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    #endregion 4playerkeyboardteamselect

                    #region 4PlayerController1TeamSelect
                    if (GameDetails.player1.controllerNumber == 1)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
                        switch (GameDetails.player1team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage1.SetActive(false);
                                FourPlayerHeister1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister1.SetActive(false);
                                FourPlayerHostage1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player2.controllerNumber == 1)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
                        switch (GameDetails.player2team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage2.SetActive(false);
                                FourPlayerHeister2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister2.SetActive(false);
                                FourPlayerHostage2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }

                    if (GameDetails.player3.controllerNumber == 1)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
                        switch (GameDetails.player1team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage3.SetActive(false);
                                FourPlayerHeister3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister3.SetActive(false);
                                FourPlayerHostage3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player4.controllerNumber == 1)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 1");
                        switch (GameDetails.player2team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage4.SetActive(false);
                                FourPlayerHeister4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister4.SetActive(false);
                                FourPlayerHostage4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }

                    #endregion 4PlayerController1TeamSelect

                    #region 4PlayerController2TeamSelect

                    if (GameDetails.player1.controllerNumber == 2)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 2");
                        switch (GameDetails.player1team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage1.SetActive(false);
                                FourPlayerHeister1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister1.SetActive(false);
                                FourPlayerHostage1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player2.controllerNumber == 2)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 2");
                        switch (GameDetails.player2team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage2.SetActive(false);
                                FourPlayerHeister2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister2.SetActive(false);
                                FourPlayerHostage2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }

                    if (GameDetails.player3.controllerNumber == 1)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 2");
                        switch (GameDetails.player3team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage3.SetActive(false);
                                FourPlayerHeister3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister3.SetActive(false);
                                FourPlayerHostage3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player4.controllerNumber == 2)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 2");
                        switch (GameDetails.player4team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage4.SetActive(false);
                                FourPlayerHeister4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister4.SetActive(false);
                                FourPlayerHostage4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }

                    #endregion 4PlayerController2TeamSelect

                    #region 4PlayerController3TeamSelect

                    if (GameDetails.player1.controllerNumber == 3)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 3");
                        switch (GameDetails.player1team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage1.SetActive(false);
                                FourPlayerHeister1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister1.SetActive(false);
                                FourPlayerHostage1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player2.controllerNumber == 3)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 3");
                        switch (GameDetails.player2team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage2.SetActive(false);
                                FourPlayerHeister2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister2.SetActive(false);
                                FourPlayerHostage2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }

                    if (GameDetails.player3.controllerNumber == 3)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 3");
                        switch (GameDetails.player3team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage3.SetActive(false);
                                FourPlayerHeister3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister3.SetActive(false);
                                FourPlayerHostage3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player4.controllerNumber == 3)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 3");
                        switch (GameDetails.player4team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage4.SetActive(false);
                                FourPlayerHeister4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister4.SetActive(false);
                                FourPlayerHostage4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    #endregion 4PlayerController3TeamSelect

                    #region 4PlayerController4TeamSelect

                    if (GameDetails.player1.controllerNumber == 4)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 4");
                        switch (GameDetails.player1team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage1.SetActive(false);
                                FourPlayerHeister1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister1.SetActive(false);
                                FourPlayerHostage1.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer1.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player1.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player2.controllerNumber == 3)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 4");
                        switch (GameDetails.player2team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage2.SetActive(false);
                                FourPlayerHeister2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister2.SetActive(false);
                                FourPlayerHostage2.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer2.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player2.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }

                    if (GameDetails.player3.controllerNumber == 4)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 4");
                        switch (GameDetails.player3team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage3.SetActive(false);
                                FourPlayerHeister3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Heisters.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Heister;
                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister3.SetActive(false);
                                FourPlayerHostage3.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer3.SetActive(true);
                                        Hostages.Add(0);
                                        GameDetails.player3.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player3team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }
                    if (GameDetails.player4.controllerNumber == 3)
                    {
                        float horizontal = Input.GetAxisRaw("Horizontal Controller 4");
                        switch (GameDetails.player4team)
                        {
                            case (GameDetails.PlayerTeam.Heister):
                                FourPlayerHostage4.SetActive(false);
                                FourPlayerHeister4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                                {
                                    if (Heisters.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Heisters.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Heister;

                                    }
                                }
                                if (horizontal > 0.1)
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Hostage;
                                }

                                break;
                            case (GameDetails.PlayerTeam.Hostage):
                                FourPlayerHeister4.SetActive(false);
                                FourPlayerHostage4.SetActive(true);
                                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                                {
                                    if (Hostages.Count < GameDetails.Players / 2)
                                    {
                                        FourPlayerConfirmPlayer4.SetActive(true);
                                        Hostages.Add(1);
                                        GameDetails.player4.team = PlayerStats.PlayerTeam.Hostage;
                                    }
                                }
                                if (horizontal < -0.1)
                                {
                                    GameDetails.player4team = GameDetails.PlayerTeam.Heister;
                                }

                                break;
                        }
                    }

                    #endregion 4PlayerController4TeamSelect

                    break;
            }


        }
        if (GameDetails.Players > 0 && Mb.settings == MenuButtons.Settings.TeamSelect)
        {
            if (Heisters.Count + Hostages.Count == GameDetails.Players)
            {
                TeamSelector.SetActive(false);
                Cs.characterSelect.SetActive(true);

                if (GameDetails.player1.team == PlayerStats.PlayerTeam.Heister)
                {
                    GameDetails.player1.character = PlayerStats.PlayerCharacter.Balanced;
                    Cs.mastermindHighlight1.SetActive(true);
                }
                if (GameDetails.player2.team == PlayerStats.PlayerTeam.Heister)
                {
                    Cs.mastermindHighlight2.SetActive(true);
                    GameDetails.player2.character = PlayerStats.PlayerCharacter.Balanced;
                }
                Loading = true;
            }
        }
        
    }
}
