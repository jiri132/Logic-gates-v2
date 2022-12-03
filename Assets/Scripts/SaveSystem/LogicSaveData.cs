using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;


public class LogicSaveData
{
    public string gateName;
	public Color gateColor;
	public Color gateNameColor;



    //all gates used ias components in the new gate
    public LogicComponent[] Gates;

    public LogicSaveData()
    {

    }
	public LogicSaveData(ChipEditor chipEditor)
	{
		List<Chip> componentChipList = new List<Chip>();

		var sortedInputs = chipEditor.inputsEditor.signals;
		sortedInputs.Sort((a, b) => b.transform.position.y.CompareTo(a.transform.position.y));
		var sortedOutputs = chipEditor.outputsEditor.signals;
		sortedOutputs.Sort((a, b) => b.transform.position.y.CompareTo(a.transform.position.y));

		componentChipList.AddRange(sortedInputs);
		componentChipList.AddRange(sortedOutputs);

		componentChipList.AddRange(chipEditor.chipInteraction.allChips);
		componentChips = componentChipList.ToArray();

		//wires = chipEditor.pinAndWireInteraction.allWires.ToArray();
		chipName = chipEditor.chipName;
		chipColour = chipEditor.chipColour;
		chipNameColour = chipEditor.chipNameColour;
		creationIndex = chipEditor.creationIndex;
	}

	public int ComponentChipIndex(LogicComponent componentChip)
	{
		return System.Array.IndexOf(Gates, componentChip);
	}
}
