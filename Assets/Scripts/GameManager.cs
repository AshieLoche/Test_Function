using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cube.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            cube.gameObject.SetActive(true);
        }
    }
}
