using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    [SerializeField] private WorldController _worldController;

    [SerializeField] public Camera cam;

    private float _camHeight;
    private float _camWidth;
    private float _camLeftBound;
    private float _camUpperBound;
    private float _camRightBound;
    private float _camLowerBound;


    private int _speed = -1;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        GetCameraDimensions();
    }

    void Update()
    {
        CameraPan();
        FastPan();
        
    }

    private void GetCameraDimensions()
    {
        this._camHeight = 2f * cam.orthographicSize;
        this._camWidth = 2f * cam.orthographicSize * cam.aspect;

        this._camLeftBound = -((_worldController.getWorldSizeInChunks.x * _worldController.getChunkSizeInTiles / 2) - _camWidth / 2) + (_worldController.getWorldSizeInChunks.x * _worldController.getChunkSizeInTiles / 2);
        this._camRightBound = ((_worldController.getWorldSizeInChunks.x * _worldController.getChunkSizeInTiles / 2) - _camWidth / 2) + (_worldController.getWorldSizeInChunks.x * _worldController.getChunkSizeInTiles / 2);
        this._camLowerBound = -((_worldController.getWorldSizeInChunks.y * _worldController.getChunkSizeInTiles / 2) - _camHeight / 2) + (_worldController.getWorldSizeInChunks.x * _worldController.getChunkSizeInTiles / 2);
        this._camUpperBound = ((_worldController.getWorldSizeInChunks.y * _worldController.getChunkSizeInTiles / 2) - _camHeight / 2) + (_worldController.getWorldSizeInChunks.x * _worldController.getChunkSizeInTiles / 2);
    }

    private void CameraPan()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * _speed;
        float yAxisValue = Input.GetAxis("Vertical") * _speed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x - xAxisValue, _camLeftBound, _camRightBound),
                                         Mathf.Clamp(transform.position.y - yAxisValue, _camLowerBound, _camUpperBound),
                                                     transform.position.z);
    }

    private void FastPan()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))

            _speed *= 2;

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))

            _speed = -2;
    }
}
