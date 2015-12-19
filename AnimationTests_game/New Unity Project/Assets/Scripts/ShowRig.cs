using UnityEngine;
//using System;
using System.Collections.Generic;

public class ShowRig : MonoBehaviour {

    [System.Serializable]
    public class MirrorBinding {

        [System.Flags]
        public enum MirrorSetting {
            xPosition = 0x1,
            yPosition = 0x2,
            zPosition = 0x4,

            xRotation = 0x8,
            yRotation = 0x16,
            zRotation = 0x32,

            xScale = 0x64,
            yScale = 0x128,
            zScale = 0x256,
        }

        [SerializeField]
        [EnumFlags]
        public MirrorSetting setting;

        public GameObject[] mirroredObjects;



    }

    public Color rigColor = Color.blue;

    public float sphereSize = 0.2f;

    public List<MirrorBinding> mirrorList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
    void OnDrawGizmos() {
        foreach (Transform tf in transform) {

        }
    }
    */
}
