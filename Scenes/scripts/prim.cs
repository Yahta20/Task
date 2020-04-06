using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class prim 
{
    public string Obj1{get;set;}
    public string Obj2{get;set;}
    public string Obj3 { get; set; }

    public prim(string o1, string o2, string o3) {
        Obj1 = o1;
        Obj2 = o2;
        Obj3 = o3;
    }
}
 
 
 