using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private TileManager _tileManager;

    

    public float camHeight;
    public float camWidth;
    private float _camLeftBound;
    private float _camUpperBound;
    private float _camRightBound;
    private float _camLowerBound;


    private int _speed = -1;

    private IEnumerator Start()
    {
        Camera cam = Camera.main;

        yield return new WaitForSeconds(0.5f);

        cam.transform.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(cam.GetCameraDimensions()["camWidth"], cam.GetCameraDimensions()["camHeight"]);

    }

    void Update()
    {
        CameraPan();
        FastPan();
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
