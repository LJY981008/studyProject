using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    //1.변수

    bool isFullLevel = false;
    float strength = 15.5f;
    int health = 30;
    int level = 5;
    int mana = 15;
    string playerName = "이름";
    string title = "전설의";

    void Start()
    {

        //2.배열, 리스트
        string[] monsters = { "슬라임", "슬라임", "슬라임" };
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 20;

        Debug.Log("몬스터 레벨");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);

        List<string> items = new List<string>();
        items.Add("생명물약30");
        items.Add("마나물약30");

        //items.RemoveAt(0);

        Debug.Log(items[0]);
        Debug.Log(items[1]);
        //3. 연산자
        int exp = 1500;
        exp = 1500 + 320;
        exp = -10;
        level = exp / 300;
        strength = level * 3.1f;


        Debug.Log("용사의 총 경험치");
        Debug.Log(exp);
        Debug.Log("용사의 레벨");
        Debug.Log(level);
        Debug.Log("용사의 힘");
        Debug.Log(strength);

        int nextExp = 300 - (exp % 300);
        Debug.Log("남은 경험치");
        Debug.Log(nextExp);


        Debug.Log("용사의 이름");
        Debug.Log(title + "" + playerName);

        int fullLevel = 99;
        isFullLevel = level == fullLevel;
        Debug.Log("만렙 달성 여부" + isFullLevel);

        bool isEndTutorial = level > 10;
        Debug.Log("튜토리얼 여부" + isEndTutorial);



        //bool isbadCondition = health <= 50 && mana <= 20;
        bool isbadCondition = health <= 50 || mana <= 20;
        string condition = isbadCondition ? "나쁨" : "좋음";
        Debug.Log("용사의 상태" + condition);

        //4. 키워드
        //int float string bool new List

        //5. 조건문
        if (condition == "나쁨")
        {
            Debug.Log("플레이어가 상태가 나쁘니 아이템을 사용하세요");
        }
        else
        {
            Debug.Log("플레이어의 상태가 좋습니다");
        }
        if (isbadCondition && items[0] == "생명물약30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("생명물약30을 사용하였습니다");
        }
        else if (isbadCondition && items[0] == "마나물약30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("마나물약30을 사용하였습니다");
        }

        string monsterAlarm;
        switch (monsters[1])
        {
            case "슬라임":
                monsterAlarm = "슬라임이 출현";
                break;
            case "사막뱀":
                monsterAlarm = "소형 몬스터가 출현";
                break;
            case "악마":
                monsterAlarm = "중형 몬스터가 출현";
                break;
            case "골렘":
                monsterAlarm = "대형 몬스터가 출현";
                break;
            default:
                monsterAlarm = "?? 몬스터가 출현";
                break;
        }

        //6. 반복문
        while (health > 0)
        {
            health--;
            Debug.Log("독 데미지를 입었습니다." + health);
            if (health < 1)
            {
                Debug.Log("사망하였습니다.");
                break;
            }
            if (health == 10)
            {
                Debug.Log("해독제를 사용합니다.");
                break;
            }
        }
        for (int cnt = 0; cnt < 10; cnt++)
        {
            health++;
            Debug.Log("붕대로 치료 중.." + health);
        }
        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("이 지역에 있는 몬스터 : " + monsters[index]);
        }

        foreach (string monster in monsters)
        {
            Debug.Log("이 지역에 있는 몬스터 : " + monster);
        }
        //7. 함수
        Heal();
        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("용사는 " + monsters[index] + "에게 " + Battle(monsterLevel[index])); ;
        }

        //8. 클래스 인스턴트화
        //Actor player = new Actor();
        Player player = new Player();
        player.id = 0;
        player.name = "이름2";
        player.title = "현명한";
        player.strength = 2.4f;
        player.weapon = "나무 지팡이";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name + "의 레벨은 " + player.level + "입니다");

        Debug.Log(player.move());
    }
    //7. 함수
    /*int Heal(int currentHealth)
    {
        currentHealth += 10;
        Debug.Log("힐을 받았습니다." + currentHealth);
        return currentHealth;
    }*/
    void Heal()
    {
        health += 10;
        Debug.Log("힐을 받았습니다." + health);
    }
    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
            result = "이겼습니다";
        else
            result = "졌습니다";
        return result;
    }


}