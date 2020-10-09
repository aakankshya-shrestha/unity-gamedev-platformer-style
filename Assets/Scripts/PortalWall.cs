using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalWall : MonoBehaviour
{
    public bool unlocked;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<BossHealthManager>()){
            return;
        }
        
        Destroy(gameObject);
        
    }
}
