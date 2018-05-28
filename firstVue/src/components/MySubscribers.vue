<template>
    <div class="my-subscribers">
        <UserHeader title='我的预约'></UserHeader>

        <OrderList :data="subcribeData"></OrderList>
        <UserFooter></UserFooter>
    </div>
</template>
<script  type="application/ecmascript">

import UserHeader from './UserHeader'
import UserFooter from './Footer'
import OrderList from '../components/orders/OrderList'

export default {
    components: { UserHeader,UserFooter, OrderList },
    data() {
        return {
            msg: 'Welcome to User Center!',
            subcribeData: [
                { name: '水光针', date: '2017-09-01', price: '2000', status: 0 },
                { name: '纹眉', date: '2017-09-01', price: '800', status: 0 }
            ]


        }

    },
    mounted() {


    },
    methods: {


    },


}

</script>

<style scoped lang="less">
@import '../assets/index.less';

.my-subscribers{height: 100%;background: #fff;}

</style>
