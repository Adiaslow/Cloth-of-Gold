using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExtentions
{
    public static Dictionary<string,float> GetCameraDimensions(this Camera Ca)
    {
        Camera cam = Camera.main;

        Dictionary<string, float> cameraDimensions = new Dictionary<string, float>();

        float camWidth = 2 * cam.orthographicSize;
        cameraDimensions.Add("camWidth", camWidth);

        float camHeight = 2 * cam.orthographicSize * cam.aspect;
        cameraDimensions.Add("camHeight", camHeight);

        //float camLeftBound = (-_tileManager.WIDTH + camWidth) / 2; ;
        //float camRightBound = (_tileManager.HEIGHT - camHeight) / 2;
        //float camUpperBound = (_tileManager.WIDTH - camWidth) / 2;
        //float camLowerBound = (-_tileManager.HEIGHT + camHeight) / 2;

        return cameraDimensions;
    }
}