using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMainMenu : MonoBehaviour
{
     private string titlemenu = "TitleMenu";
    public void callMenu(){
         Application.LoadLevel(titlemenu);
    }
}
