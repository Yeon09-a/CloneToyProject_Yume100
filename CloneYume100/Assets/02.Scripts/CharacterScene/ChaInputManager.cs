using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChaInputManager : MonoBehaviour
{
    public List<Vector2> positions; // 베리어 곡선 점 리스트

    public RectTransform first; // 첫 번째 캐릭터
    public RectTransform second; // 두 번째 캐릭터
    public RectTransform third; // 세 번째 캐릭터
    public RectTransform fourth; // 네 번째 캐릭터
    public RectTransform fifth; // 다섯 번째 캐릭터
    
    // Start is called before the first frame update
    void Start()
    {
        positions.Add(first.position);
        positions.Add(new Vector2(second.position.x, first.position.y));
        positions.Add(second.position);
        positions.Add(new Vector2(second.position.x, third.position.y));
        positions.Add(third.position);
        positions.Add(Vector2.Lerp(third.position, fourth.position, 0.5f));
        positions.Add(fourth.position);
        positions.Add(new Vector2(fifth.position.x, fourth.position.y));
        positions.Add(fifth.position);
        positions.Add(new Vector2(fifth.position.x, first.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPoint = Vector2.zero;

            float moveValue = 0f; // 거리 비율로 계산하기 Distance 사용
            
            if (touch.phase == TouchPhase.Began)
            {
                touchPoint = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                Vector2 curPos = touch.position;
                
                if(touchPoint.y - curPos.y < 0) // 오른쪽으로 이동
                {
                    moveValue += 0.5f;

                    MoveRightCharacters(moveValue);

                    if (moveValue == 1f)
                    {
                        moveValue = 0f;
                    }
                }
                else if(touchPoint.y - curPos.y > 0) // 왼쪽으로 이동
                {
                    
                }

                touchPoint = curPos;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                SetCharacterPosition();
                Debug.Log(111);
            }
        }
    }

    private Vector2 ThreeBezierCurve(Vector2 point1, Vector2 point2, Vector2 point3, float value)
    {
        Vector2 temp1 = Vector2.Lerp(point1, point2, value);
        Vector2 temp2 = Vector2.Lerp(point2, point3, value);
        Vector2 temp3 = Vector2.Lerp(temp1, temp2, value);

        return temp3;
    }

    private void MoveRightCharacters(float value)
    {
        if(value == 1)
        {
            for(int i = 0; i < 2; i++)
            {
                Vector2 temp = positions[0];
                positions.RemoveAt(0);
                positions.Add(temp);
            }
        }
        else
        {
            first.position = ThreeBezierCurve(positions[0], positions[1], positions[2], value);
            second.position = ThreeBezierCurve(positions[2], positions[3], positions[4], value);
            third.position = ThreeBezierCurve(positions[4], positions[5], positions[6], value);
            fourth.position = ThreeBezierCurve(positions[6], positions[7], positions[8], value);
            fifth.position = ThreeBezierCurve(positions[8], positions[9], positions[0], value);
        }
        
    }

    private void SetCharacterPosition()
    {
        if (Vector2.Distance(positions[0], first.position) >= Vector2.Distance(first.position, positions[2]))
        {
            first.position = positions[2];
        }
        else
        {
            first.position = positions[0];
        }

        if (Vector2.Distance(positions[2], second.position) >= Vector2.Distance(second.position, positions[4]))
        {
            second.position = positions[4];
        }
        else
        {
            second.position = positions[2];
        }

        if (Vector2.Distance(positions[4], third.position) >= Vector2.Distance(third.position, positions[6]))
        {
            third.position = positions[6];
        }
        else
        {
            third.position = positions[4];
        }

        if (Vector2.Distance(positions[6], fourth.position) >= Vector2.Distance(fourth.position, positions[8]))
        {
            fourth.position = positions[6];
        }
        else
        {
            fourth.position = positions[8];
        }

        if (Vector2.Distance(positions[8], fifth.position) >= Vector2.Distance(fifth.position, positions[0]))
        {
            fifth.position = positions[8];
        }
        else
        {
            fifth.position = positions[0];
        }
    }


}
