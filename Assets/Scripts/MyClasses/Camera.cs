using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace camera_follow
{
    public class Camera
    {
        //Atributes
        Vector3 virtualCamMask;
        [Header("Player To Follow")] public Transform target;
        [Header("Layers to Include")] LayerMask camOcclusion;
        //Constructor to initialize an instance
        Camera(Transform targetToFollow, LayerMask camLayers)
        {
            target = targetToFollow;
            camOcclusion = camLayers;
        }
        
        //Methods
        Vector3 occludeRay(ref Vector3 targetFollow)
        {
            //Creamos un raycast
            RaycastHit wallHit = new RaycastHit();
            //linecast from your player (targetFollow) to your cameras mask (camMask) to find collisions.
            if (Physics.Linecast(targetFollow, virtualCamMask, out wallHit, camOcclusion))
            {
                //the x and z coordinates are pushed away from the wall by hit.normal.
                //the y coordinate stays the same.
                return new Vector3(wallHit.point.x + wallHit.normal.x * 0.5f, virtualCamMask.y, wallHit.point.z + wallHit.normal.z * 0.5f);
            }
            else return virtualCamMask;
        }

    }
}

