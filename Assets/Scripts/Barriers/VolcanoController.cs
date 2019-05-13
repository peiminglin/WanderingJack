using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum VolcanoStatus{
    Normal, Ready, Explode
}

public class VolcanoController : MonoBehaviour
{
    VolcanoStatus status;
    float timeToExplode;
    Material myMat;
    float countDown;
    [SerializeField]
    int maxFireAmount = 10;
    int fireAmount;
    float explodeFreq = 0.5f;
    float timeToPoo;
    [SerializeField]
    GameObject firePrefab;

    // Start is called before the first frame update
    void Start(){
        myMat = GetComponent<Renderer>().material;
        NextExplosion();
    }

    void NextExplosion(){
        timeToExplode = Random.Range(3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        switch(status){
            case VolcanoStatus.Normal:
                if (timeToExplode >= 0) {
                    timeToExplode -= Time.deltaTime;
                    if (timeToExplode < 0) {
                        status = VolcanoStatus.Ready;
                        countDown = 1f;
                    }
                }
                break;
            case VolcanoStatus.Ready:
                countDown -= Time.deltaTime;
                myMat.color = Color.Lerp(Color.white, Color.red, 1f - countDown);
                if (countDown < 0) {
                    myMat.color = Color.white;
                    status = VolcanoStatus.Explode;
                    fireAmount = maxFireAmount;
                }
                break;
            case VolcanoStatus.Explode:
                if (fireAmount > 0){
                    //Vector3 offset = Random.insideUnitCircle.to3d(transform.position.z);
                    if (timeToPoo > explodeFreq){
                        GameObject go = Instantiate(firePrefab, transform.position, Quaternion.identity);
                        Vector2 dir = transform.up;
                        dir.Rotate(Random.Range(-75f, 75f));
                        go.GetComponent<VolcanoFire>().Poo(dir);
                        go.transform.parent = this.transform.parent;
                        fireAmount--;
                        timeToPoo = 0;
                    }else{
                        timeToPoo += Time.deltaTime;
                    }
                } else{
                    status = VolcanoStatus.Normal;
                    NextExplosion();
                }
                break;
            default:
                break;
        }
    }
}
