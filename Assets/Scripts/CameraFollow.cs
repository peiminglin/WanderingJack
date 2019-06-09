using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public GameObject player;
    //GravityObject gravityObject;
    GameObject target;
    Vector3 camPosition = -Vector3.forward;
    Vector3 camOffset = Vector3.zero;
    Vector3 camTarget => camPosition + camOffset;

    public float defaultSize;
    readonly float panRadius = 5f;
    float zoomSize = 1f;


    // Start is called before the first frame update
    void Start(){
        defaultSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update(){
        CamControl();
        Follow();
        transform.position = Vector3.Lerp(transform.position, camTarget, 0.3f);
    }

    void CamControl(){
        if (Input.GetKey(KeyCode.LeftShift)){
            float panx = Input.GetAxis("Horizontal");
            float pany = Input.GetAxis("Vertical");
            Pan(new Vector3(panx, pany, camPosition.z));
        }else if (Input.GetKeyUp(KeyCode.LeftShift)){
            Pan(Vector3.zero);
        }else if (Input.GetKeyDown(KeyCode.LeftControl)){
            Zoom(2f);
        }else if (Input.GetKeyUp(KeyCode.LeftControl)){
            Zoom();
        }
    }

    void Follow(){
        if (target != null)
            camPosition = new Vector3(target.transform.position.x, target.transform.position.y, camPosition.z);
    }

    public void SetTarget(GameObject target){
        this.target = target;
    }

    //public void MoveTo(Vector3 target){
    //    camPosition = target;
    //}

    public void Zoom(float size = 1f){
        Camera.main.orthographicSize = defaultSize * size;
        zoomSize = size;
    }

    public void Pan(Vector3 direction){
        camOffset = direction.normalized * panRadius * zoomSize;
    }
}
