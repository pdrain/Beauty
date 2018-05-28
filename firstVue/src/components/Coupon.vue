
<template>
    <div class="coupon">
        <UserHeader title='优惠券'></UserHeader>

        <div class="tab">
            <a class='active'>已领券</a>
            <a>待领券</a>
        </div>

        <div class="coupon-list">
            <div class="msg">{{Msg}}</div>
            <dl v-for="item in CouponList" :key="item">
                <dd></dd>
            </dl>
            正在建设中...
        </div>
        <UserFooter></UserFooter>
    </div>
</template>

<script>
import UserHeader from './UserHeader'
import UserFooter from './Footer'
export default {
    components: { UserHeader, UserFooter },
    data() {
        return {
            CouponList: [],
            Msg:''
        }
    }

}
</script>

<style lang="less">
@import '../assets/index.less';
.coupon {
    height: 100%;
    background: #fff;
}

.coupon .tab {
    height: 35px;
    border-bottom: 1px #f0f0f0 solid;
}

.coupon .tab a {
    display: block;
    width: 50%;
    height: 100%;
    text-align: center;
    line-height: 35px;
    float: left;
    box-sizing: border-box;
}

.coupon .tab a:first-child {
    border-right: 1px #f0f0f0 solid;
}

.coupon .tab a.active {
    border-bottom: 1px solid @font-hot-color;
}

.coupon .coupon-list {
    width: 100%;
    margin-top: 10px;
}

.coupon .coupon-list dl,
.coupon .coupon-list dd {
    margin: 0px;
    padding: 0px;
}
</style>

