using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public MeshRenderer myRenderPlane;
    Camera playerCam;
    Camera myCamera;

    [HideInInspector] public PortalTeleport myTeleport;

    private void Awake()
    {
        playerCam = Camera.main;
        myCamera = GetComponentInChildren<Camera>();
        myTeleport = GetComponentInChildren<PortalTeleport>();
        myTeleport.player = playerCam.transform.parent;
        //myTeleport.receiver = linkedPortal.GetComponentInChildren<PortalTeleport>().transform;
    }

    private void Start()
    {
        myTeleport.receiver = linkedPortal.myTeleport.transform;

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCamera.targetTexture = rt;
        linkedPortal.myRenderPlane.material.SetTexture("_MainTex", rt);
    }

    private void Update()
    {
        var matrix = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix
            * playerCam.transform.localToWorldMatrix;
        myCamera.transform.SetPositionAndRotation(matrix.GetColumn(3), matrix.rotation);
    }
}
