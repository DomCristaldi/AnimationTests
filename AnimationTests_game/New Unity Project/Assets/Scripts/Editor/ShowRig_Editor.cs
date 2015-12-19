using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

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

        List<GameObject> selectedGameobjects = Selection.gameObjects.ToList<GameObject>();
        List<GameObject> childrenGameobjects = new List<GameObject>();

        //ShowRig selfScript = (ShowRig)target;




        Color unselectedRigColor = Color.blue;
        Color selectedRigColor = Color.green;
        Color childColor = Color.yellow;

        float rigSphereSize = 0.07f;
        float rigConeSize = 0.05f;

        Color originalColor = Handles.color;

        Handles.color = unselectedRigColor;


        //loop through every object in the root's hierarchy
        foreach (Transform tf in objTransform.GetComponentsInChildren<Transform>()) {

            if (tf.tag == "RigJoint") {//we found a rig-component

                //SELECTED COLOR
                if (selectedGameobjects.Contains(tf.gameObject)) {
                    Handles.color = selectedRigColor;
                }



                //UNSELECTED COLOR
                else { Handles.color = unselectedRigColor; }
                
                //CHILD OBJECT COLOR
                GameObject selectedParent = tf.parent.gameObject;
                while (true) {

                    if (selectedParent == null) { break; }

                    if (selectedGameobjects.Contains(selectedParent)) {
                        Handles.color = childColor;
                        break;
                    }

                    if (selectedParent.transform.parent == null) { break; }
                    else { selectedParent = selectedParent.transform.parent.gameObject; }

                }
                

                /*
                Handles.PositionHandle(tf.position,
                                       Quaternion.identity);
                */
                /*
                Handles.Slider(tf.position,
                               tf.up,
                               rigSphereSize,
                               Handles.SphereCap,
                               0.0f);
                */
                /*
                bool pressed = Handles.Button(tf.position,
                               Quaternion.identity,
                               rigSphereSize,
                               rigSphereSize,
                               Handles.SphereCap);


                if (pressed) {
                    Debug.Log("boom");

                }
                */

                Handles.SphereCap(0,
                                  tf.position,
                                  Quaternion.identity,
                                  rigSphereSize);

                //DRAW CONNECTIONS TO CHILD JOINTS

                if (Handles.color == selectedRigColor) { Handles.color = childColor; }

                foreach (Transform tfChild in tf) {

                    if (tfChild.tag == "RigJoint") {

                    Handles.DrawLine(tf.position, tfChild.position);
                    Handles.ConeCap(0,
                                    Vector3.Lerp(tf.position, tfChild.position, 0.5f),
                                    Quaternion.LookRotation(tf.position - tfChild.position),
                                    rigConeSize);
                    }
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
