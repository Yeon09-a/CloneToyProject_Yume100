using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AllMemberManager : MonoBehaviour
{
    static public List<int> allObjectsOrder = new List<int>(); // �÷��̾ ������ �ִ� ������Ʈ�� ����Ʈ
    static public List<Character> allCharacters = new List<Character>(); // �÷��̾ ������ �ִ� ĳ���� ����Ʈ
    static public List<TrainingObject> allTrainingObjects = new List<TrainingObject>(); // �÷��̾ ������ �ִ� ������� ����Ʈ
}
