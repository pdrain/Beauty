<template>
    <div class="my-orders">
        <UserHeader  title="我的订单"></UserHeader>
      
        <OrderList :data="subcribeData"></OrderList>
        
        
        <UserFooter></UserFooter>
    </div>
</template>
<script  type="application/ecmascript">
import UserHeader from "./UserHeader";
import UserFooter from "./Footer";
import OrderList from "../components/orders/OrderList";
import { defaultCoreCipherList } from "constants";

export default {
  components: { UserHeader, UserFooter, OrderList },
  data() {
    return {
      user:JSON.parse(localStorage.getItem('userinfo')),
      subcribeData: [
        { name: "水光针", date: "2017-09-01", price: "2000", status: 0 },
        { name: "纹眉", date: "2017-09-01", price: "800", status: 0 }
      ]
    };
  },
  created: function() {
    var _this = this;
    _this.$store.dispatch("queryOrders", _this.user.openId).then(function(data) {
      let _orders = [];
      data.forEach(function(item) {
        console.log(item);
        _orders.push(item)
      });
      _this.subcribeData = _orders;
    });
  },
  mounted() {},
  methods: {}
};
</script>

<style scoped lang="less">
@import "../assets/index.less";

.my-orders {
  height: 100%;
  background: #fff;
}
</style>
