using UnityEngine;
using System.Collections;

public class Position
{

    #region Tipos
    public const int Tile = 1;
    public const int Vazio = 0;
    public const int Buraco = 2;
    #endregion

    private int   tipo;
    private float posX;
    private float posY;
    private bool  final;

    public Position(int tipo, bool final = false)
    {
        this.tipo  = tipo;
        this.final = final;
    }

    public int Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public float PosX
    {
        get { return posX; }
        set { posX = value; }
    }

    public float PosY
    {
        get { return posY; }
        set { posY = value; }
    }

    public bool Final
    {
        get
        {
            return final;
        }

        set
        {
            final = value;
        }
    }

    public void setaPos(float x, float y)
    {
        this.PosY = y;
        this.posX = x;
    }
}
