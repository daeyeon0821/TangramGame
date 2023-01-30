using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //! Exit 버튼을 눌렀을 때 부를 함수
    public void OnExitButton()
    {
        GFunc.QuitThisGame();
    }       // OnExitButton()
}
