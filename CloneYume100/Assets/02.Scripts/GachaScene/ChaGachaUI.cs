using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChaGachaUI : MonoBehaviour
{
    public Button valueBtn;
    public Button oneTimeBtn;
    public Button tenTimeBtn;

    private int[] weights = new int[] { 80, 56, 37, 20, 7 }; // 차례대로 1성, 2성, 3성, 4성, 5성 가중치

    private List<Character> one = new List<Character>(); // 1성 캐릭터 리스트
    private List<Character> two = new List<Character>(); // 2성 캐릭터 리스트
    private List<Character> three = new List<Character>(); // 3성 캐릭터 리스트
    private List<Character> four = new List<Character>(); // 4성 캐릭터 리스트
    private List<Character> five = new List<Character>(); // 5성 캐릭터 리스트

    private List<Character>[] characterRare; // 캐릭터 레어도 리스트
    static public List<Character> result = new List<Character>(); // 뽑기 결과 리스트

    public Sprite[] rareImage; // 레어도 이미지
    public Sprite[] colorImage; // 속성 이미지

    public Sprite[] oneImage; // 1성 캐릭터 이미지 리스트
    public Sprite[] twoImage; // 2성 캐릭터 이미지 리스트
    public Sprite[] threeImage; // 3성 캐릭터 이미지 리스트
    public Sprite[] fourImage; // 4성 캐릭터 이미지 리스트
    public Sprite[] fiveImage; // 5성 캐릭터 이미지 리스트

    private Dictionary<int, Sprite[]> characterDic; // 위의 레어도에 따른 캐릭터 이미지 리스트와 레어도를 연결지은 딕셔너리

    void Start()
    {
        characterDic = new Dictionary<int, Sprite[]>() {
            {1, oneImage},
            {2, twoImage},
            {3, threeImage},
            {4, fourImage},
            {5, fiveImage}
        };

        valueBtn.onClick.AddListener(() => valueSceneMove());
        oneTimeBtn.onClick.AddListener(() => OneTimeBtnFun());
        tenTimeBtn.onClick.AddListener(() => TenTimeBtnFun());

        one.Add(new Character(0, "그냥 감자", 1, Character.CharacterColor.Red, 10, 5, 20, Character.BattleSkill.LineDestroy, Character.LeaderSkill.None, characterDic[1][0], rareImage[0], colorImage[((int)Character.CharacterColor.Red)]));
        two.Add(new Character(0, "싹난 감자", 2, Character.CharacterColor.Blue, 15, 10, 30, Character.BattleSkill.ColorDestroy, Character.LeaderSkill.None, characterDic[2][0], rareImage[1], colorImage[((int)Character.CharacterColor.Blue)]));
        three.Add(new Character(0, "공부 감자", 3, Character.CharacterColor.Green, 25, 30, 40, Character.BattleSkill.Heal, Character.LeaderSkill.HealUp, characterDic[3][0], rareImage[2], colorImage[((int)Character.CharacterColor.Green)]));
        four.Add(new Character(0, "파티 감자", 4, Character.CharacterColor.Yellow, 35, 25, 45, Character.BattleSkill.Change, Character.LeaderSkill.AttackUp, characterDic[4][0], rareImage[3], colorImage[((int)Character.CharacterColor.Yellow)]));
        five.Add(new Character(0, "그냥 감자", 5, Character.CharacterColor.Pupple, 35, 20, 55, Character.BattleSkill.TimeUp, Character.LeaderSkill.AttackUp, characterDic[5][0], rareImage[4], colorImage[((int)Character.CharacterColor.Pupple)]));

        characterRare = new List<Character>[5] { one, two, three, four, five };;
    }

    private void valueSceneMove() // 출현 캐릭터 화면 이동
    {
        SceneManager.LoadScene("GachaValue");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }

    private void OneTimeBtnFun() // 뽑기 1회 버튼 함수
    {
        OneTimeGacha();
        SceneManager.LoadScene("GachaResult"); // 뽑기 결과 화면 이동
    }

    private void TenTimeBtnFun() // 뽑기 10회 버튼 함수
    {
        TenTimeGacha();
        SceneManager.LoadScene("GachaResult"); // 뽑기 결과 화면 이동
    }

    private void GachaFun() // 뽑기 함수
    {
        int weight = Random.Range(1, 201);
        int total = 0;
        int rare = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            total += weights[i];

            if (weight <= total)
            {
                rare = i;
                break;
            }
        }

        DecideCharacter(rare);
    }

    private void LastGachaFun() // 10연속 마지막 뽑기 함수(4성 : 70% 5성 : 30%)
    {
        int[] weights = new int[] { 70, 30 }; // 차례대로 4성, 5성 가중치
        int weight = Random.Range(1, 101);
        int total = 0;
        int rare = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            total += weights[i];

            if (weight <= total)
            {
                rare = i+3;
                break;
            }
        }

        DecideCharacter(rare);
    }

    private void DecideCharacter(int rare) // 레어도를 받아 해당 레어도의 캐릭터를 랜덤으로 뽑는 함수
    {
        int count = characterRare[rare].Count;
        int num = Random.Range(0, count);
        result.Add(characterRare[rare][num]);
    }

    private void OneTimeGacha() // 뽑기 1회 실행 함수
    {
        GachaFun();
        AllMemberManager.allCharacters.AddRange(result);
        AllMemberManager.allObjectsOrder.Add(0);
    }

    private void TenTimeGacha() // 뽑기 10회 실행 함수
    {
        for(int i = 0; i < 9; i++)
        {
            GachaFun();
            AllMemberManager.allObjectsOrder.Add(0);
        }
        // 마지막은 4성 이상 필수
        LastGachaFun();
        AllMemberManager.allCharacters.AddRange(result);
        AllMemberManager.allObjectsOrder.Add(0);
    }
}