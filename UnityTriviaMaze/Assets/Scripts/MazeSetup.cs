using UnityEngine;
using System.Collections;
using TriviaMaze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class MazeSetup : MonoBehaviour 
{

    private const int _size = 3;
    private Maze maze;

    public Transform prefabDoor;
    public Transform prefabFloor;

	// Use this for initialization
	void Start () 
    {
	        Driver driver;

            
            QuestionFactory qs = new QuestionFactory();
            DoorFactory df;
            MazeFactory mf;

            string str;

            bool play = true;

            while (play)
            {
                qs.CreateList();
                df = new DoorFactory(qs.getQuestions());
                mf = new MazeFactory(prefabFloor);

                driver = new Driver(0, 0, _size - 1, _size - 1, _size); //coords for start room and then end room

                Door[,] hDoors = df.makeHDoors(_size);
                Door[,] vDoors = df.makeVDoors(_size);

                setUpFloors();
                setUpDoors(hDoors, 90, 20, 10);
                setUpDoors(vDoors, 0, 10, 20);

                maze = mf.makeMaze(_size, hDoors, vDoors);
                //if (isLoaded)
                //    loadGame(driver);
                //else
                //driver.enterMaze(mf.makeMaze(_size, hDoors, vDoors));

                //Console.WriteLine("Would you like to play again?(Y/N)");
                //str = Console.ReadLine().ToUpper();

               // if (str.Equals("N"))
                    play = false;
            }
	}

    public Maze getMaze()
    {
        if (maze != null)
            return maze;
        else
            return null;
    }

    private void setUpDoors(Door[,] doors, float degrees, int xSpacing, int ySpacing)
    {
        for(int i = 0; i < doors.GetLength(0); i++)
            for (int j = 0; j < doors.GetLength(1); j++)
            {
                Transform door = Instantiate(prefabDoor, new Vector3(i*20 + xSpacing, prefabDoor.localScale.y/2, j*20 + ySpacing), Quaternion.Euler(0, degrees, 0)) as Transform;
                door.GetComponent<DoorHolder>().setDoor(doors[i,j]);
            }

        
    }

    private void setUpFloors()
    {
        for (int i = 0; i < _size; i++)
        {
            for(int j = 0; j < _size; j++)
            {
                Transform floor= Instantiate(prefabFloor, new Vector3(i * 20 + 10, 0, j * 20 + 10), Quaternion.identity) as Transform;    
            }
        }
    }

	// Update is called once per frame
	void Update () 
    {
	
	}
}
