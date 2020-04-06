using UnityEngine;

public class gameManager : MonoBehaviour
{

    [SerializeField] public TextAsset file;
    [SerializeField] public GameObject Cube;
    [SerializeField] public GameObject Sphere;
    [SerializeField] public GameObject Cylinder;
    [SerializeField] public Canvas _canvas;
    private Camera _view;
    private prim nameOfObj;
    // Start is called before the first frame update
    void Awake()
    {
        nameOfObj = JsonUtility.FromJson<prim>(file.text);
        _view = GameObject.Find("Main Camera").GetComponent(typeof(Camera)) as Camera;
        
    }
        void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            
            Ray ray = _view.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Plane")
                {
                    int i = Random.Range(0,3);
                    GameObject fr = new GameObject();
                    switch (i) {
                        case 0:
                             fr =Instantiate(Cube, hit.point, Quaternion.identity) as GameObject;
                            fr.name = nameOfObj.Obj1;
                            break;
                        case 1:
                            fr = Instantiate(Sphere, hit.point, Quaternion.identity) as GameObject;
                            fr.name = nameOfObj.Obj2;
                            break;
                        case 2:
                            fr = Instantiate(Cylinder, hit.point, Quaternion.identity) as GameObject;
                            fr.name = nameOfObj.Obj3;
                            break;

                    }

                    primitive primit = fr.AddComponent<primitive>();
                    primit.setName(fr.name);
                }
                else {
                    
                    primitive p =  hit.collider.gameObject.GetComponent<primitive>();
                    p.OneMoreClick();
                    //Увеличение его кол-ва кликов
                }
            }
        }
    }

        
}





        

   
//print("Hit" + hit.point);
/*
 
     
     */
//print(Input.mousePosition);