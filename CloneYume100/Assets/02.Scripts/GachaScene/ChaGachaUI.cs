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

    private int[] weights = new int[] { 80, 56, 37, 20, 7 }; // ���ʴ�� 1��, 2��, 3��, 4��, 5�� ����ġ

    private List<Character> one = new List<Character>(); // 1�� ĳ���� ����Ʈ
    private List<Character> two = new List<Character>(); // 2�� ĳ���� ����Ʈ
    private List<Character> three = new List<Character>(); // 3�� ĳ���� ����Ʈ
    private List<Character> four = new List<Character>(); // 4�� ĳ���� ����Ʈ
    private List<Character> five = new List<Character>(); // 5�� ĳ���� ����Ʈ

    private List<Character>[] characterRare; // ĳ���� ��� ����Ʈ
    static public List<Character> result = new List<Character>(); // �̱� ��� ����Ʈ

    void Start()
    {
        valueBtn.onClick.AddListener(() => valueSceneMove());
        oneTimeBtn.onClick.AddListener(() => OneTimeBtnFun());
        tenTimeBtn.onClick.AddListener(() => TenTimeBtnFun());

        one.Add(new Character(0, "�׳� ����", 1, Character.CharacterColor.Red, 10, 5, 20, Character.BattleSkill.LineDestroy, Character.LeaderSkill.None));
        two.Add(new Character(0, "�ϳ� ����", 2, Character.CharacterColor.Blue, 15, 10, 30, Character.BattleSkill.ColorDestroy, Character.LeaderSkill.None));
        three.Add(new Character(0, "���� ����", 3, Character.CharacterColor.Green, 25, 30, 40, Character.BattleSkill.Heal, Character.LeaderSkill.HealUp));
        four.Add(new Character(0, "��Ƽ ����", 4, Character.CharacterColor.Yellow, 35, 25, 45, Character.BattleSkill.Change, Character.LeaderSkill.AttackUp));
        five.Add(new Character(0, "�׳� ����", 5, Character.CharacterColor.Pupple, 35, 20, 55, Character.BattleSkill.TimeUp, Character.LeaderSkill.AttackUp));

        characterRare = new List<Character>[5] { one, two, three, four, five };
    }

    private void valueSceneMove() // ���� ĳ���� ȭ�� �̵�
    {
        SceneManager.LoadScene("GachaValue");
        SceneManager.LoadScene("MainUI", LoadSceneMode.Additive);
    }

    private void OneTimeBtnFun() // �̱� 1ȸ ��ư �Լ�
    {
        OneTimeGacha();
        SceneManager.LoadScene("GachaResult"); // �̱� ��� ȭ�� �̵�
    }

    private void TenTimeBtnFun() // �̱� 10ȸ ��ư �Լ�
    {
        TenTimeGacha();
        SceneManager.LoadScene("GachaResult"); // �̱� ��� ȭ�� �̵�
    }

    private void GachaFun() // �̱� �Լ�
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

    private void LastGachaFun() // 10���� ������ �̱� �Լ�(4�� : 70% 5�� : 30%)
    {
        int[] weights = new int[] { 70, 30 }; // ���ʴ�� 4��, 5�� ����ġ
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

    private void DecideCharacter(int rare) // ����� �޾� �ش� ����� ĳ���͸� �������� �̴� �Լ�
    {
        int count = characterRare[rare].Count;
        int num = Random.Range(0, count);
        result.Add(characterRare[rare][num]);
    }

    private void OneTimeGacha() // �̱� 1ȸ ���� �Լ�
    {
        GachaFun();
    }

    private void TenTimeGacha() // �̱� 10ȸ ���� �Լ�
    {
        for(int i = 0; i < 9; i++)
        {
            GachaFun();
        }
        // �������� 4�� �̻� �ʼ�
        LastGachaFun();
    }
}