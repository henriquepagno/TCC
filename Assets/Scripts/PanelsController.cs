using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelsController : MonoBehaviour {

    public GameObject gameController;
    LevelController lvl;

    Color selectedColor;
    Color normalColor;

    #region Constantes
    public const string commandPanel = "CommandPanel";
    public const string loopPanel = "LoopPanel";
    public const string untilPanel = "UntilPanel";
    public const string procPanel = "ProcedurePanel";
    #endregion

    // Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController");
        lvl = (LevelController)gameController.GetComponent("LevelController");

        selectedColor = new Color32(255, 178, 178, 90);
        normalColor = new Color32(255, 255, 255, 90);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CmdPanelClick()
    {
        TrataPaineis(commandPanel);
        lvl.SelectedPanel = commandPanel;
    }

    public void ProcPanelClick()
    {
        TrataPaineis(procPanel);
        lvl.SelectedPanel = procPanel;
    }

    public void LoopPanelClick()
    {
        TrataPaineis(loopPanel);
        lvl.SelectedPanel = loopPanel;
    }

    public void UntilPanelClick()
    {
        TrataPaineis(untilPanel);
        lvl.SelectedPanel = untilPanel;
    }

    private void TrataPaineis(string painelSelecionado)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Panel");

        foreach (GameObject obj in objects)
        {
            Image img = obj.GetComponent<Image>();
            if (obj.name.Equals(painelSelecionado))
                img.color = selectedColor;
            else
                img.color = normalColor;
        }
    }
}
