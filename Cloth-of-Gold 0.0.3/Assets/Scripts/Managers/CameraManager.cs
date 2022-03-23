using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private TileManager _tileManager;

    [SerializeField] public Camera cam;

    public float camHeight;
    public float camWidth;
    private float _camLeftBound;
    private float _camUpperBound;
    private float _camRightBound;
    private float _camLowerBound;


    private int _speed = -1;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        CameraDimensions();
        cam.transform.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(camWidth, camHeight);
        cam.transform.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0,0);

    }

    void Update()
    {
        CameraPan();
        FastPan();
        
    }

    private void CameraDimensions()
    {
        camHeight = 2f * cam.orthographicSize;
        camWidth = 2 * cam.orthographicSize * cam.aspect;

        _camLeftBound = (-_tileManager.WIDTH + camWidth) / 2;
        _camRightBound = (_tileManager.WIDTH - camWidth) / 2;
        _camLowerBound = (-_tileManager.HEIGHT + camHeight) / 2;
        _camUpperBound = (_tileManager.HEIGHT - camHeight) / 2;
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
