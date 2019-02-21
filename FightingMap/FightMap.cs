using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientate
{
    public Orientate(double f0, double f1, double f2, double f3, double b0, double b1, double b2, double b3, double start_angle)
    {
        this.f0 = f0;
        this.f1 = f1;
        this.f2 = f2;
        this.f3 = f3;
        this.b0 = b0;
        this.b1 = b1;
        this.b2 = b2;
        this.b3 = b3;
        this.start_angle = start_angle;
    }
    public readonly double f0;
    public readonly double f1;
    public readonly double f2;
    public readonly double f3;
    public readonly double b0;
    public readonly double b1;
    public readonly double b2;
    public readonly double b3;
    public readonly double start_angle;
}
public class FightMap : MonoBehaviour {
    public List<HexTile> hexTiles;
	
    
    static public void EqualHex(string name, HexTile a, HexTile b)
    {
        if (!(a.q == b.q && a.s == b.s && a.r == b.r))
        {
            Complain(name);
        }
    }
    static public void EqualOffsetcoord(string name, OsCoord a, OsCoord b)
    {
        if (!(a.col == b.col && a.row == b.row))
        {
            Complain(name);
        }
    }
    static public void TestOffsetRoundtrip()
    {
        HexTile a = new HexTile(3, 4, -7);
        OsCoord b = new OsCoord(1, -3);

        EqualHex("conversion_roundtrip even-r", a, OsCoord.RoffsetToCube(OsCoord.EVEN, OsCoord.RoffsetFromCube(OsCoord.EVEN, a)));
        EqualOffsetcoord("conversion_roundtrip even-r", b, OsCoord.RoffsetFromCube(OsCoord.EVEN, OsCoord.RoffsetToCube(OsCoord.EVEN, b)));
        
        EqualHex("conversion_roundtrip odd-r", a, OsCoord.RoffsetToCube(OsCoord.ODD, OsCoord.RoffsetFromCube(OsCoord.ODD, a)));
        EqualOffsetcoord("conversion_roundtrip odd-r", b, OsCoord.RoffsetFromCube(OsCoord.ODD, OsCoord.RoffsetToCube(OsCoord.ODD, b)));
    }


    static public void TestOffsetFromCube()
    {
        EqualOffsetcoord("offset_from_cube odd-r", new OsCoord(1, 2), OsCoord.RoffsetFromCube(OsCoord.ODD, new HexTile(1, 2, -3)));
    }


    static public void TestOffsetToCube()
    {
        EqualHex("offset_to_cube odd-r", new HexTile(1, 2, -3), OsCoord.RoffsetToCube(OsCoord.ODD, new OsCoord(1, 2)));
    }

    static public void Complain(string name)
    {
        Debug.Log("FAIL " + name);
    }
}
