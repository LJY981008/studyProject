using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    //1.����

    bool isFullLevel = false;
    float strength = 15.5f;
    int health = 30;
    int level = 5;
    int mana = 15;
    string playerName = "�̸�";
    string title = "������";

    void Start()
    {

        //2.�迭, ����Ʈ
        string[] monsters = { "������", "������", "������" };
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 20;

        Debug.Log("���� ����");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);

        List<string> items = new List<string>();
        items.Add("������30");
        items.Add("��������30");

        //items.RemoveAt(0);

        Debug.Log(items[0]);
        Debug.Log(items[1]);
        //3. ������
        int exp = 1500;
        exp = 1500 + 320;
        exp = -10;
        level = exp / 300;
        strength = level * 3.1f;


        Debug.Log("����� �� ����ġ");
        Debug.Log(exp);
        Debug.Log("����� ����");
        Debug.Log(level);
        Debug.Log("����� ��");
        Debug.Log(strength);

        int nextExp = 300 - (exp % 300);
        Debug.Log("���� ����ġ");
        Debug.Log(nextExp);


        Debug.Log("����� �̸�");
        Debug.Log(title + "" + playerName);

        int fullLevel = 99;
        isFullLevel = level == fullLevel;
        Debug.Log("���� �޼� ����" + isFullLevel);

        bool isEndTutorial = level > 10;
        Debug.Log("Ʃ�丮�� ����" + isEndTutorial);



        //bool isbadCondition = health <= 50 && mana <= 20;
        bool isbadCondition = health <= 50 || mana <= 20;
        string condition = isbadCondition ? "����" : "����";
        Debug.Log("����� ����" + condition);

        //4. Ű����
        //int float string bool new List

        //5. ���ǹ�
        if (condition == "����")
        {
            Debug.Log("�÷��̾ ���°� ���ڴ� �������� ����ϼ���");
        }
        else
        {
            Debug.Log("�÷��̾��� ���°� �����ϴ�");
        }
        if (isbadCondition && items[0] == "������30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("������30�� ����Ͽ����ϴ�");
        }
        else if (isbadCondition && items[0] == "��������30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("��������30�� ����Ͽ����ϴ�");
        }

        string monsterAlarm;
        switch (monsters[1])
        {
            case "������":
                monsterAlarm = "�������� ����";
                break;
            case "�縷��":
                monsterAlarm = "���� ���Ͱ� ����";
                break;
            case "�Ǹ�":
                monsterAlarm = "���� ���Ͱ� ����";
                break;
            case "��":
                monsterAlarm = "���� ���Ͱ� ����";
                break;
            default:
                monsterAlarm = "?? ���Ͱ� ����";
                break;
        }

        //6. �ݺ���
        while (health > 0)
        {
            health--;
            Debug.Log("�� �������� �Ծ����ϴ�." + health);
            if (health < 1)
            {
                Debug.Log("����Ͽ����ϴ�.");
                break;
            }
            if (health == 10)
            {
                Debug.Log("�ص����� ����մϴ�.");
                break;
            }
        }
        for (int cnt = 0; cnt < 10; cnt++)
        {
            health++;
            Debug.Log("�ش�� ġ�� ��.." + health);
        }
        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("�� ������ �ִ� ���� : " + monsters[index]);
        }

        foreach (string monster in monsters)
        {
            Debug.Log("�� ������ �ִ� ���� : " + monster);
        }
        //7. �Լ�
        Heal();
        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("���� " + monsters[index] + "���� " + Battle(monsterLevel[index])); ;
        }

        //8. Ŭ���� �ν���Ʈȭ
        //Actor player = new Actor();
        Player player = new Player();
        player.id = 0;
        player.name = "�̸�2";
        player.title = "������";
        player.strength = 2.4f;
        player.weapon = "���� ������";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name + "�� ������ " + player.level + "�Դϴ�");

        Debug.Log(player.move());
    }
    //7. �Լ�
    /*int Heal(int currentHealth)
    {
        currentHealth += 10;
        Debug.Log("���� �޾ҽ��ϴ�." + currentHealth);
        return currentHealth;
    }*/
    void Heal()
    {
        health += 10;
        Debug.Log("���� �޾ҽ��ϴ�." + health);
    }
    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
            result = "�̰���ϴ�";
        else
            result = "�����ϴ�";
        return result;
    }


}