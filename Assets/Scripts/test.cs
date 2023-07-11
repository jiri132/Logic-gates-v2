using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WrongWayToPauseLoop());
        StartCoroutine(CorrectWayToPauseLoop());
    }
    // Update is called once per frame
    IEnumerator WrongWayToPauseLoop()
    {
        print("Start");
        int index = 0;
        while (index <= 20)
        {
            //This will not stop while loop or for loop
            yield return null;
            print("WrongWay Index= " + index);
            index++;
        }
        print("End");
    }

    IEnumerator CorrectWayToPauseLoop()
    {
        print("Start");
        int index = 0;
        while (index <= 20)
        {
            //Hold the coroutine loop until space button is clicked
            yield return WaitUntilTrue(IsSpaceKeyPressed());
            print("CorrectWay Index= " + index);
            index++;
        }
        print("End");
    }
    bool IsSpaceKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public IEnumerator WaitUntilTrue(bool checkMethod)
    {
        while (checkMethod == false)
        {
            yield return null;
        }
    }
}
