using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlanetType{
    Normal, Rotating, Floating, Breathing
}

public class PlanetController : MonoBehaviour
{

    public int id;
    [SerializeField]
    PlanetType planetType;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = Resources.Load("Planet_" + id, typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Tick(){
        switch(planetType){
            case PlanetType.Breathing:

                break;
            case PlanetType.Floating:
                break;
            case PlanetType.Rotating:
                break;
            default:
                break;
        }
    }
}
