using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
 public    Rotator rotator;
    Vector3 target;
    float x,y,z;
    [System.Serializable]
    public struct mystruct {
        public Transform TargetObjTrans;
    }

    public List<mystruct> targetList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public  void MoveToTarget(int index) {
        Vector3 targetLoaction = new Vector3(targetList[index].TargetObjTrans.position.x, targetList[index].TargetObjTrans.position.y, targetList[index].TargetObjTrans.position.z - 5);
        Vector3 LookTarget = new Vector3(targetList[index].TargetObjTrans.position.x, targetList[index].TargetObjTrans.position.y, targetList[index].TargetObjTrans.position.z );
        //LeanTween.value(0f, 1f, 1).setOnUpdate((float value) => {
        //    Debug.Log(value);
        //});

        LeanTween.move(Camera.main.gameObject,targetLoaction,1f).setOnUpdate((float value) =>{
            rotateCamera(LookTarget);

        }).setOnComplete(delegate() {
            while (targetList[index].TargetObjTrans.position.magnitude - target.magnitude > .1)//将QualitySetting下v sync count 改成don't sync不会跳帧
            {
                rotateCamera(LookTarget);
                //Debug.Log(targetList[index].TargetObjTrans.position.magnitude - target.magnitude);
            }
        });


    }


    void rotateCamera(Vector3 _LookTarget) {

        x += (_LookTarget.x - x) * 0.033f;
        y += (_LookTarget.y - y) * 0.033f;
        z += (_LookTarget.z - z) * 0.033f;

        target = new Vector3(x, y, z);
        transform.LookAt(target);
    }
}
