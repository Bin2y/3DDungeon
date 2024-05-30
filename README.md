# [개인과제] "3D Dungeon"

## 👨‍🏫 프로젝트 소개
여러 아이템과 오브젝트들을 이용한 간단한 점프맵 게임

## 📋 목차
1. 구현 기능
2. 조작키
3. Trouble Shooting
4. 시연 영상


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
       - AI브로콜리가 플레이어를 추적
    

## 🖼 조작키
 - 이동 : W,A,S,D  
 - 점프 : Space  
 - 벽타기 : Space(Hold)  
 - 상호작용 : E  
 - 아이템 사용 : Q  
 - 시점 변환 : V  
 - 차지 점프 : Shift (빨간색 플랫폼 위에서만 가능)  
 - 마지막 세이브포인트로 돌아가기 : T

## 📌 Trouble Shooting
**1. 아이템을 들고있을때 교체하는것과 그냥 떨어뜨리는 작업을 할 때 스텟 적용이 떨어뜨리더라도 이전 아이템의 스텟이 떨어지는 현상**  
   - 이전 아이템의 데이터 기록이 남아있었던 것을 발견하고 해당 데이터 기록을 아이템을 UnEquip할때 함께 제거
   
**2. Ray를 이용한 레이저 트랩에서 GameView에서는 레이저가 시각적으로 보이지 않는 현상**
   - 어렵게 생각하지 않고 Ray길이 만큼의 레이저모양 오브젝트를 생성하고 Colider를 제거한 뒤 Ray로만 검사하는 방식을 사용

**3. 벽을 오르는 로직을 구현할 때 스태미나가 모두 소모됐더라도 최소 스태미나만 넘어가면 계속 오르는것을 시도하기 때문에 결국 계속 올라가는 현상 (스태미나가 떨어지면 캐릭터가 밑으로 쭉 떨어지길 원했음)**  
   - Coroutine을 이용해 CoolDown을 두어 일정 시간동안은 canClimb bool값을 false로하여 오르지 못하게 함 (coolDown시간만큼 지나면 다시 오를 수 있음)

**4. LauchPlatform에서 shift를 차징하던중에 플랫폼에서 떨어지면 차징한 시간이 초기화되지 않는 현상**  
   - isCharge Boolean을 두고 플레이어가 플랫폼위에 올라가있으면 Charge이벤트를 구독시키고 (CollisionEnter)
   - 플랫폼위에 "Player"태그가 올라가있으면 해당 캐릭터 Transform을 추적해서 날아갈 수 있도록하고 (CollisionStay)
   - 플랫폼에서 벗어나면 Charge() 함수를 구독취소해서 Charge를 못하게함 (CollisionExit)
              
   

## 📹 시연 영상
https://youtu.be/ZnETSE_1qp4
