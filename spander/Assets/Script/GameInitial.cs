using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitial : MonoBehaviour
{
    
        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            Screen.SetResolution(1365, 768, false, 60);

        }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
