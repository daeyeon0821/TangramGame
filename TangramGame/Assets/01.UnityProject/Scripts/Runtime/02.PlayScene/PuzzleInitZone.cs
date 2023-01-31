using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInitZone : MonoBehaviour
{
    public Canvas parentCanvas = default;

    // Start is called before the first frame update
    void Start()
    {
        GFunc.Assert(parentCanvas != null || parentCanvas != default);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
