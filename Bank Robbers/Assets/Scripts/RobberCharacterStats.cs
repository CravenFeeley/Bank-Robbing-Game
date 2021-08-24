using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberCharacterStats: MonoBehaviour
{
    public string characterName;
    public float baseSpeed;
    public float boostSpeed;

    public enum Class
    {
        Light,
        Balanced,
        Heavy
    }
    public Class characterClass;

}
