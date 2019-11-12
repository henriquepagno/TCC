using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTutorialController : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void IniciaPanel(string panelName)
    {
        //Instancia o painel de fim do level
        GameObject uiCanvas = GameObject.Find("UICanvas");
        //GameObject painel = (GameObject)Instantiate(Resources.Load("Prefabs/" + panelName), uiCanvas.transform);
        Instantiate(Resources.Load("Prefabs/" + panelName), uiCanvas.transform);
    }

    void FechaPanel(string panelName)
    {
        GameObject uiCanvas = GameObject.Find("UICanvas");

        Transform[] trs = uiCanvas.GetComponentsInChildren<RectTransform>(true);
        foreach (RectTransform t in trs)
            if (t.name.Equals(panelName, System.StringComparison.Ordinal))
                Destroy(t.gameObject);
                
    }
    
    public void ContinuePanel1(string panelName)
    {
        FechaPanel("PanelTutorial1");
        IniciaPanel("PanelTutorial2");
    }

    public void ContinuePainel2(string panelName)
    {
        FechaPanel("PanelTutorial2(Clone)");
        IniciaPanel("PanelTutorial3");
    }

    public void ContinuePainel3(string panelName)
    {
        FechaPanel("PanelTutorial3(Clone)");
        IniciaPanel("PanelTutorial4");
    }

    public void ContinuePainel4(string panelName)
    {
        FechaPanel("PanelTutorial4(Clone)");
    }

    public void ContinuePanel()
    {
        FechaPanel("PanelTutorial");
    }
}