using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCreator : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Create();
    }

    // Start is called before the first frame update
    void Start()
    {
#if DEBUG_MODE
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
#else
        GFunc.LoadScene(GData.SCENE_NAME_TITLE);
#endif      // DEBUG_MODE
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
