using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;


public class ChaInputManager : MonoBehaviour
{
    public List<Vector2> positions; // ������ � �� ����Ʈ
    public List<Vector2> nextRightPositions; // moveValue�� 1�� ���� ��� ��, ĳ���Ͱ� ���� ��ġ�� �Ѿ�� �ϴ� ��츦 ���� ������ � �� ����Ʈ(�̰� ������ ������ setPosition�� �ؾ��ϴµ� �̰Ŵ� �ð��� ���� �ɷ��� ����Ʈ�� ���Ӱ� �Է��� �ȵ�)
    public List<Vector2> nextLeftPositions; // moveValue�� 1�� ���� ��� ��, ĳ���Ͱ� ���� ��ġ�� �Ѿ�� �ϴ� ��츦 ���� ������ � �� ����Ʈ(�̰� ������ ������ setPosition�� �ؾ��ϴµ� �̰Ŵ� �ð��� ���� �ɷ��� ����Ʈ�� ���Ӱ� �Է��� �ȵ�)

    private Touch touch;
    private Vector2 touchPoint;
    private Vector2 curPoint;
    public float moveValue;
    private float maxMoveWidth;

    public Transform first; // ù ��° ĳ����
    public Transform second; // �� ��° ĳ����
    public Transform third; // �� ��° ĳ����
    public Transform fourth; // �� ��° ĳ����
    public Transform fifth; // �ټ� ��° ĳ����

    // ������ � �� ��ġ
    public Transform a;
    public Transform b;
    public Transform c;
    public Transform d;
    public Transform e;
    public Transform f;
    public Transform g;
    public Transform h;
    public Transform i;
    public Transform j;
    
    // Start is called before the first frame update
    void Start()
    {
        maxMoveWidth = (float)Screen.width * 2f / 3f;

        SetPositions();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPoint = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                curPoint = touch.position;

                if (touchPoint.x - curPoint.x < 0) // ���������� �̵�
                {
                    if (moveValue >= 0.9999f)
                    {
                        moveValue = (((touchPoint.x - curPoint.x) * -1f) / maxMoveWidth) - 0.9999f;
                    }
                    else
                    {
                        moveValue = ((touchPoint.x - curPoint.x) * -1f) / maxMoveWidth;
                    }

                    MoveRightCharacters(moveValue);
                }
                else if (touchPoint.x - curPoint.x > 0) // �������� �̵�
                {

                }

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                SetCharacterPosition();
                moveValue = 0;
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
        if(value < 0.9999f)
        {
            first.position = ThreeBezierCurve(positions[0], positions[1], positions[2], value);
            second.position = ThreeBezierCurve(positions[2], positions[3], positions[4], value);
            third.position = ThreeBezierCurve(positions[4], positions[5], positions[6], value);
            fourth.position = ThreeBezierCurve(positions[6], positions[7], positions[8], value);
            fifth.position = ThreeBezierCurve(positions[8], positions[9], positions[0], value);
        }
        else
        {
            positions.Clear();
            positions = nextRightPositions.ToList();
        }
        
    }

    private void SetCharacterPosition() // ������ �Ǵ� ���ʿ� �� ������� Ȯ������ �����ؾ� ��
    {
        float maxTime = 1f;
        float time = 0;
        float curMoveValue = moveValue;

        if(curMoveValue != 0 && curMoveValue != 1f)
        {
            while (true)
            {
                time += Time.deltaTime / maxTime;

                if (curMoveValue >= 0.4f) // ���� ��ġ�� �� �����
                {
                    moveValue = Mathf.Lerp(curMoveValue, 1, time);
                    MoveRightCharacters(time);
                    
                }
                else // ���� ��ġ�� �� �����
                {
                    moveValue = Mathf.Lerp(curMoveValue, 0, time);
                    
                }

                if(moveValue == 0 || moveValue >= 0.9999f)
                {
                    break;
                }
            }
        }

        SetPositions();
    }

    private void SetPositions() 
    {
        positions.Clear();
        nextRightPositions.Clear();
        nextLeftPositions.Clear();


        if (Vector2.Distance(first.position, a.position) <= 0.05f)
        {
            positions.Add(a.position);
            positions.Add(b.position);
            positions.Add(c.position);
            positions.Add(d.position);
            positions.Add(e.position);
            positions.Add(f.position);
            positions.Add(g.position);
            positions.Add(h.position);
            positions.Add(i.position);
            positions.Add(j.position);

            nextRightPositions.Add(c.position);
            nextRightPositions.Add(d.position);
            nextRightPositions.Add(e.position);
            nextRightPositions.Add(f.position);
            nextRightPositions.Add(g.position);
            nextRightPositions.Add(h.position);
            nextRightPositions.Add(i.position);
            nextRightPositions.Add(j.position);
            nextRightPositions.Add(a.position);
            nextRightPositions.Add(b.position);

            nextLeftPositions.Add(i.position);
            nextLeftPositions.Add(j.position);
            nextLeftPositions.Add(a.position);
            nextLeftPositions.Add(b.position);
            nextLeftPositions.Add(c.position);
            nextLeftPositions.Add(d.position);
            nextLeftPositions.Add(e.position);
            nextLeftPositions.Add(f.position);
            nextLeftPositions.Add(g.position);
            nextLeftPositions.Add(h.position);
        }
        else if (Vector2.Distance(first.position, c.position) <= 0.05f)
        {
            positions.Add(c.position);
            positions.Add(d.position);
            positions.Add(e.position);
            positions.Add(f.position);
            positions.Add(g.position);
            positions.Add(h.position);
            positions.Add(i.position);
            positions.Add(j.position);
            positions.Add(a.position);
            positions.Add(b.position);

            nextRightPositions.Add(e.position);
            nextRightPositions.Add(f.position);
            nextRightPositions.Add(g.position);
            nextRightPositions.Add(h.position);
            nextRightPositions.Add(i.position);
            nextRightPositions.Add(j.position);
            nextRightPositions.Add(a.position);
            nextRightPositions.Add(b.position);
            nextRightPositions.Add(c.position);
            nextRightPositions.Add(d.position);

            nextLeftPositions.Add(a.position);
            nextLeftPositions.Add(b.position);
            nextLeftPositions.Add(c.position);
            nextLeftPositions.Add(d.position);
            nextLeftPositions.Add(e.position);
            nextLeftPositions.Add(f.position);
            nextLeftPositions.Add(g.position);
            nextLeftPositions.Add(h.position);
            nextLeftPositions.Add(i.position);
            nextLeftPositions.Add(j.position);
        }
        else if (Vector2.Distance(first.position, e.position) <= 0.05f)
        {
            positions.Add(e.position);
            positions.Add(f.position);
            positions.Add(g.position);
            positions.Add(h.position);
            positions.Add(i.position);
            positions.Add(j.position);
            positions.Add(a.position);
            positions.Add(b.position);
            positions.Add(c.position);
            positions.Add(d.position);

            nextRightPositions.Add(g.position);
            nextRightPositions.Add(h.position);
            nextRightPositions.Add(i.position);
            nextRightPositions.Add(j.position);
            nextRightPositions.Add(a.position);
            nextRightPositions.Add(b.position);
            nextRightPositions.Add(c.position);
            nextRightPositions.Add(d.position);
            nextRightPositions.Add(e.position);
            nextRightPositions.Add(f.position);

            nextLeftPositions.Add(c.position);
            nextLeftPositions.Add(d.position);
            nextLeftPositions.Add(e.position);
            nextLeftPositions.Add(f.position);
            nextLeftPositions.Add(g.position);
            nextLeftPositions.Add(h.position);
            nextLeftPositions.Add(i.position);
            nextLeftPositions.Add(j.position);
            nextLeftPositions.Add(a.position);
            nextLeftPositions.Add(b.position);
        }
        else if (Vector2.Distance(first.position, g.position) <= 0.05f)
        {
            positions.Add(g.position);
            positions.Add(h.position);
            positions.Add(i.position);
            positions.Add(j.position);
            positions.Add(a.position);
            positions.Add(b.position);
            positions.Add(c.position);
            positions.Add(d.position);
            positions.Add(e.position);
            positions.Add(f.position);

            nextRightPositions.Add(i.position);
            nextRightPositions.Add(j.position);
            nextRightPositions.Add(a.position);
            nextRightPositions.Add(b.position);
            nextRightPositions.Add(c.position);
            nextRightPositions.Add(d.position);
            nextRightPositions.Add(e.position);
            nextRightPositions.Add(f.position);
            nextRightPositions.Add(g.position);
            nextRightPositions.Add(h.position);

            nextLeftPositions.Add(e.position);
            nextLeftPositions.Add(f.position);
            nextLeftPositions.Add(g.position);
            nextLeftPositions.Add(h.position);
            nextLeftPositions.Add(i.position);
            nextLeftPositions.Add(j.position);
            nextLeftPositions.Add(a.position);
            nextLeftPositions.Add(b.position);
            nextLeftPositions.Add(c.position);
            nextLeftPositions.Add(d.position);
        }
        else if (Vector2.Distance(first.position, i.position) <= 0.05f)
        {
            positions.Add(i.position);
            positions.Add(j.position);
            positions.Add(a.position);
            positions.Add(b.position);
            positions.Add(c.position);
            positions.Add(d.position);
            positions.Add(e.position);
            positions.Add(f.position);
            positions.Add(g.position);
            positions.Add(h.position);

            nextRightPositions.Add(a.position);
            nextRightPositions.Add(b.position);
            nextRightPositions.Add(c.position);
            nextRightPositions.Add(d.position);
            nextRightPositions.Add(e.position);
            nextRightPositions.Add(f.position);
            nextRightPositions.Add(g.position);
            nextRightPositions.Add(h.position);
            nextRightPositions.Add(i.position);
            nextRightPositions.Add(j.position);

            nextLeftPositions.Add(g.position);
            nextLeftPositions.Add(h.position);
            nextLeftPositions.Add(i.position);
            nextLeftPositions.Add(j.position);
            nextLeftPositions.Add(a.position);
            nextLeftPositions.Add(b.position);
            nextLeftPositions.Add(c.position);
            nextLeftPositions.Add(d.position);
            nextLeftPositions.Add(e.position);
            nextLeftPositions.Add(f.position);
        }
    } // ������ � �� ����Ʈ ��ġ ����
}
