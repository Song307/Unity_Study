using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int level = 5;
    int exp = 1500;
    float strength = 15.5f;
    string title = "전설의";
    string playerName = "용사";
    bool isFullLevel = false;
    int health = 30;
    int mana = 25;

    void Start()
    {
        Debug.Log("Hello Unity!");

        //1.변수
        int level = 5;
        float strength = 15.5f;
        string playerName = "용사";
        bool isFullLevel = false;

        //2. 그룹형 변수
        string[] monsters = { "슬라임", "사막뱀", "악마" };
        int[] monstersLevel = new int[3];
        monstersLevel[0] = 1;
        monstersLevel[1] = 2;
        monstersLevel[2] = 3;


        /*Debug.Log("맵의 몬스터");
        Debug.Log(monstersLevel[0]);
        Debug.Log(monstersLevel[1]);
        Debug.Log(monstersLevel[2]);*/


        List<string> items = new List<string>();
        items.Add("생명물약30");  //리스트에 아이템 추가
        items.Add("마나물약30");
        items.RemoveAt(0);  //리스트 인덱스로 아이템 삭제
        /*Debug.Log(items[0]);
        Debug.Log(items[1]);*/

        //3. 연산자
        int exp = 1500;
        exp = 1500 + 320;
        level = exp / 300;
        strength = level * 3.1f;

        Debug.Log("용사의 경험치 : " + exp);
        Debug.Log("용사의 레벨 : " + level);
        Debug.Log("용사의 힘 : " + strength);

        int nextExp = 300 - (exp % 300);
        Debug.Log("다음 레벨까지 남은 경험치는? : " + nextExp);

        string title = "전설의";
        Debug.Log("용사의 이름 : " + title + " " + playerName);

        int fullLevel = 99;
        isFullLevel = level == fullLevel;
        Debug.Log("용사는 만렙인가? " + isFullLevel);

        bool isEndTutorial = level > 3;
        Debug.Log("튜토리얼이 끝났나? " + isEndTutorial);


 
        //bool isBadCondition = health <= 50 && mana <= 20;   //And 연산자
        bool isBadCondition = health <= 50 || mana <= 20;   //Or 연산자

        string condition = isBadCondition ? "나쁨" : "좋음";    //삼항연산자
        Debug.Log("용사의 상태가 나쁜가? " + condition);

        //4.조건문
        if (condition == "나쁨")
        {
            Debug.Log("플레이어 상태가 나쁘니 아이템을 사용하세요.");
        } else
        {
            Debug.Log("플레이어 상태가 좋습니다. ");
        }

        if (isBadCondition && items[0] == "생명물약30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("생명물약30을 사용하였습니다.");
        } else if (isBadCondition && items[0] == "마나물약30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("마나물약30을 사용하였습니다.");
        }


        switch (monsters[1])
        {
            case "슬라임":
            case "사막뱀":
                Debug.Log("소형 몬스터가 출현!");
                break;
            case "악마":
                Debug.Log("중형 몬스터가 출현!");
                break;
            case "골렘":
                Debug.Log("대형 몬스터가 출현!");
                break;
            default:
                Debug.Log("??? 몬스터 출현");
                break;
        }


        //6. 반복문
        while (health > 0)
        {
            health--;
            if (health > 0)
                Debug.Log("독 데미지를 입었습니다. " + health);
            else
                Debug.Log("사망하였습니다.");

            if (health == 10)
            {
                Debug.Log("해독제를 사용합니다.");
                break;
            }

        }

        for (int count=0; count<10; count++)
        {
            health++;
            Debug.Log("붕대(10)로 상처 치료중..." + health);
        }

        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("이 지역에 있는 몬스터 : " + monsters[index]);
        }


        Heal();

        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log(title + playerName + "는 " + monsters[index] + "에게 " + Battle(monstersLevel[index]));
        }

        //8. 클래스 (Actor.cs)
        Player player = new Player();     //인스턴스화
        player.id = 0;
        player.name = "법사";
        player.title = "현명한";
        player.strength = 2.4f;
        player.weapon = "나무지팡이";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());
        Debug.Log(player.weapon);
        Debug.Log(player.name + "의 id" + player.id);
        Debug.Log(player.move());

    }


    //7.함수(메소드)

    /*int Heal(int currenthealth)
    {
        currenthealth += 10;
        Debug.Log("힐을 받았습니다. " + currenthealth);
        return currenthealth;
    }
    health = Heal(health);  //함수 호출*/


    void Heal()
    {
        health += 10;
        Debug.Log("힐를 받았습니다. " + health);
    }

    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
            result = "이겼습니다.";
        else
            result = "졌습니다.";
        return result;
    }
}