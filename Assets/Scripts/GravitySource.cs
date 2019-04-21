using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySource : MonoBehaviour {

    [SerializeField]
    float power;
    public float Power { 
        get { return power; } 
        set { power = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")){
            if (!collision.gameObject.GetComponent<CharactorController>().IsLanded)
                collision.gameObject.GetComponent<GravityObject>().UseGravity(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        GravityObject source = collision.gameObject.GetComponent<GravityObject>();
        if (source.GetGravitySource().Equals(this)){
            source.ResetGravity();
        }
    }
}
