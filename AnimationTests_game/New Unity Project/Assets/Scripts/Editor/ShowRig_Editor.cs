using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ShowRig))]
public class ShowRig_Editor : Editor {



    //ShowRig selfScript;

    void OnEnable() {
        //selfScript = (ShowRig)target;

        //SceneView.onSceneGUIDelegate += DrawRigFunction;
    }

    //void OnSceneGUI() {
    [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
    static void DrawRigFunction(Transform objTransform, GizmoType gizmoType) {

        //ShowRig selfScript = (ShowRig)target;


        Color rigColor = Color.blue;
        float rigSphereSize = 0.07f;

        Color originalColor = Handles.color;
        Handles.color = rigColor;

        foreach (Transform tf in objTransform.GetComponentsInChildren<Transform>()) {

            if (tf.tag == "RigJoint") {

            Handles.SphereCap(0,
                               tf.position,
                               Quaternion.identity,
                               rigSphereSize);

                if (tf.parent != null && tf.parent.tag == "RigJoint") {

                    Handles.DrawLine(tf.parent.position, tf.position);

                    /*Handles.CylinderCap(0,
                                        Vector3.Lerp(tf.position, tf.parent.position, 0.5f),
                                        Quaternion.LookRotation(tf.parent.position - tf.position),
                                        0.05f);
                    */
                }
            }


            

            
        }

        /*
        Handles.SphereCap(0,
                          selfScript.transform.position,
                          Quaternion.identity,
                          selfScript.sphereSize);
        */


        Handles.color = originalColor;
    }
    
}
