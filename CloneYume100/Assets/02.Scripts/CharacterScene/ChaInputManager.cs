using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;


public class ChaInputManager : MonoBehaviour
{
    public List<Transform> positions; // ������ � �� ����Ʈ
    
    // �� ����Ʈ�� ������ ������ setPosition�� ȣ���� �� �ð��� ���� �ɷ��� ����Ʈ�� ���Ӱ� �Է��� �ȵȴ�.
    public List<Transform> nextRightPositions; // moveValue�� 1�� ���� ��� ��, ĳ���Ͱ� ���� ��ġ�� �Ѿ�� �ϴ� ��츦 ���� ������ � �� ����Ʈ
    public List<Transform> nextLeftPositions; // moveValue�� 1�� ���� ��� ��, ĳ���Ͱ� ���� ��ġ�� �Ѿ�� �ϴ� ��츦 ���� ������ � �� ����Ʈ

    // ĳ���� ���̾� ����Ʈ
    private List<int> layers = new List<int>() {2, 1, 0, 0, 1 };

    private bool changeLayer = false; // ���̾ 1���� �ٲ�� ���ؼ� �ʿ�
    
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
                    if (moveValue >= 0.9999f)
                    {
                        moveValue = ((touchPoint.x - curPoint.x) / maxMoveWidth) - 0.9999f;
                    }
                    else
                    {
                        moveValue = (touchPoint.x - curPoint.x) / maxMoveWidth;
                    }

                    MoveLeftCharacters(moveValue);
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
            // ��ġ
            first.position = ThreeBezierCurve(positions[0].position, positions[1].position, positions[2].position, value);
            second.position = ThreeBezierCurve(positions[2].position, positions[3].position, positions[4].position, value);
            third.position = ThreeBezierCurve(positions[4].position, positions[5].position, positions[6].position, value);
            fourth.position = ThreeBezierCurve(positions[6].position, positions[7].position, positions[8].position, value);
            fifth.position = ThreeBezierCurve(positions[8].position, positions[9].position, positions[0].position, value);

            // ũ��
            first.localScale = Vector2.Lerp(positions[0].localScale, positions[2].localScale, value);
            second.localScale = Vector2.Lerp(positions[2].localScale, positions[4].localScale, value);
            third.localScale = Vector2.Lerp(positions[4].localScale, positions[6].localScale, value);
            fourth.localScale = Vector2.Lerp(positions[6].localScale, positions[8].localScale, value);
            fifth.localScale = Vector2.Lerp(positions[8].localScale, positions[0].localScale, value);

            if(!changeLayer && value >= 0.3f)
            {
                SetRightLayer();
                changeLayer = true;
            }
        }
        else
        {
            positions.Clear();
            positions = nextRightPositions.ToList();
            changeLayer = false;
        }
        
    }

    private void MoveLeftCharacters(float value)
    {
        if (value < 0.9999f)
        {
            // ��ġ
            first.position = ThreeBezierCurve(positions[0].position, positions[9].position, positions[8].position, value);
            second.position = ThreeBezierCurve(positions[2].position, positions[1].position, positions[0].position, value);
            third.position = ThreeBezierCurve(positions[4].position, positions[3].position, positions[2].position, value);
            fourth.position = ThreeBezierCurve(positions[6].position, positions[5].position, positions[4].position, value);
            fifth.position = ThreeBezierCurve(positions[8].position, positions[7].position, positions[6].position, value);

            // ũ��
            first.localScale = Vector2.Lerp(positions[0].localScale, positions[8].localScale, value);
            second.localScale = Vector2.Lerp(positions[2].localScale, positions[0].localScale, value);
            third.localScale = Vector2.Lerp(positions[4].localScale, positions[2].localScale, value);
            fourth.localScale = Vector2.Lerp(positions[6].localScale, positions[4].localScale, value);
            fifth.localScale = Vector2.Lerp(positions[8].localScale, positions[6].localScale, value);

            if (!changeLayer && value >= 0.3f)
            {
                SetLeftLayer();
                changeLayer = true;
            }
        }
        else
        {
            positions.Clear();
            positions = nextLeftPositions.ToList();
            changeLayer = false;
        }
    }

    private void SetCharacterPosition() // ������ �Ǵ� ���ʿ� �� ������� Ȯ������ �����ؾ� ��
    {
        float maxTime = 2f;
        float time = 0;
        float curMoveValue = moveValue;

        if(curMoveValue != 0 && curMoveValue != 1f)
        {
            if (Vector2.Distance(first.position, positions[2].position) <= Vector2.Distance(first.position, positions[8].position)) // �����ʿ� �� �����
            {
                while(true)
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
                        MoveRightCharacters(time);
                    }

                    if (moveValue == 0 || moveValue >= 0.9999f)
                    {
                        break;
                    }
                }
            }
            else // ���ʿ� �� �����
            {
                while (true)
                {
                    time += Time.deltaTime / maxTime;

                    if (curMoveValue >= 0.4f) // ���� ��ġ�� �� �����
                    {
                        moveValue = Mathf.Lerp(curMoveValue, 1, time);
                        MoveLeftCharacters(time);

                    }
                    else // ���� ��ġ�� �� �����
                    {
                        moveValue = Mathf.Lerp(curMoveValue, 0, time);
                        MoveLeftCharacters(time);
                    }

                    if (moveValue == 0 || moveValue >= 0.9999f)
                    {
                        break;
                    }
                }
            }
        }

        SetPositions();
    }

    private void SetPositions() // ������ � �� ����Ʈ ��ġ ����
    {
        positions.Clear();
        nextRightPositions.Clear();
        nextLeftPositions.Clear();


        if (Vector2.Distance(first.position, a.position) <= 0.05f)
        {
            positions.Add(a);
            positions.Add(b);
            positions.Add(c);
            positions.Add(d);
            positions.Add(e);
            positions.Add(f);
            positions.Add(g);
            positions.Add(h);
            positions.Add(i);
            positions.Add(j);

            nextRightPositions.Add(c);
            nextRightPositions.Add(d);
            nextRightPositions.Add(e);
            nextRightPositions.Add(f);
            nextRightPositions.Add(g);
            nextRightPositions.Add(h);
            nextRightPositions.Add(i);
            nextRightPositions.Add(j);
            nextRightPositions.Add(a);
            nextRightPositions.Add(b);

            nextLeftPositions.Add(i);
            nextLeftPositions.Add(j);
            nextLeftPositions.Add(a);
            nextLeftPositions.Add(b);
            nextLeftPositions.Add(c);
            nextLeftPositions.Add(d);
            nextLeftPositions.Add(e);
            nextLeftPositions.Add(f);
            nextLeftPositions.Add(g);
            nextLeftPositions.Add(h);
        }
        else if (Vector2.Distance(first.position, c.position) <= 0.05f)
        {
            positions.Add(c);
            positions.Add(d);
            positions.Add(e);
            positions.Add(f);
            positions.Add(g);
            positions.Add(h);
            positions.Add(i);
            positions.Add(j);
            positions.Add(a);
            positions.Add(b);

            nextRightPositions.Add(e);
            nextRightPositions.Add(f);
            nextRightPositions.Add(g);
            nextRightPositions.Add(h);
            nextRightPositions.Add(i);
            nextRightPositions.Add(j);
            nextRightPositions.Add(a);
            nextRightPositions.Add(b);
            nextRightPositions.Add(c);
            nextRightPositions.Add(d);

            nextLeftPositions.Add(a);
            nextLeftPositions.Add(b);
            nextLeftPositions.Add(c);
            nextLeftPositions.Add(d);
            nextLeftPositions.Add(e);
            nextLeftPositions.Add(f);
            nextLeftPositions.Add(g);
            nextLeftPositions.Add(h);
            nextLeftPositions.Add(i);
            nextLeftPositions.Add(j);
        }
        else if (Vector2.Distance(first.position, e.position) <= 0.05f)
        {
            positions.Add(e);
            positions.Add(f);
            positions.Add(g);
            positions.Add(h);
            positions.Add(i);
            positions.Add(j);
            positions.Add(a);
            positions.Add(b);
            positions.Add(c);
            positions.Add(d);

            nextRightPositions.Add(g);
            nextRightPositions.Add(h);
            nextRightPositions.Add(i);
            nextRightPositions.Add(j);
            nextRightPositions.Add(a);
            nextRightPositions.Add(b);
            nextRightPositions.Add(c);
            nextRightPositions.Add(d);
            nextRightPositions.Add(e);
            nextRightPositions.Add(f);

            nextLeftPositions.Add(c);
            nextLeftPositions.Add(d);
            nextLeftPositions.Add(e);
            nextLeftPositions.Add(f);
            nextLeftPositions.Add(g);
            nextLeftPositions.Add(h);
            nextLeftPositions.Add(i);
            nextLeftPositions.Add(j);
            nextLeftPositions.Add(a);
            nextLeftPositions.Add(b);
        }
        else if (Vector2.Distance(first.position, g.position) <= 0.05f)
        {
            positions.Add(g);
            positions.Add(h);
            positions.Add(i);
            positions.Add(j);
            positions.Add(a);
            positions.Add(b);
            positions.Add(c);
            positions.Add(d);
            positions.Add(e);
            positions.Add(f);

            nextRightPositions.Add(i);
            nextRightPositions.Add(j);
            nextRightPositions.Add(a);
            nextRightPositions.Add(b);
            nextRightPositions.Add(c);
            nextRightPositions.Add(d);
            nextRightPositions.Add(e);
            nextRightPositions.Add(f);
            nextRightPositions.Add(g);
            nextRightPositions.Add(h);

            nextLeftPositions.Add(e);
            nextLeftPositions.Add(f);
            nextLeftPositions.Add(g);
            nextLeftPositions.Add(h);
            nextLeftPositions.Add(i);
            nextLeftPositions.Add(j);
            nextLeftPositions.Add(a);
            nextLeftPositions.Add(b);
            nextLeftPositions.Add(c);
            nextLeftPositions.Add(d);
        }
        else if (Vector2.Distance(first.position, i.position) <= 0.05f)
        {
            positions.Add(i);
            positions.Add(j);
            positions.Add(a);
            positions.Add(b);
            positions.Add(c);
            positions.Add(d);
            positions.Add(e);
            positions.Add(f);
            positions.Add(g);
            positions.Add(h);

            nextRightPositions.Add(a);
            nextRightPositions.Add(b);
            nextRightPositions.Add(c);
            nextRightPositions.Add(d);
            nextRightPositions.Add(e);
            nextRightPositions.Add(f);
            nextRightPositions.Add(g);
            nextRightPositions.Add(h);
            nextRightPositions.Add(i);
            nextRightPositions.Add(j);

            nextLeftPositions.Add(g);
            nextLeftPositions.Add(h);
            nextLeftPositions.Add(i);
            nextLeftPositions.Add(j);
            nextLeftPositions.Add(a);
            nextLeftPositions.Add(b);
            nextLeftPositions.Add(c);
            nextLeftPositions.Add(d);
            nextLeftPositions.Add(e);
            nextLeftPositions.Add(f);
        }
    }

    private void SetRightLayer() // ���������� �̵� �� ���̾� ����
    {
        int temp = layers[0];
        layers.RemoveAt(0);
        layers.Add(temp);

        first.GetComponent<SpriteRenderer>().sortingOrder = layers[0];
        second.GetComponent<SpriteRenderer>().sortingOrder = layers[1];
        third.GetComponent<SpriteRenderer>().sortingOrder = layers[2];
        fourth.GetComponent<SpriteRenderer>().sortingOrder = layers[3];
        fifth.GetComponent<SpriteRenderer>().sortingOrder = layers[4];
    }

    private void SetLeftLayer() // �������� �̵� �� ���̾� ����
    {
        int temp = layers[4];
        layers.RemoveAt(4);
        layers.Insert(0, temp);

        first.GetComponent<SpriteRenderer>().sortingOrder = layers[0];
        second.GetComponent<SpriteRenderer>().sortingOrder = layers[1];
        third.GetComponent<SpriteRenderer>().sortingOrder = layers[2];
        fourth.GetComponent<SpriteRenderer>().sortingOrder = layers[3];
        fifth.GetComponent<SpriteRenderer>().sortingOrder = layers[4];
    }
}
