using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PosicionaTiles : MonoBehaviour {

    public GameObject tile;
    public GameObject gameController;
    public GameObject player;
    public GameObject hole;

    public GameObject keyLvl1;
    public GameObject keyLvl2;
    public GameObject keyLvl3;
    public GameObject keyLvl4;

    LevelController lvl;
    Scene scene;

    // Use this for initialization
    void Start () {
        //Valor de offset para separar as tiles
        const float offset = 0.1f;
        const float camOffsetUp = 1f;
        //Altura da tile
        float tileHeight = tile.transform.localScale.x;
        //Altura da tela
        float height = Camera.main.orthographicSize;

        float tmpHeight = -height + (tileHeight / 2) + offset;

        //Seta a máxima posição para baixo/cima da tela, de forma a controlar o movimento da tela.
        lvl = (LevelController)gameController.GetComponent("LevelController");
        lvl.MaxCamPosDown = -height;
        lvl.MaxCamPosUp = height;

        //Pega a matriz de jogo do nível atual
        scene = SceneManager.GetActiveScene();

        //Busca a matriz de jogo conforme cada nível
        Position[,] gameMat = lvl.GetGameMat(scene.name);

        //Varre cada linha da matriz do jogo
        for (int i = gameMat.GetLength(0)-1; i >= 0; i--) // X
        {
            if (gameMat[i, 0].Tipo == Position.Tile || gameMat[i, 0].Tipo == Position.Buraco)
            {
                if (gameMat[i, 0].Tipo == Position.Tile)
                {
                    //Cria as tiles conforme a matriz
                    Instantiate(tile, new Vector3(-tileHeight - offset, tmpHeight, -1), Quaternion.identity);
                }
                else if (gameMat[i, 0].Tipo == Position.Buraco)
                {
                    //Cria os holes conforme a matriz
                    Instantiate(hole, new Vector3(-tileHeight - offset, tmpHeight, -1), Quaternion.identity);
                }

                //Atualiza dados da posição da matriz
                gameMat[i, 0].setaPos(-tileHeight - offset, tmpHeight);

                //Posiciona objeto se a posição for final
                PosicionaObjFimLevel(gameMat[i, 0].Final, -tileHeight - offset, tmpHeight);
            }
            if (gameMat[i, 1].Tipo == Position.Tile || gameMat[i, 1].Tipo == Position.Buraco)
            {
                if (gameMat[i, 1].Tipo == Position.Tile)
                {
                    //Cria as tiles conforme a matriz
                    Instantiate(tile, new Vector3(0, tmpHeight, -1), Quaternion.identity);
                }
                else if (gameMat[i, 1].Tipo == Position.Buraco)
                {
                    //Cria os holes conforme a matriz
                    Instantiate(hole, new Vector3(0, tmpHeight, -1), Quaternion.identity);
                }

                //Atualiza dados da posição da matriz
                gameMat[i, 1].setaPos(0, tmpHeight);

                //Posiciona objeto se a posição for final
                PosicionaObjFimLevel(gameMat[i, 1].Final, 0, tmpHeight);
            }
            if (gameMat[i, 2].Tipo == Position.Tile || gameMat[i, 2].Tipo == Position.Buraco)
            {
                if (gameMat[i, 2].Tipo == Position.Tile)
                {
                    //Cria as tiles conforme a matriz
                    Instantiate(tile, new Vector3(tileHeight + offset, tmpHeight, -1), Quaternion.identity);
                }
                else if (gameMat[i, 2].Tipo == Position.Buraco)
                {
                    //Cria os holes conforme a matriz
                    Instantiate(hole, new Vector3(tileHeight + offset, tmpHeight, -1), Quaternion.identity);
                }

                //Atualiza dados da posição da matriz
                gameMat[i, 2].setaPos(tileHeight + offset, tmpHeight);

                //Posiciona objeto se a posição for final
                PosicionaObjFimLevel(gameMat[i, 2].Final, tileHeight + offset, tmpHeight);
            }

            tmpHeight += tileHeight + offset;

            //Atualiza a máxima posição para cima da tela, de forma a controlar o movimento da tela.
            if (tmpHeight > lvl.MaxCamPosUp)
                lvl.MaxCamPosUp = tmpHeight - (tileHeight / 2 ) + camOffsetUp;
        }
        
        //Posiciona o jogador na primeira tile do jogo
        posicionaJogador(gameMat);
	}

    //Posiciona o jogador na primeira tile do jogo
    void posicionaJogador(Position[,] gameMat)
    {
        //Sempre a posição do meio
        int i = gameMat.GetLength(0) - 1;
        lvl.atualizaPosPlayer(i, 1);
        lvl.setaPorIniPlayer(i, 1);
        //Instancia o jogador
        Instantiate(player, new Vector3(gameMat[i, 1].PosX, gameMat[i, 1].PosY, -1.2f), Quaternion.identity);
    }

    //Posiciona o objeto que representa o fim do level
    private void PosicionaObjFimLevel(bool posFinal, float posX, float posY)
    {
        if (posFinal)
        {
            if (scene.name.Equals(LevelController.lvl1, System.StringComparison.Ordinal))
                Instantiate(keyLvl1, new Vector3(posX, posY, -1.2f), Quaternion.identity);
            else if (scene.name.Equals(LevelController.lvl2, System.StringComparison.Ordinal))
                Instantiate(keyLvl2, new Vector3(posX, posY, -1.2f), Quaternion.identity);
            else if (scene.name.Equals(LevelController.lvl3, System.StringComparison.Ordinal))
                Instantiate(keyLvl3, new Vector3(posX, posY, -1.2f), Quaternion.identity);
            else if (scene.name.Equals(LevelController.lvl4, System.StringComparison.Ordinal))
                Instantiate(keyLvl4, new Vector3(posX, posY, -1.2f), Quaternion.identity);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}