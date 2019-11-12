using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public const string lvl1 = "Level1";
    public const string lvl2 = "Level2";
    public const string lvl3 = "Level3";
    public const string lvl4 = "Level4";
    private const int cols = 3;

    #region MatrizesLvl1
    private Position[,] gameMatLvl1_0 = new Position[8, cols] {{new Position(0),new Position(0),new Position(1,true)},
                                                               {new Position(0),new Position(0),new Position(2)},
                                                               {new Position(1),new Position(1),new Position(1)},
                                                               {new Position(1),new Position(0),new Position(0)},
                                                               {new Position(1),new Position(0),new Position(0)},
                                                               {new Position(1),new Position(0),new Position(0)},
                                                               {new Position(1),new Position(0),new Position(0)},
                                                               {new Position(1),new Position(1),new Position(0)}
                                                              };

    private Position[,] gameMatLvl1_1 = new Position[6, cols] {{new Position(1),new Position(1),new Position(1,true)},
                                                               {new Position(2),new Position(0),new Position(0)},
                                                               {new Position(1),new Position(0),new Position(0)},
                                                               {new Position(1),new Position(1),new Position(0)},
                                                               {new Position(0),new Position(1),new Position(0)},
                                                               {new Position(0),new Position(1),new Position(0)}
                                                              };

    private Position[,] gameMatLvl1_2 = new Position[8, cols] {{new Position(1),new Position(1,true),new Position(0)},
                                                               {new Position(1),new Position(0)     ,new Position(0)},
                                                               {new Position(1),new Position(1)     ,new Position(1)},
                                                               {new Position(0),new Position(0)     ,new Position(1)},
                                                               {new Position(0),new Position(0)     ,new Position(1)},
                                                               {new Position(0),new Position(1)     ,new Position(1)},
                                                               {new Position(0),new Position(2)     ,new Position(0)},
                                                               {new Position(0),new Position(1)     ,new Position(0)}
                                                              };

    private Position[,] gameMatLvl1;
    #endregion

    #region MatrizesLvl2
    private Position[,] gameMatLvl2_0 = new Position[10, cols] {{new Position(1,true),new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(1),new Position(1)},
                                                                {new Position(0)     ,new Position(0),new Position(1)},
                                                                {new Position(0)     ,new Position(0),new Position(2)},
                                                                {new Position(1)     ,new Position(1),new Position(1)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(1),new Position(0)}
                                                               };

    private Position[,] gameMatLvl2_1 = new Position[8, cols] {{new Position(1,true),new Position(1),new Position(1)},
                                                               {new Position(0)     ,new Position(0),new Position(2)},
                                                               {new Position(1)     ,new Position(1),new Position(1)},
                                                               {new Position(1)     ,new Position(0),new Position(0)},
                                                               {new Position(1)     ,new Position(0),new Position(0)},
                                                               {new Position(1)     ,new Position(0),new Position(0)},
                                                               {new Position(1)     ,new Position(0),new Position(0)},
                                                               {new Position(1)     ,new Position(1),new Position(0)}
                                                              };

    private Position[,] gameMatLvl2_2 = new Position[12, cols] {{new Position(0),new Position(1),new Position(1,true)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(1)},
                                                                {new Position(0),new Position(0),new Position(2)},
                                                                {new Position(0),new Position(1),new Position(1)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)}
                                                               };

    private Position[,] gameMatLvl2;
    #endregion

    #region MatrizesLvl3
    private Position[,] gameMatLvl3_0 = new Position[7, cols] {{new Position(1,true),new Position(1),new Position(1)},
                                                               {new Position(0)     ,new Position(0),new Position(1)},
                                                               {new Position(1)     ,new Position(1),new Position(1)},
                                                               {new Position(1)     ,new Position(0),new Position(0)},
                                                               {new Position(1)     ,new Position(1),new Position(1)},
                                                               {new Position(0)     ,new Position(0),new Position(1)},
                                                               {new Position(0)     ,new Position(1),new Position(1)}
                                                              };

    private Position[,] gameMatLvl3_1 = new Position[11, cols] {{new Position(1,true),new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(1),new Position(1)},
                                                                {new Position(0)     ,new Position(0),new Position(2)},
                                                                {new Position(0)     ,new Position(1),new Position(1)},
                                                                {new Position(1)     ,new Position(1),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(1),new Position(0)},
                                                                {new Position(0)     ,new Position(1),new Position(0)}
                                                               };

    private Position[,] gameMatLvl3_2 = new Position[8, cols] {{new Position(1),new Position(1),new Position(1,true)},
                                                               {new Position(1),new Position(0),new Position(0)},
                                                               {new Position(1),new Position(0),new Position(0)},
                                                               {new Position(2),new Position(0),new Position(0)},
                                                               {new Position(1),new Position(1),new Position(1)},
                                                               {new Position(0),new Position(0),new Position(1)},
                                                               {new Position(0),new Position(0),new Position(2)},
                                                               {new Position(0),new Position(1),new Position(1)}
                                                              };

    private Position[,] gameMatLvl3;
    #endregion

    #region MatrizesLvl4
    private Position[,] gameMatLvl4_0 = new Position[15, cols] {{new Position(1,true),new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(2)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(1),new Position(1)},
                                                                {new Position(0)     ,new Position(0),new Position(2)},
                                                                {new Position(1)     ,new Position(1),new Position(1)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(0),new Position(0)},
                                                                {new Position(1)     ,new Position(1),new Position(0)}
                                                               };

    private Position[,] gameMatLvl4_1 = new Position[12, cols] {{new Position(1),new Position(1),new Position(1,true)},
                                                                {new Position(1),new Position(0),new Position(0)},
                                                                {new Position(1),new Position(0),new Position(0)},
                                                                {new Position(1),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(2),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(2),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)},
                                                                {new Position(0),new Position(2),new Position(0)},
                                                                {new Position(0),new Position(1),new Position(0)}
                                                               };

    private Position[,] gameMatLvl4_2 = new Position[12, cols] {{new Position(1,true),new Position(0),new Position(0)},
                                                                {new Position(1),new Position(0),new Position(0)},
                                                                {new Position(1),new Position(2),new Position(1)},
                                                                {new Position(0),new Position(0),new Position(1)},
                                                                {new Position(0),new Position(0),new Position(1)},
                                                                {new Position(0),new Position(0),new Position(1)},
                                                                {new Position(1),new Position(1),new Position(1)},
                                                                {new Position(2),new Position(0),new Position(0)},
                                                                {new Position(1),new Position(1),new Position(1)},
                                                                {new Position(0),new Position(0),new Position(2)},
                                                                {new Position(0),new Position(1),new Position(1)},
                                                                {new Position(0),new Position(1),new Position(0)}
                                                               };

    private Position[,] gameMatLvl4;
    #endregion

    #region Vetores
    private char[] gameVetLvl1 = new char[10];
    private char[] gameVetProcLvl1 = new char[4];

    private char[] gameVetLvl2 = new char[10];
    private char[] gameVetProcLvl2 = new char[4];

    private char[] gameVetLvl3 = new char[10];
    private char[] gameVetProcLvl3 = new char[4];

    private char[] gameVetLvl4 = new char[10];
    private char[] gameVetProcLvl4 = new char[4];
    #endregion

    //Variáveis para controlar a posição máxima e mínima da câmera no cenário
    private float maxCamPosUp;
    private float maxCamPosDown;

    //Variáveis para controlar a posição da matriz onde o personagem se encontra
    private int posPlayerX;
    private int posPlayerY;

    //Variáveis para controlar a posição da matriz inicial do personagem
    private int posIniPlayerX;
    private int posIniPlayerY;

    //Variável para controlar o índice do vetor de comandos
    private int indiceVetor = 0;

    //Variável para controlar o índice do vetor do procedimento
    private int indiceVetorProc = 0;

    //Controla qual é o painel selecionado para adicionar/excluir comandos
    private string selectedPanel;

    //Comando do loop
    private char cmdLoop;
    //Comando que controla a parada do loop
    private char cmdUntilLoop;

    private void Awake()
    {
        //Pega a matriz de jogo do nível atual
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals(lvl1, System.StringComparison.Ordinal))
        {
            int randNum = Random.Range(0, 3);
            if (randNum == 0)
                gameMatLvl1 = gameMatLvl1_0;
            else if (randNum == 1)
                gameMatLvl1 = gameMatLvl1_1;
            else if (randNum == 2)
                gameMatLvl1 = gameMatLvl1_2;
        }
        else if (scene.name.Equals(lvl2, System.StringComparison.Ordinal))
        {
            int randNum = Random.Range(0, 3);
            if (randNum == 0)
                gameMatLvl2 = gameMatLvl2_0;
            else if (randNum == 1)
                gameMatLvl2 = gameMatLvl2_1;
            else if (randNum == 2)
                gameMatLvl2 = gameMatLvl2_2;
        }
        else if (scene.name.Equals(lvl3, System.StringComparison.Ordinal))
        {
            int randNum = Random.Range(0, 3);
            if (randNum == 0)
                gameMatLvl3 = gameMatLvl3_0;
            else if (randNum == 1)
                gameMatLvl3 = gameMatLvl3_1;
            else if (randNum == 2)
                gameMatLvl3 = gameMatLvl3_2;
        }
        else if (scene.name.Equals(lvl4, System.StringComparison.Ordinal))
        {
            int randNum = Random.Range(0, 3);
            if (randNum == 0)
                gameMatLvl4 = gameMatLvl4_0;
            else if (randNum == 1)
                gameMatLvl4 = gameMatLvl4_1;
            else if (randNum == 2)
                gameMatLvl4 = gameMatLvl4_2;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public Position[,] GameMatLvl1
    {
        get { return gameMatLvl1; }
        set { gameMatLvl1 = value; }
    }

    public Position[,] GameMatLvl2
    {
        get { return gameMatLvl2; }
        set { gameMatLvl2 = value; }
    }

    public Position[,] GameMatLvl3
    {
        get { return gameMatLvl3; }
        set { gameMatLvl3 = value; }
    }

    public Position[,] GameMatLvl4
    {
        get { return gameMatLvl4; }
        set { gameMatLvl4 = value; }
    }

    public Position[,] GetGameMat(string lvl)
    {
        if (lvl.Equals(lvl1, System.StringComparison.Ordinal))
            return GameMatLvl1;
        else if (lvl.Equals(lvl2, System.StringComparison.Ordinal))
            return GameMatLvl2;
        else if (lvl.Equals(lvl3, System.StringComparison.Ordinal))
            return GameMatLvl3;
        else if (lvl.Equals(lvl4, System.StringComparison.Ordinal))
            return GameMatLvl4;

        return null;
    }

    public char[] GetGameVet(string lvl)
    {
        if (lvl.Equals(lvl1, System.StringComparison.Ordinal))
            return gameVetLvl1;
        else if (lvl.Equals(lvl2, System.StringComparison.Ordinal))
            return gameVetLvl2;
        else if (lvl.Equals(lvl3, System.StringComparison.Ordinal))
            return gameVetLvl3;
        else if (lvl.Equals(lvl4, System.StringComparison.Ordinal))
            return gameVetLvl4;

        return null;
    }

    public float MaxCamPosUp
    {
        get { return maxCamPosUp; }
        set { maxCamPosUp = value; }
    }

    public float MaxCamPosDown
    {
        get { return maxCamPosDown; }
        set { maxCamPosDown = value; }
    }

    public int PosPlayerX
    {
        get { return posPlayerX; }
        set { posPlayerX = value; }
    }

    public int PosPlayerY
    {
        get { return posPlayerY; }
        set { posPlayerY = value; }
    }

    public void atualizaPosPlayer(int x, int y)
    {
        this.PosPlayerX = x;
        this.PosPlayerY = y;
    }

    public int PosIniPlayerX
    {
        get { return posIniPlayerX; }
        set { posIniPlayerX = value; }
    }

    public int PosIniPlayerY
    {
        get { return posIniPlayerY; }
        set { posIniPlayerY = value; }
    }

    public void setaPorIniPlayer(int x, int y)
    {
        this.posIniPlayerX = x;
        this.posIniPlayerY = y;
    }

    public int IndiceVetor
    {
        get { return indiceVetor; }
        set { indiceVetor = value; }
    }

    public int IndiceVetorProc
    {
        get
        {
            return indiceVetorProc;
        }

        set
        {
            indiceVetorProc = value;
        }
    }

    public string SelectedPanel
    {
        get { return selectedPanel; }
        set { selectedPanel = value; }
    }

    public char CmdLoop
    {
        get { return cmdLoop; }
        set { cmdLoop = value; }
    }

    public char CmdUntilLoop
    {
        get { return cmdUntilLoop; }
        set { cmdUntilLoop = value; }
    }

    public char[] GetGameProcVet(string lvl)
    {
        if (lvl.Equals(lvl1, System.StringComparison.Ordinal))
            return gameVetProcLvl1;
        else if (lvl.Equals(lvl2, System.StringComparison.Ordinal))
            return gameVetProcLvl2;
        else if (lvl.Equals(lvl3, System.StringComparison.Ordinal))
            return gameVetProcLvl3;
        else if (lvl.Equals(lvl4, System.StringComparison.Ordinal))
            return gameVetProcLvl4;

        return null;
    }
}
