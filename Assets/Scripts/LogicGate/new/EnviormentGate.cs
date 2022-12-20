using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic.Nodes;

namespace Logic
{
    public class EnviormentGate : LogicComponent
    {
        [Header("Spawning IO")]
        public Transform ParentInput;
            public Transform ParentOutput;
        public GameObject CustomInput;
            public GameObject CustomOutput;


        [SerializeField] private List<Node> outputNodes = new List<Node>();
        [SerializeField] private List<Node> inputNodes = new List<Node>();

        private Vector2 widthHeight;
        [SerializeField] private Vector2 playingField;

        private Vector2 mousePos()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }


        private void Start()
        {
            this.ID = GameManager.Instance.AllGates.Count;

            widthHeight = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
            playingField = Camera.main.ScreenToWorldPoint(widthHeight);
        }

        private bool InsideClampedY()
        {
            if (mousePos().y < playingField.y - 1 && mousePos().y > (playingField.y - 1) * -1)
            {
                return true;
            }

            return false;
        }
        private bool IsLeft()
        {
            if (mousePos().x > playingField.x * -1 && mousePos().x < (playingField.x - 1) * -1)
            {
                return true;
            }
            return false;
        }
        private bool IsRight()
        {
            if (mousePos().x < playingField.x && mousePos().x > playingField.x - 1)
            {
                return true;
            }
            return false;
        }


        private void Update()
        {
            if (!InsideClampedY()) { return; }


            if (Input.GetMouseButtonDown(0))
            {
                
                if (IsRight())
                {
                    //create outputs
                    Node output = Instantiate(CustomOutput, ParentOutput).GetComponentInChildren<Node>();
                    outputNodes.Add(output);
                    base.outputs = outputNodes.ToArray();
                    return;
                }
                if (IsLeft())
                {
                    //create inputs
                    Node input = Instantiate(CustomInput, ParentInput).GetComponentInChildren<Node>();
                    inputNodes.Add(input);
                    base.inputs = inputNodes.ToArray();
                    return;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (IsRight())
                {
                    Node lastnode = outputNodes[outputNodes.Count-1];
                    outputNodes.RemoveAt(outputNodes.Count-1);
                    //destroy the outputs
                    Destroy(lastnode.gameObject);

                    base.outputs = outputNodes.ToArray();

                    return;
                }
                if (IsLeft())
                {
                    Node lastnode = inputNodes[inputNodes.Count-1];
                    inputNodes.RemoveAt(inputNodes.Count-1);
                    //destroy the inputs
                    Destroy(lastnode.gameObject);

                    base.inputs = inputNodes.ToArray();
                    return;
                }
            }
            
        }

    }
}

