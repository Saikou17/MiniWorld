using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliviaAnimation : MonoBehaviour
{
    Animator ac;
    // Start is called before the first frame update
    void Start()
    {
        ac = GameObject.Find("Ch11_nonPBR").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            ac.SetBool("Walking",true);
        }
    }
}
