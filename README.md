### 2020 Seoul Hardware Hackathon: Team Sim_tact
<p align="center">
<img width="300" alt="KakaoTalk_20200906_112959566" src="https://user-images.githubusercontent.com/52956065/92316838-729bcc00-f034-11ea-80f7-0cc03be555d2.png">
  </p>

## Demonstration video
[![Watch the video](https://user-images.githubusercontent.com/52956065/92318294-fb226880-f044-11ea-82eb-ee0660d4ead9.png)](https://youtu.be/euSKnWlC29Q)


Personalised shopping advertisement board Mynage (Mynage: My + Signage)
============= 
We propose Mynage, a brand new advertising technology in untact era. Mynage is a compound word of My and Signage. It is a location-based ad system. Attatched to a cart, it shows the personalised ad based on the customer's location in the mall.
&nbsp;
&nbsp;
>  &nbsp; Existing promotional activities that offline stores have provided so far, such as face-to-face promotions such as tastings, try-ons, and demonstrations have been the mainstream. However, this activity is not suitable in the untact era.
>
>  &nbsp;본 프로젝트에서 제안하는 마이니지는 디지털 판촉방식을 제공함으로써 오프라인 매장에서 인력을 최소화하는 동시에 효과적인 판촉을 할 수 있는 쇼핑 카트 부착형 시스템입니다. 마이니지는 기존에 시행되던 대면 기반의 판촉 행위를 비대면으로 전환할 수 있도록 도우며, 매장 내 위치를 기반으로 고객에게 적합한 판촉 정보를 제공하는 시스템입니다. 이를 통해 고객은 자신에게 필요한 정보를 제공받을 수 있고, 기업은 판매 대상에게 선택적으로 상품 광고를 할 수 있으며, 매장에서는  위치정보를 활용하여 매대 진열의 효율을 높일 수 있을 것입니다.

&nbsp;
&nbsp;
## Team Members
* Hyoju Lim(Team Leader) : 프로젝트 기획, SW 디버깅, 3D 모델링
* YG Park : SW개발 
* HG Choi : HW개발
* Mina Park : HW 디버깅, 아두이노(비콘) 


## 프로젝트 목적 
<p align="center">
<img width="800" src="https://user-images.githubusercontent.com/49704910/92316398-572dc280-f02e-11ea-9a4e-46fd508126e0.png">
  </p>
  
코로나로 인한 언택트 시대를 살고있음에도 불구하고 아직 마트의 판촉 시스템은 사람이 직접 컨택하는 형태를 띄고 있습니다. 또한 판촉상품이 아닌 물건들에 대해서는 직접 찾아보지 않는이상 구매가 쉽지 않습니다. 우리는 지하철에서도 쉽게 볼 수 있는 디지털 광고판인 사이니지에서 영감을 얻어 카트에 탈부착 하여 사용할 수 있는 디지털 사이니지 시스템을 기획하였습니다. 이는 기존 사이니지의 무작위 추천이 아닌 위치센서(비콘)를 기반으로 현재 위치에서 판매하는 물품을 추천할 수 있는 시스템입니다.




## 파일 리스트
|파일이름|위치|내용|기여자|
|------|---|---|---|
|real_ble.c|(master)sim_tact/real_BLE/src/|비콘신호 감지 및 위치측정|최현경|
|ListPage.xaml.cs|(Version1.3_UI_Final)sim_tact/CartProject/Views/|Tizen UI|박영건|
|AdsMaker.xaml.cs|(Version1.3_UI_Final)sim_tact/CartProject/Models/|Database|박영건|


## 보드
* RPI4 : BLE신호 수신 및 현재위치 계산. 상품정보 디스플레잉. (https://github.com/thebirds0324/sim_tact/tree/Version1.3_UI_Final)
* 아두이노 우노 : 비콘 업로드 (https://github.com/thebirds0324/sim_tact/blob/master/beacon_upload.ino)





## 기능

<h4 align="center"> [ Front-end 구상도 ] </h4>
<p align="center">
<img width="700" alt="스크린샷 2020-09-06 오전 9 50 20" src="https://user-images.githubusercontent.com/49704910/92316453-43369080-f02f-11ea-8680-d5bb56243219.png">
  </p>

디스플레이상에서 현재 위치, 해당 위치에서 판매되는 추천 물품 리스트를 확인할 수 있다. 



위치 기반의 물품 추천 시스템
수신되는 신호를 기반으로 현재 위치에서 판매하는 물품에 대해 추천해주는 시스템. 실내 측위를 위해 특정 위치마다 비콘 발신기를 설치한다. 한 위치를 특정하기 위한 비콘의 갯수는 최소 4개이다. 현재 위치에서 수신되는 신호를  기반으로 현재 위치를 특정한다. 

<h4 align="center"> [ 위치 특정 알고리즘 ] </h4> 

<p align="center">
<img width="250" alt="스크린샷 2020-08-28 오후 8 07 05" src="https://user-images.githubusercontent.com/49704910/92315901-6b21f600-f027-11ea-9aed-f2f72661999f.png">
  </p>
  
위치 A,B,C,D에 해당하는 비콘값은 A={1,2,3,4} B={2,3,5,6} C= {4,5,7,8} D={5,6,8,9}이다. 
1) device name으로 BLE 신호 필터링
2) 2m이내의 신호만 받도록 BLE신호 필터링 
3) 가장 가까운 비콘 송신기를 Key값으로 두고,  해당 Key값이 포함되는 영역과 수신된 신호 비콘신호값들 유사도 확인
4) 가장 높은 유사도를 갖는 영역을 현재 영역으로 판단.  (단, 75%미만일 경우나 다른 예외상황에서는 위치를 갱신하지 않음) 
5) 5초 단위 싸이클로 반복



<h4 align="center"> [ 사용자의 시간당 위치 데이터 획득 ] </h4> 
<p align="center">
<img width="550" alt="스크린샷 2020-08-28 오후 8 07 05" src="https://user-images.githubusercontent.com/49704910/92315715-e8983700-f024-11ea-8307-53d33ecdc589.png">
  </p>
매장의 매대관리를 돕기 위해 사람들이 어느 구역을 얼마나 이용했는지에 대한 데이터를 서버로 전송하는 시스템.

## 받침대 3D 모델링
<p align="center">
<img width="550" alt="KakaoTalk_20200906_003203923" src="https://user-images.githubusercontent.com/52956065/92316670-87776000-f032-11ea-8392-f75153624145.png">
  </p>

특징
1) LCD 사이즈에 맞추어 설계
2) 무게중심을 중앙에 맞추어 한 쪽으로 미끄러지지 않도록 설계
3) 25도 기울여서 사용자가 보기 편하도록 설계
4) 무게 경량화


<h4 align="center"> [ 실제 사용 예상도 ] </h4>
<p align="center">
<img width="550" alt="KakaoTalk_20200906_112955632" src="https://user-images.githubusercontent.com/52956065/92316889-f8b81280-f034-11ea-98b9-e112b1b269d8.png">
  </p>
  

## 구현사항(가산점)
GPIO : 비콘 스캔 초기화시 LED 점등 



