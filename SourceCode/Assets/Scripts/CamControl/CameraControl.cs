using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public float verticalScrollArea = Screen.height - 60f;
    public float horizontalScrollArea = Screen.width - 128f;
    public float verticalScrollSpeed = 25f;
    public float horizontalScrollSpeed = 25f;

    public void EnableControls(bool enable)
    {
        if (enable)
        {
            ZoomEnabled = true;
            MoveEnabled = true;
        }
        else
        {
            ZoomEnabled = false;
            MoveEnabled = false;
        }
    }

    public bool ZoomEnabled = true;
    public bool MoveEnabled = true;

    private Vector2 mousePos;
    private Vector3 moveVector;
    private int xMove;
    private int yMove;
    private int zMove;

    // Update is called once per frame

    void Update()
    {
        mousePos = Input.mousePosition;
        while (true)
        {
            //Move camera if mouse is at the edge of the screen
            if (MoveEnabled)
            {
                if (mousePos.x < 100 || Input.GetKey(KeyCode.LeftArrow))
                {
                    xMove = 1;
                    zMove = -1;
                    break;
                }
                else if (mousePos.x >= Screen.width - 100 || Input.GetKey(KeyCode.RightArrow))
                {
                    xMove = -1;
                    zMove = 1;
                    break;
                }
                else
                {
                    xMove = 0;
                }

                if (mousePos.y < 40 || Input.GetKey(KeyCode.DownArrow))
                {
                    zMove = 1;
                    xMove = 1;
                    break;
                }
                else if (mousePos.y >= Screen.height - 40 || Input.GetKey(KeyCode.UpArrow))
                {
                    zMove = -1;
                    xMove = -1;
                    break;
                }
                else
                {
                    zMove = 0;
                }
            }
            else
            {
                xMove = 0;
                yMove = 0;
            }
            break;
        }

        //Zoom Camera in or out

        if (ZoomEnabled)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                yMove = 12;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                yMove = -12;
            }

            else
            {
                yMove = 0;
            }
        }
        else
        {
            zMove = 0;
        }

        //move the object
        MoveMe(xMove, yMove, zMove);
    }

    private void MoveMe(int x, int y, int z)
    {
        moveVector = (new Vector3(x * horizontalScrollSpeed, y * verticalScrollSpeed, z * horizontalScrollSpeed) * Time.deltaTime);
        transform.Translate(moveVector, Space.World);
    }

}