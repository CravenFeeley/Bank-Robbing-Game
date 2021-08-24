using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotationScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion stayStill;
    void Start()
    {
        stayStill = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.rotation = stayStill;
    }
}
