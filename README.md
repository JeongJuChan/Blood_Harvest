# 🎮 Blood_Harvest

- 프로젝트 명 : 농부의 밤 - Blood Harvest

- 프로젝트 소개 : 게임 '뱀파이어 서바이버' 를 레퍼런스로 한 2D 로그라이크 게임입니다.

# 구현 기능

- 맵 생성
- 캐릭터 조작
- 경험치 획득 및 레벨업
- 아이템 수집
- 업그레이드 팝업
- 몬스터 스폰

# 담당 파트

## 정주찬
#### 업그레이드

핸들러, 매니저
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Controllers/PlayerWeaponHandler.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Managers/WeaponManager.cs#L1

업그레이드 무기
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Shooters/Base/Shooter.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Shooters/RakeShooter.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Shooters/ShovelShooter.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Shooters/SickleShooter.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Weapons/Base/Weapon.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Weapons/Rake.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Weapons/Shovel.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Weapons/Sickle.cs#L1
![무기 3가지](https://github.com/JeongJuChan/Blood_Harvest/assets/95285906/e4b03b31-a35e-4122-8b74-a387e3c0c3aa)

기본 무기 업그레이드
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Entities/CharacterStatsHandler.cs#L1

#### 팝업 UI
팝업 UI를 구현하였습니다. (Show, Close, Order, IsExist)
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Managers/UIManager.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/UI/UIBase.cs#L1
![image](https://github.com/JeongJuChan/Blood_Harvest/assets/95285906/14a65954-bd19-4991-8c5d-1944ff009399)

#### 기본 무기
총알이 발사되는 것을 오브젝트 풀링으로 구현하였습니다.
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Entities/TopDownShooting.cs#L1
https://github.com/JeongJuChan/Blood_Harvest/blob/98b1ac2cbe34936907e6f9ffc26baf182526daf4/Assets/Scripts/Projectiles/Bullet.cs#L1
![image](https://github.com/JeongJuChan/Blood_Harvest/assets/95285906/d52aec1f-ad8b-4647-951b-1581baf2d6f8)

## 이홍준
#### 몬스터 생성
근거리, 원거리, 보스 2종류
#### 몬스터 AI
#### 몬스터/원거리 공격과 플레이어간의 충돌 감지

## 김하늘
#### 아이템 구현
체력회복, 경험치, 이동속도 증가 버프, 자석(경험치 흡수), 업그레이드 상자
#### 아이템 드랍 테이블

## 장현교
#### 캐릭터
캐릭터 조작, 캐릭터 애니메이션
#### UI 보조

## 김민태
### 기본 UI
### 설정 기능
### 기본 화면 구성

# 게임 화면

![1](https://github.com/JeongJuChan/Blood_Harvest/assets/73785455/695652c0-ff7d-4c6e-b652-665a74918e9b)
![2](https://github.com/JeongJuChan/Blood_Harvest/assets/73785455/38fed7e4-dbd4-4966-b81f-3cd9004009e9)
![3](https://github.com/JeongJuChan/Blood_Harvest/assets/73785455/192d8402-430e-4312-87cc-877a9c2b7ad8)
![4](https://github.com/JeongJuChan/Blood_Harvest/assets/73785455/7105e7f0-2e86-4848-a518-5d5d2f69e1bb)
![5](https://github.com/JeongJuChan/Blood_Harvest/assets/73785455/ec00ca3e-1d24-4f6a-86ee-cb10b2be4ac2)
![6](https://github.com/JeongJuChan/Blood_Harvest/assets/73785455/406760bb-f1b6-4518-aee1-b4f83d41b1a2)

# 사용 기술
- C#
- Unity

# 만든 사람들
<a href="https://github.com/JeongJuChan/Blood_Harvest/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=JeongJuChan/Blood_Harvest" />
</a>
