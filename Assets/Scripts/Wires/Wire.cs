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

    private bool isSelectedWire() => GameManager.Instance.selectedWire == this;

    private Vector2 mousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void UpdateUI(Color c)
    {
        lr.SetColors(c, c);
    }

    public void SetPosition(int index, Vector2 pos) => lr.SetPosition(index,pos);
    public int GetPositionCount() => lr.positionCount;

    private void Start()
    {

        lr = this.GetComponent<LineRenderer>();
        lr.material = wireMaterial;

        lr.SetPosition(0, OutputNode.transform.position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isSelectedWire())
        {
            List<Vector3> positions = new List<Vector3>();

            for (int i = 0; i < lr.positionCount; i++)
            {
                positions.Add(lr.GetPosition(i));
            }

            positions.Add(mousePos());

            lr.SetPositions(positions.ToArray());
            lr.SetVertexCount(positions.Count);
        }
        
        /*if (Input.GetMouseButtonDown(0) && isSelectedWire())
        {
            GameManager.Instance.selectedWire = null;
            OutputNode.Wires.RemoveAt(OutputNode.Wires.IndexOf(this));
            Destroy(this.gameObject);
        }*/

        if (InputNode == null)
        {
            lr.SetPosition(lr.positionCount-1, mousePos());
        }
    }
}
