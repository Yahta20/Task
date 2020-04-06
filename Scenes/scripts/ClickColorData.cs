using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickColorData
{

    public string ObjectType {get;set;}
    public int MaxClickCount {get;set;}
    public int MinClickCount {get;set;}
    public Color color       {get;set;}
    public float time2Change { get; set; }
    public primitive prim    { get; set; }

    public ClickColorData(string s,int max,int min, float d, Color clr,primitive p) {
        ObjectType = s;
        MaxClickCount = max;
        MaxClickCount = min;
        time2Change = d;
        color = clr;
        prim = p;
    }

    private double ObjectId { get; set; }
    public double getObjectId() {
        return ObjectId;
    }
}
