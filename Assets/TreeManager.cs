using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class TreeManager : MonoBehaviour
{
    CustomTree t;
    // Start is called before the first frame update
    void Start()
    {
        t = new CustomTree();
        t.insert("home/sport/futbol/worldcup/");
        t.insert("home/sport/football/");
        t.insert("home/music/metal/iron maiden/");
        t.insertDual("/home/sports/futbol/worldcup/Brazil|America");
        t.insertCombinational("/home/sports/futbol/worldcup/Brazil|America|Japan");
        // /home/sports|music/misc|favorites
        
        List<string> paths = t.getPaths();

        foreach (string item in paths)
        {
            Debug.Log("Saved paths: " + item);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
