using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{

    public GameObject Character;
    public enum PlayerTeam
    {
        Hostage,
        Heister
    }
    public PlayerTeam team;

    public enum PlayerCharacter
    {
        Hostage,
        Balanced,
        Light,
        Heavy,

    }

    public PlayerCharacter character;

    public int controllerNumber;
    public int playerNumber;

}
