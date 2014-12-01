using UnityEngine;
using System.Collections;
using TriviaMaze;
using UnityEngine.UI;

public class Driver3D : MonoBehaviour 
{
    private Maze maze;
    private Text instruction;
    private bool useKey = false;

	// Use this for initialization
	void Start () 
    {
        maze = GameObject.FindGameObjectWithTag("Init").GetComponent<MazeSetup>().getMaze();

        instruction = GameObject.FindGameObjectWithTag("Prompt").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown("Use"))
            useKey = !useKey;


	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            instruction.text = "Press E to Ask Question";
        }
            
    }

    public void OnTriggerStay(Collider other)
    {
        if (useKey)
        {
            if (other.tag == "Door")
            {
                other.GetComponent<DoorHolder>().knock();
            }

            useKey = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            instruction.text = "";
        }
    }
}
