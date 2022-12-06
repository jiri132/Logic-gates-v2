using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Logic;
using Logic.Nodes;

public class DragAndDrop<T> : MonoBehaviour where T : LogicComponent
{
    public bool isDragging = false;

    private T obj;

    private Vector2 mousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (isDragging == false) { isDragging = true; } 
        else { isDragging = false; }
    }

    private void Update()
    {
        if (obj == null) { obj = this as T; return; }

        if (isDragging == false) { return; }

        if (Input.GetKeyDown(KeyCode.Delete)) { Destroy(obj); }

        this.transform.position = mousePos();
        
        foreach (Node node in obj.outputs)
        {
            node.UpdateWirePositions();
        }
        foreach (Node node in obj.inputs)
        {
            node.UpdateWirePositions();
        }
    }

}
