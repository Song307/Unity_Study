
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor         //Actor 클래스 상속   [ 자식 / 부모 ]관계
{
    public string move()
    {
        return "플레이어는 움직입니다.";
    }
}


//자식 클래스는 부모클래스의 모든 변수와 함수를 사용 가능
// 자기 자신의 새로운 맴버 변수와 함수를 사용 가능