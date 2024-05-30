# [개인과제] "3D Dungeon"
간단한 점프맵 게임을 구현해 봤습니다.

## 📋 목차
1. 구현 기능
2. 조작키
3. 시연 영상


## 📌 구현 기능
 - 필수구현
   - **기본 이동 및 점프** `Input System`, `Rigidbody ForceMode` 
   - **체력바 UI** `UI` 
   - **동적 환경 조사** `Raycast` `UI` 
   - **점프대** `Rigidbody ForceMode`
   - **아이템 데이터** `ScriptableObject`
   - **아이템 사용** `Coroutine` 

 - 선택구현
   - **추가 UI**
     - Stamina Bar, MainItemSlot
     - MainItemSlot에 있는 아이템들은 모두 사용가능 (흡수, 설치.. 등)
   - **3인칭 시점**
     - V키를 이용해 시점 토글기능
   - **움직이는 플랫폼 구현**
       - MovingPlatform
   - **벽 타기 및 매달리기**
       - PlayerAction.cs에서 Ray를 이용하여 Wall Layer체크
       - SpaceBar를 홀드하는 InputAction 활용
   - **다양한 아이템 구현**
       - 세이브 포인트 아이템
       - 먹으면 속도가 빨라지는 아이템
       - 먹으면 더블 점프가 가능해지는 아이템
       - 사다리를 설치하여 올라 갈 수 있는 아이템
   - **장비 장착**
       - 검을 들면 점프력이 높아짐
       - 도끼를 들면 이동속도가 빨라짐
   - **레이저 트랩**
       - Ray를 이용해 플레이어 식별
       - GameView에서도 레이저가 보이게 간단한 방법으로 레이저 길이와 똑같은 오브젝트를 붙힘
   - **상호작용 가능한 오브젝트 표시**
       - Interactable 타입으로 분류해서 표시
   - **플랫폼 발사기**
       - Shift를 꾹 누르고있으면 최소1초 최대5초 사이에서 누른 시간만큼 발사하도록함
   - **발전된 AI**
       - 새로 설치한 사다리에 동적 베이크
       - 빌딩의 구조물의 가중치를 설정
    

## 🖼 조작키
 - 이동 : W,A,S,D  
 - 점프 : Space  
 - 벽타기 : Space(Hold)  
 - 상호작용 : E  
 - 아이템 사용 : Q  
 - 시점 변환 : V  
 - 차지 점프 : Shift (빨간색 플랫폼 위에서만 가능)  
 - 마지막 세이브포인트로 돌아가기 : T

## 📹 시연 영상
https://youtu.be/ZnETSE_1qp4
