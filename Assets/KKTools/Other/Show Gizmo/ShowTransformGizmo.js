/**********************************************************
// Author   : K.(k79k06k02k)
// FileName : ShowTransformGizmo.js
**********************************************************/
//
// This is just a helper object, it draws a fake Axis gizmo.
// Usage: Add Component to any GameObject. 
//
// Tip: Set a large fully transparent sphere to make gameobject clickable in the scene.
 
var gizmoSize = 2;
var spherePoint = true;
private var sphereColor = new Color(0, 0, 0, 0.1); 
var sphereScale = 0.25; 

 @script AddComponentMenu ("KKTools/Other/Show Gizmo/Show Transform Gizmo")
function OnDrawGizmos()
{
    if (this.enabled == false) { return; }
 
    if (spherePoint)
    {
        Gizmos.color = sphereColor; 
        Gizmos.DrawSphere (transform.position, sphereScale * gizmoSize);
    }
 
    Gizmos.color = Color.blue;
    Gizmos.DrawLine (transform.position, transform.position + (transform.forward * gizmoSize * 1.0));
    Gizmos.DrawLine (transform.position + (transform.forward * gizmoSize * 1.0), (transform.position + (transform.forward * gizmoSize * 0.8) + (transform.up * gizmoSize * 0.2)));
    Gizmos.DrawLine (transform.position + (transform.forward * gizmoSize * 1.0), (transform.position + (transform.forward * gizmoSize * 0.8) + (transform.up * gizmoSize * -0.2)));
    Gizmos.DrawLine (transform.position + (transform.forward * gizmoSize * 1.0), (transform.position + (transform.forward * gizmoSize * 0.8) + (transform.right * gizmoSize * 0.2)));
    Gizmos.DrawLine (transform.position + (transform.forward * gizmoSize * 1.0), (transform.position + (transform.forward * gizmoSize * 0.8) + (transform.right * gizmoSize * -0.2)));
 
    Gizmos.color = Color.green;
    Gizmos.DrawLine (transform.position, transform.position + (transform.up * gizmoSize));
    Gizmos.DrawLine (transform.position + (transform.up * gizmoSize * 1.0), (transform.position + (transform.up * gizmoSize * 0.8) + (transform.forward * gizmoSize * 0.2)));
    Gizmos.DrawLine (transform.position + (transform.up * gizmoSize * 1.0), (transform.position + (transform.up * gizmoSize * 0.8) + (transform.forward * gizmoSize * -0.2)));
    Gizmos.DrawLine (transform.position + (transform.up * gizmoSize * 1.0), (transform.position + (transform.up * gizmoSize * 0.8) + (transform.right * gizmoSize * 0.2)));
    Gizmos.DrawLine (transform.position + (transform.up * gizmoSize * 1.0), (transform.position + (transform.up * gizmoSize * 0.8) + (transform.right * gizmoSize * -0.2)));
 
    Gizmos.color = Color.red;
    Gizmos.DrawLine (transform.position, transform.position + (transform.right * gizmoSize));
    Gizmos.DrawLine (transform.position + (transform.right * gizmoSize * 1.0), (transform.position + (transform.right * gizmoSize * 0.8) + (transform.up * gizmoSize * 0.2)));
    Gizmos.DrawLine (transform.position + (transform.right * gizmoSize * 1.0), (transform.position + (transform.right * gizmoSize * 0.8) + (transform.up * gizmoSize * -0.2)));
    Gizmos.DrawLine (transform.position + (transform.right * gizmoSize * 1.0), (transform.position + (transform.right * gizmoSize * 0.8) + (transform.forward * gizmoSize * 0.2)));
    Gizmos.DrawLine (transform.position + (transform.right * gizmoSize * 1.0), (transform.position + (transform.right * gizmoSize * 0.8) + (transform.forward * gizmoSize * -0.2)));	
}