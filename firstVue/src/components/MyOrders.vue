<template>
    <div class="my-orders">
        <UserHeader backurl="/user" title="我的订单"></UserHeader>
      
        <OrderList :data="subcribeData"></OrderList>
        
        
        <UserFooter></UserFooter>
    </div>
</template>
<script  type="application/ecmascript">
import UserHeader from "./UserHeader";
import UserFooter from "./Footer";
import OrderList from "../components/orders/OrderList";
import { defaultCoreCipherList } from "constants";
import order from "../store/modules/order";

export default {
  components: { UserHeader, UserFooter, OrderList },
  data() {
    return {
      user: "", //JSON.parse(localStorage.getItem('userinfo')),
      subcribeData: [
        { name: "水光针", date: "2017-09-01", price: "2000", status: 0 },
        { name: "纹眉", date: "2017-09-01", price: "800", status: 0 }
      ]
    };
  },
  created: function() {},
  mounted() {
    let _this = this;
    _this.$store.dispatch("getLostorageUserInfo").then(function(uInfo) {
      _this.user = uInfo;
      _this.queryOrders();
    });
  },
  methods: {
    queryOrders: function() {
      var _this = this;
      let project_order = new Promise((resolve, reject) => {
        _this.$store
          .dispatch("queryOrders", _this.user.openId)
          .then(function(data) {
            let _orders = [];
            data.forEach(function(item) {
              _orders.push(item);
            });
            resolve(_orders);
            //_this.subcribeData = _orders;
          });
      });
      let product_order = new Promise((resolve, reject) => {
        _this.$store
          .dispatch("queryUserProductOrder", _this.user.userId)
          .then(function(data) {
            let _orders = [];
            data.list.forEach(function(item) {
              console.log(item);
              _orders.push(item);
            });
            resolve(_orders);
            //_this.subcribeData = _orders;
          });
      });

      Promise.all([project_order, product_order]).then(resultList => {
        let orders = resultList[0];
        orders = orders.concat(resultList[1]);
        _this.subcribeData = orders;
      });
    }
  }
};
</script>

<style scoped lang="less">
@import "../assets/index.less";

.my-orders {
  height: 100%;
  background: #fff;
}
</style>
