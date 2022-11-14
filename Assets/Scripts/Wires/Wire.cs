using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Logic.Nodes;

public class Wire : MonoBehaviour
{
    [SerializeField]private LineRenderer lr;
    public Material wireMaterial;

    private bool _state;
    public bool state
    {
        get { return _state; }
        set
        {
            if (value == _state) { return; }

            _state = value;

            if (_state == true) { UpdateUI(LogicSettings.Instance.onColor); }
            else if (_state == false) { UpdateUI(LogicSettings.Instance.offColor); }
        }
    }

    public Node InputNode;
    public Node OutputNode;

    private Vector2 mousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void UpdateUI(Color c)
    {
        lr.SetColors(c, c);
    }

    private void Start()
    {

        lr = this.GetComponent<LineRenderer>();
        lr.material = wireMaterial;

        lr.SetPosition(0, OutputNode.transform.position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

        }
        


        if (InputNode == null)
        {
            lr.SetPosition(lr.positionCount, mousePos());
        }
    }
}
