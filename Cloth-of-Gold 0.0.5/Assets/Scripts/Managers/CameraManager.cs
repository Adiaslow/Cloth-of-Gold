using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    
    [SerializeField] private WorldController _worldController;

    [SerializeField] public Camera cam;

    public Button zoomInButton;
    public Button zoomOutButton;

    private float _camHeight;
    private float _camWidth;
    private float _camLeftBound;
    private float _camUpperBound;
    private float _camRightBound;
    private float _camLowerBound;

    public float zoomStepSize;
    public float zoomMin;
    public float zoomMax;

    private float _speed = 3;

    private IEnumerator Start()
    {
        Button zoomInBtn = zoomInButton.GetComponent<Button>();
        zoomInBtn.onClick.AddListener(ZoomIn);
        Button zoomOutBtn = zoomOutButton.GetComponent<Button>();
        zoomOutBtn.onClick.AddListener(ZoomOut);

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
        float xAxisValue = Input.GetAxis("Horizontal") * -(1/_speed);
        float yAxisValue = Input.GetAxis("Vertical") * -(1/_speed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x - xAxisValue, _camLeftBound, _camRightBound),
                                         Mathf.Clamp(transform.position.y - yAxisValue, _camLowerBound, _camUpperBound),
                                                     transform.position.z);
    }

    private void FastPan()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))

            _speed /= 2;

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))

            _speed *= 2;
    }

    public void ZoomIn()
    {
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x - zoomStepSize, zoomMin, zoomMax),
                                         Mathf.Clamp(transform.localScale.y - zoomStepSize, zoomMin, zoomMax),
                                                     transform.localScale.z);
    }

    public void ZoomOut()
    {
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x + zoomStepSize, zoomMin, zoomMax),
                                          Mathf.Clamp(transform.localScale.y + zoomStepSize, zoomMin, zoomMax),
                                                      transform.localScale.z);
    }
}
