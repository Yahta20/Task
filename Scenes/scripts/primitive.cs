using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[System.Serializable]
public class primitive : MonoBehaviour
{
    public primitive(string n,Color c,int min,int max) {
      objName   =n;
      color     =c;
     _minClick =min;
     _maxClick =max;
} 
    public string objName { get;private set; }
    public Color color;
    [SerializeField] private int _minClick;
    [SerializeField] private int _maxClick;
    [SerializeField] private int _ClicCount=0;
    [SerializeField] private float _timeToChange;//in milliseconds
    private int time4screen;
    public CanvasControll cc;
    private  ClickColorData ccd;
    private Renderer rend;
    void Start() {

        _minClick       = Random.Range(0, 50);
        _maxClick       = Random.Range(_minClick, 254);
        _timeToChange   = Random.Range(500,2000);

        
        rend = GetComponent<Renderer>();

        ccd = new ClickColorData(objName, _maxClick, _minClick, _timeToChange, color,this);
        Canvas _canvas = GameObject.Find("Canvas").GetComponent(typeof(Canvas)) as Canvas;
        cc=_canvas.GetComponent<CanvasControll>();
        cc.addObject(ccd);

        Observable.Timer(System.TimeSpan.FromMilliseconds(_timeToChange)) 
        .Repeat() 
        .Subscribe(_ => { 

            changeColor();
        });
    }
    public void setName(string s) {
        objName = s;

    } 
    private void changeColor() {
        
            switch (objName)
            {
                case "Cube":
                    color = Random.ColorHSV(0, (_ClicCount / _maxClick), 0, (_maxClick - _ClicCount / _maxClick));
                    break;
                case "Sphere":
                    float r = (_ClicCount /  254) < 1 ? (_ClicCount / 254) : 1;
                    float g = (_ClicCount  / 254)< 1 ? (_ClicCount / 254) : 1;
                    float b = (_ClicCount  / 254)< 1 ? (_ClicCount / 254) : 1;
                    color = new Color(Random.Range(0,r), Random.Range(0, g), Random.Range(0, b));
                    
                    break;
                case "Cylinder":
                    
                    color = Random.ColorHSV(0, 0.3f, 0, 0.5f,0,0.7f);
                    break;
                }

        if (_ClicCount > _minClick & _ClicCount < _maxClick)
        {
            rend.material.color = color;

        }
        
    rend.material.color = Random.ColorHSV(0, 1f, 0, 0.5f, 0, 0.5f); 
        
    
}
    public void OneMoreClick() {
        _ClicCount++;
    }

}
