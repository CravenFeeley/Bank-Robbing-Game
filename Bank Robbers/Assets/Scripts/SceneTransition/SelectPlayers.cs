using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectPlayers : MonoBehaviour
{

    public MenuButtons Mb;

    public GameObject TwoPlayerPanel;
    public GameObject FourPlayerPanel;

    public List<int> ControllerNumber = new List<int>();

    public GameObject ReadyPlayer1;
    public GameObject ReadyPlayer2;

    public GameObject FourPlayerReadyPlayer1;
    public GameObject FourPlayerReadyPlayer2;
    public GameObject FourPlayerReadyPlayer3;
    public GameObject FourPlayerReadyPlayer4;

    public bool Loading;
    public float LoadingTime;


    // Start is called before the first frame update
    void Start()
    {
        Mb = GameObject.Find("LevelLoader").GetComponent<MenuButtons>();
        GameDetails.player1.playerNumber = 1;
        GameDetails.player2.playerNumber = 2;
        GameDetails.player3.playerNumber = 3;
        GameDetails.player4.playerNumber = 4;
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
                Mb.settings = MenuButtons.Settings.TeamSelect;
            }

        }


        if (Mb.settings == MenuButtons.Settings.SelectPlayers)
        {
            switch (GameDetails.Players)
            {
                #region 2playerselect
                case 2:
                    TwoPlayerPanel.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (ControllerNumber.Contains(0))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(0);
                            if (0 == ControllerNumber[0])
                            {
                                ReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 0;
                            }
                            if (0 == ControllerNumber[1])
                            {
                                ReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 0;
                            }
                        }

                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                    {
                        if (ControllerNumber.Contains(1))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(1);
                            if (1 == ControllerNumber[0])
                            {
                                ReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 1;
                            }
                            if (1 == ControllerNumber[1])
                            {
                                ReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 1;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                    {
                        if (ControllerNumber.Contains(2))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(2);
                            if (2 == ControllerNumber[0])
                            {
                                ReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 2;
                            }
                            if (2 == ControllerNumber[1])
                            {
                                ReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 2;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                    {
                        if (ControllerNumber.Contains(3))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(3);
                            if (3 == ControllerNumber[0])
                            {
                                ReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 3;
                            }
                            if (3 == ControllerNumber[1])
                            {
                                ReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 3;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                    {
                        if (ControllerNumber.Contains(4))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(4);
                            if (4 == ControllerNumber[0])
                            {
                                ReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 4;
                            }
                            if (4 == ControllerNumber[1])
                            {
                                ReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 4;
                            }
                        }
                    }

                    if (ControllerNumber.Count == 2)
                    {
                        ReadyPlayer1.SetActive(false);
                        ReadyPlayer2.SetActive(false);
                        GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                        GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                        Loading = true;
                        
                    }

                    break;
                #endregion 2player


                #region 4playerselect
                case 4:
                    FourPlayerPanel.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (ControllerNumber.Contains(0))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(0);
                            if (0 == ControllerNumber[0])
                            {
                                FourPlayerReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 0;
                            }
                            if (0 == ControllerNumber[1])
                            {
                                FourPlayerReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 0;
                            }
                            if (0 == ControllerNumber[2])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player3.controllerNumber = 0;
                            }
                            if (0 == ControllerNumber[3])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player4.controllerNumber = 0;
                            }
                        }

                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                    {
                        if (ControllerNumber.Contains(1))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(1);
                            if (1 == ControllerNumber[0])
                            {
                                FourPlayerReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 1;
                            }
                            if (1 == ControllerNumber[1])
                            {
                                FourPlayerReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 1;
                            }
                            if (1 == ControllerNumber[2])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player3.controllerNumber = 1;
                            }
                            if (1 == ControllerNumber[3])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player4.controllerNumber = 1;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                    {
                        if (ControllerNumber.Contains(2))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(2);
                            if (2 == ControllerNumber[0])
                            {
                                FourPlayerReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 2;
                            }
                            if (2 == ControllerNumber[1])
                            {
                                FourPlayerReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 2;
                            }
                            if (2 == ControllerNumber[2])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player3.controllerNumber = 2;
                            }
                            if (2 == ControllerNumber[3])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player4.controllerNumber = 2;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                    {
                        if (ControllerNumber.Contains(3))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(3);
                            if (3 == ControllerNumber[0])
                            {
                                FourPlayerReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 3;
                            }
                            if (3 == ControllerNumber[1])
                            {
                                FourPlayerReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 3;
                            }
                            if (3 == ControllerNumber[2])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player3.controllerNumber = 3;
                            }
                            if (3 == ControllerNumber[3])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player4.controllerNumber = 3;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                    {
                        if (ControllerNumber.Contains(4))
                        {

                        }
                        else
                        {
                            ControllerNumber.Add(4);
                            if (4 == ControllerNumber[0])
                            {
                                FourPlayerReadyPlayer1.SetActive(true);
                                GameDetails.player1.controllerNumber = 4;
                            }
                            if (0 == ControllerNumber[1])
                            {
                                FourPlayerReadyPlayer2.SetActive(true);
                                GameDetails.player2.controllerNumber = 4;
                            }
                            if (0 == ControllerNumber[2])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player3.controllerNumber = 4;
                            }
                            if (0 == ControllerNumber[3])
                            {
                                FourPlayerReadyPlayer3.SetActive(true);
                                GameDetails.player4.controllerNumber = 4;
                            }

                        }
                    }
                    break;
            }

            if (ControllerNumber.Count == 4)
            {
                FourPlayerReadyPlayer1.SetActive(false);
                FourPlayerReadyPlayer2.SetActive(false);
                FourPlayerReadyPlayer3.SetActive(false);
                FourPlayerReadyPlayer4.SetActive(false);
                GameDetails.player1team = GameDetails.PlayerTeam.Heister;
                GameDetails.player2team = GameDetails.PlayerTeam.Heister;
                GameDetails.player3team = GameDetails.PlayerTeam.Heister;
                GameDetails.player4team = GameDetails.PlayerTeam.Heister;
                Loading = true;
            }

            #endregion 4playerselect


        }
    }
}
