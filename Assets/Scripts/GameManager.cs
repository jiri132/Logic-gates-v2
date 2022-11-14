using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;
using Extentions.singleton

public class GameManager : MonoBehaviour
{

    #region Singleton
    //TODO: Make it with the extention of singleton<T>
    public static singleton<GameManager> Instance = new singleton<GameManager>;
    /*
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }else
        {
            Destroy(this);
        }
    }
    */
    #endregion
    public LogicComponent x;
    public LogicComponent y;

    public Wire selectedWire;

    // Start is called before the first frame update
    void Start()
    {
        //output 1 to input 1 
        /*x.bridge.links[0].CreateRelation(y, 0);
        //output 1 to input 2
        x.bridge.links[0].CreateRelation(y, 1);
        //output 1 to input 1
        y.bridge.links[0].CreateRelation(x, 0);*/

        //x.bridge.links[0].CreateRelation(x, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
