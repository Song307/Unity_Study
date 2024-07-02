using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int level = 5;
    int exp = 1500;
    float strength = 15.5f;
    string title = "������";
    string playerName = "���";
    bool isFullLevel = false;
    int health = 30;
    int mana = 25;

    void Start()
    {
        Debug.Log("Hello Unity!");

        //1.����
        int level = 5;
        float strength = 15.5f;
        string playerName = "���";
        bool isFullLevel = false;

        //2. �׷��� ����
        string[] monsters = { "������", "�縷��", "�Ǹ�" };
        int[] monstersLevel = new int[3];
        monstersLevel[0] = 1;
        monstersLevel[1] = 2;
        monstersLevel[2] = 3;


        /*Debug.Log("���� ����");
        Debug.Log(monstersLevel[0]);
        Debug.Log(monstersLevel[1]);
        Debug.Log(monstersLevel[2]);*/


        List<string> items = new List<string>();
        items.Add("������30");  //����Ʈ�� ������ �߰�
        items.Add("��������30");
        items.RemoveAt(0);  //����Ʈ �ε����� ������ ����
        /*Debug.Log(items[0]);
        Debug.Log(items[1]);*/

        //3. ������
        int exp = 1500;
        exp = 1500 + 320;
        level = exp / 300;
        strength = level * 3.1f;

        Debug.Log("����� ����ġ : " + exp);
        Debug.Log("����� ���� : " + level);
        Debug.Log("����� �� : " + strength);

        int nextExp = 300 - (exp % 300);
        Debug.Log("���� �������� ���� ����ġ��? : " + nextExp);

        string title = "������";
        Debug.Log("����� �̸� : " + title + " " + playerName);

        int fullLevel = 99;
        isFullLevel = level == fullLevel;
        Debug.Log("���� �����ΰ�? " + isFullLevel);

        bool isEndTutorial = level > 3;
        Debug.Log("Ʃ�丮���� ������? " + isEndTutorial);


 
        //bool isBadCondition = health <= 50 && mana <= 20;   //And ������
        bool isBadCondition = health <= 50 || mana <= 20;   //Or ������

        string condition = isBadCondition ? "����" : "����";    //���׿�����
        Debug.Log("����� ���°� ���۰�? " + condition);

        //4.���ǹ�
        if (condition == "����")
        {
            Debug.Log("�÷��̾� ���°� ���ڴ� �������� ����ϼ���.");
        } else
        {
            Debug.Log("�÷��̾� ���°� �����ϴ�. ");
        }

        if (isBadCondition && items[0] == "������30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("������30�� ����Ͽ����ϴ�.");
        } else if (isBadCondition && items[0] == "��������30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("��������30�� ����Ͽ����ϴ�.");
        }


        switch (monsters[1])
        {
            case "������":
            case "�縷��":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            case "�Ǹ�":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            case "��":
                Debug.Log("���� ���Ͱ� ����!");
                break;
            default:
                Debug.Log("??? ���� ����");
                break;
        }


        //6. �ݺ���
        while (health > 0)
        {
            health--;
            if (health > 0)
                Debug.Log("�� �������� �Ծ����ϴ�. " + health);
            else
                Debug.Log("����Ͽ����ϴ�.");

            if (health == 10)
            {
                Debug.Log("�ص����� ����մϴ�.");
                break;
            }

        }

        for (int count=0; count<10; count++)
        {
            health++;
            Debug.Log("�ش�(10)�� ��ó ġ����..." + health);
        }

        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("�� ������ �ִ� ���� : " + monsters[index]);
        }


        Heal();

        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log(title + playerName + "�� " + monsters[index] + "���� " + Battle(monstersLevel[index]));
        }

        //8. Ŭ���� (Actor.cs)
        Player player = new Player();     //�ν��Ͻ�ȭ
        player.id = 0;
        player.name = "����";
        player.title = "������";
        player.strength = 2.4f;
        player.weapon = "����������";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());
        Debug.Log(player.weapon);
        Debug.Log(player.name + "�� id" + player.id);
        Debug.Log(player.move());

    }


    //7.�Լ�(�޼ҵ�)

    /*int Heal(int currenthealth)
    {
        currenthealth += 10;
        Debug.Log("���� �޾ҽ��ϴ�. " + currenthealth);
        return currenthealth;
    }
    health = Heal(health);  //�Լ� ȣ��*/


    void Heal()
    {
        health += 10;
        Debug.Log("���� �޾ҽ��ϴ�. " + health);
    }

    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
            result = "�̰���ϴ�.";
        else
            result = "�����ϴ�.";
        return result;
    }
}