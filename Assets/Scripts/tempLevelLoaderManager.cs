using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempLevelLoaderManager : MonoBehaviour
{   private string level1 = "hills";
private string level2 = "forest";
private string level3 = "dungeon";
private string menu = "TitleMenu";

    public void levelOne(){
         Application.LoadLevel(level1);
    }
    public void levelTwo(){
        Application.LoadLevel(level2);
    }
    public void levelThree(){
        Application.LoadLevel(level3);
    }
    public void mainMenu(){
        Application.LoadLevel(menu);
    }
}
