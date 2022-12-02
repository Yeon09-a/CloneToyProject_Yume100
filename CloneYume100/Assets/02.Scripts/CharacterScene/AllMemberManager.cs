using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AllMemberManager : MonoBehaviour
{
    static public List<int> allObjectsOrder = new List<int>(); // 플레이어가 가지고 있는 오브젝트들 리스트
    static public List<Character> allCharacters = new List<Character>(); // 플레이어가 가지고 있는 캐릭터 리스트
    static public List<TrainingObject> allTrainingObjects = new List<TrainingObject>(); // 플레이어가 가지고 있는 육성재료 리스트
}
