using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[ExecuteInEditMode]
public class HexTile : MonoBehaviour {

	public HexTile(int q, int r, int s)
    {
        this.q = q;
        this.r = r;
        this.s = s;
        if (q + r + s != 0) throw new ArgumentException("q + r + s must be 0");
    }
    public int q;
    public int r;
    public int s;

    public Vector3 GetCoord(){
        return new Vector3(q,r,s);
    }

    public HexTile Add(HexTile b)
    {
        return new HexTile(q + b.q, r + b.r, s + b.s);
    }


    public HexTile Subtract(HexTile b)
    {
        return new HexTile(q - b.q, r - b.r, s - b.s);
    }


    public HexTile Scale(int k)
    {
        return new HexTile(q * k, r * k, s * k);
    }


    public HexTile RotateLeft()
    {
        return new HexTile(-s, -q, -r);
    }


    public HexTile RotateRight()
    {
        return new HexTile(-r, -s, -q);
    }

    static public List<HexTile> directions = new List<HexTile>{new HexTile(1, 0, -1), new HexTile(1, -1, 0), new HexTile(0, -1, 1), new HexTile(-1, 0, 1), new HexTile(-1, 1, 0), new HexTile(0, 1, -1)};

    static public HexTile Direction(int direction)
    {
        return HexTile.directions[direction];
    }


    public HexTile Neighbor(int direction)
    {
        return Add(HexTile.Direction(direction));
    }

    static public List<HexTile> diagonals = new List<HexTile>{new HexTile(2, -1, -1), new HexTile(1, -2, 1), new HexTile(-1, -1, 2), new HexTile(-2, 1, 1), new HexTile(-1, 2, -1), new HexTile(1, 1, -2)};

    public HexTile DiagonalNeighbor(int direction)
    {
        return Add(HexTile.diagonals[direction]);
    }


    public int Length()
    {
        return (int)((Math.Abs(q) + Math.Abs(r) + Math.Abs(s)) / 2);
    }


    public int Distance(HexTile b)
    {
        return Subtract(b).Length();
    }
    void OnGUI()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos.y = -pos.y;
        GUI.Label(new Rect(pos,new Vector2(200,30)),q+","+r);
    }
}
