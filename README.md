### 2020 서울 하드웨어 해커톤 sim_tact 팀

현명한 쇼핑을 돕는 쇼핑비서 시스템 ShowBee
=============
언택트 시대에 필요한 기술로 저희는 쇼핑 비서 Showbee를 제안합니다. 쇼비는 단순 로직에 의한 추천이 아닌 위치 기반의 판촉 시스템으로 고객에게는 효율적이고 즐거운 쇼핑을, 기업에게는 효율적인 마케팅의 기회를 제공하는 시스템입니다.

&nbsp;
&nbsp;

>  &nbsp;지금까지 오프라인 매장에서 제공해왔던 판촉의 행위로는 시식, 시착, 시연 등 사람을 통한 판촉이 주류를 이뤘습니다. 그러나 특히 시식을 통한 판촉이나 직접 말로 제품을 홍보하는 판촉 행위는 언택트 시대에 적합하지 않은 판촉 방법이며, 언택트 시대에 알맞은 판촉 방법이 필요할 때입니다. 
>
>  &nbsp;본 프로젝트에서 제안하는 쇼비는 디지털 판촉방식을 제공함으로써 오프라인 매장에서 인력을 최소화하는 동시에 효과적인 판촉을 할 수 있는 쇼핑 카트 부착형 시스템입니다. 쇼비는 기존에 시행되던 대면 기반의 판촉 행위를 비대면으로 전환할 수 있도록 도우며, 매장 내 위치를 기반으로 한 판촉 시스템입니다. 이를 통해 고객은 자신에게 필요한 정보를 제공받을 수 있고, 기업은 판매 대상에게 선택적으로 상품 광고를  하여 매대 진열의 효율을 높일 수 있을 것입니다.

&nbsp;
&nbsp;

## 1. 소프트웨어 구성도 (background~front)
<img width="1000" alt="스크린샷 2020-08-28 오후 9 07 11" src="https://user-images.githubusercontent.com/49704910/91559176-8b401e00-e972-11ea-9fa7-6212cb05961b.png">

작성중 


## 2. 기능
### 1. 위치 기반의 물품 추천 시스템
수신되는 비콘 신호를 기반으로 현재 위치를 추정하여 물품을 추천해주는 시스템. 

<img width="278" alt="스크린샷 2020-08-28 오후 8 07 05" src="https://user-images.githubusercontent.com/49704910/91554468-254f9880-e96a-11ea-84c6-75215ab61499.png">

1) 2m이내의 비콘 신호 수신
2) 가장 거리 가까운 송신기를 Key값으로 두고,  해당 Key값이 포함되는 영역과 수신된 신호 유사도 확인
3) 가장 높은 유사도를 갖는 영역을 현재 영역으로 판단.  (단, 75%미만일 경우 이전 영역에서 갱신하지 않음.) 

&nbsp;
## 3. 기존 스마트카트와의 차별점(경쟁성)
작성중
기존의 스마트카트는 무인매장 구현을 위하여 카트에 자동 결제 시스템과 같은 기술을 포함하고 있다. 이러한 기술은 계산원에 대한 인건절감을 가능하게 하지만 초기 구매비용 및 유지보수 비용이 적지않다는 단점이 존재한다.
 우리는 이런 스마트카트의 최신 동향과 달리 판촉인원을 대체하는 시스템에 집중하였다. 이를 위해 무엇보다 "저비용"에 초점을 맞추었으며 이를 통해 소비 촉진을 이루고자 한다.
표 첨부


