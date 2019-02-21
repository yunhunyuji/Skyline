using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsCoord {

    public OsCoord(int col, int row)
    {
        this.col = col;
        this.row = row;
    }
    public readonly int col;
    public readonly int row;
    static public int EVEN = 1;
    static public int ODD = -1;

    static public OsCoord QoffsetFromCube(int offset, HexTile h)
    {
        int col = h.q;
        int row = h.r + (int)((h.q + offset * (h.q & 1)) / 2);
        return new OsCoord(col, row);
    }


    static public HexTile QoffsetToCube(int offset, OsCoord h)
    {
        int q = h.col;
        int r = h.row - (int)((h.col + offset * (h.col & 1)) / 2);
        int s = -q - r;
        return new HexTile(q, r, s);
    }


    static public OsCoord RoffsetFromCube(int offset, HexTile h)
    {
        int col = h.q + (int)((h.r + offset * (h.r & 1)) / 2);
        int row = h.r;
        return new OsCoord(col, row);
    }

    static public HexTile RoffsetToCube(int offset, OsCoord h)
    {
        int q = h.col - (int)((h.row + offset * (h.row & 1)) / 2);
        int r = h.row;
        int s = -q - r;
        return new HexTile(q, r, s);
    }


}
