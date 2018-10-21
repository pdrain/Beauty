<template>
    <div class="product" v-title='"产品详情"'>
        <div class="product-info" v-if="detail">
            <img :src="detail.icon"/>
            <div class="block price">
                <p>购买价格：<span>¥ {{detail.price}}</span></p>
                <p>兑换价格：<span>{{detail.point}}&nbsp;积分</span></p>
                <p class="desc">备注：本宝贝可以直接在线购买或通过积分兑换！</p>
            </div>
            <div class="block desc">{{detail.name}}</div>
            <div class="block spec">规格</div>
            <div class="block detail">详情</div>
        </div> 
        <h2 class="title">配送信息</h2>
        <div class="detial">
            <ul>
                <li>
                    <label>联系人：</label>
                    <div>
                       <input type="text" v-model="exchangeOrder.receiver">
                    </div>
                </li>
                <li>
                    <label>联系电话：</label>
                    <div>
                       <input type="text" v-model="exchangeOrder.phone">
                    </div>
                </li>
                <li class="multiLine"> 
                    <label>收货地址：</label>
                    <div>
                       <textarea v-model="exchangeOrder.address"></textarea>
                    </div>
                </li>
                <li class="multiLine"> 
                    <label>备注：</label>
                    <div>
                       <textarea v-model="exchangeOrder.remark"></textarea>
                    </div>
                </li>
            </ul>
           
        </div>
        <p class="deliveray-desc">备注：为了您能尽快的收到宝贝，请填写真是的联系信息，并仔细核对。我们将第一时间将宝贝送到您的手中！</p>
        <p class="bottom-space">&nbsp;</p>
        <div class="buttons">
            <a class="home"></a>
            <a class="btn left" @click="doBuy">立即购买</a>
            <a class="btn" @click="doExchange">立即兑换</a>
        </div>
    </div>
</template>

<script>
import Swal from "sweetalert2";
export default {
  name: "product-exchange",
  components: {},
  data() {
    return {
      prdid: this.getQueryString("prdid"),
      detail: null,
      UserInfo: {},
      exchangeOrder: {
        openId: "",
        productId: this.prdid || "",
        quantity: "1",
        receiver: "",
        address: "",
        phone: "",
        remark: ""
      }
    };
  },
  mounted() {
    let _this = this;
    _this.getProductDetail();

    _this.$store.dispatch("getLostorageUserInfo").then(function(uInfo) {
      _this.UserInfo = uInfo;

      console.log(_this.UserInfo);
      _this.exchangeOrder.openId = _this.UserInfo.openId;
      _this.exchangeOrder.receiver = _this.UserInfo.contact;
      _this.exchangeOrder.phone = _this.UserInfo.contractNo;
    });
  },
  methods: {
    getProductDetail() {
      let _this = this;
      this.$store.dispatch("queryProductDetail", _this.prdid).then(data => {
        _this.detail = data;
      });
    },
    doExchange() {
      // 调用接口进行兑换，然后跳转直兑换结果页
      let _this = this;
      _this.exchangeOrder.productId = _this.prdid;
      _this.precheckBySave().then(
        () => {
          this.$store
            .dispatch("saveExchangeProduct", _this.exchangeOrder)
            .then(data => {
              Swal({
                text: "宝贝兑换成功!",
                showCancelButton: true,
                confirmButtonText: "继续浏览产品",
                //cancelButtonText: "返回首页"
              });
            });
        },
        errs => {
          Swal({text:errs.join("\r\n")});
        }
      );
    },
    precheckBySave() {
      let _this = this;
      let _errors = [];
      let cb = (resolve, reject) => {
        if (!_this.exchangeOrder.receiver) {
          _errors.push("请输入联系人。");
        }
        if (!_this.exchangeOrder.phone) {
          _errors.push("请输入联系电话。");
        }
        if (!_this.exchangeOrder.address) {
          _errors.push("请输入详细收货地址。");
        }
        if (_errors.length == 0) {
          resolve();
        } else {
          reject(_errors);
        }
      };
      let promise = new Promise((resolve, reject) => {
        cb(resolve, reject);
      });
      return promise;
    },
    doBuy() {
      Swal("Hello world!");
    },
    getQueryString(name) {
      var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
      var r = location.search.substr(1).match(reg);
      if (r != null) return unescape(r[2]);
      return null;
    }
  }
};
</script>


<style>
.product-info img {
  width: 100%;
  height: auto;
}

.product-info .block {
  margin-top: 0.3rem;
  text-align: left;
  padding: 0.2rem;
  background: #fff;
}

.product-info .price {
}
.product-info .price .desc {
  color: #ccc;
}
.product-info .price span {
  color: #ff0000;
}
.product-info .price p {
  height: 1.2rem;
  line-height: 1.2rem;
}

.product .buttons {
  height: 1.5rem;
  line-height: 1.5rem;
  position: fixed;
  bottom: 0px;
  background: #fff;
  width: 100%;
  display: flex;
}
.product .buttons a.home {
  width: 10%;
  text-align: center;
  display: inline-block;
}
.product .buttons a.btn {
  width: 45%;
  text-align: center;
  display: inline-block;
  background: #ff00fb;
  color: #fff;
}

.product .buttons a.left {
  background: #faaef9 !important;
}

.product h2 {
  height: 1rem;

  padding-left: 0.3rem;
  font-size: 0.8rem;
  margin-top: 0.5rem;
  margin-bottom: 0.5rem;
}

.product h2.title {
  text-align: left;
  border-left: 0.2rem #ff00fb solid;
}

.product .detial {
  background: #fff;
  width: 100%;
}

.product .detial ul {
  padding-top: 0.3rem;
  padding-bottom: 0.3rem;
}

.product .detial ul li {
  width: 100%;
  display: flex;
  line-height: 1.3rem;
  height: 1.3rem;
  margin-top: 0.5rem;
}
.product .detial ul li label {
  width: 20%;
  text-align: right;
}
.product .detial ul li div {
  width: 80%;
}
.product .detial ul li div input,
.product .detial ul li div textarea {
  width: 95%;
  height: 100%;
  border: 0.05rem #ccc solid;

  border-radius: 3px;
}
.product .detial ul li div textarea {
  height: 3rem;
}

.product .detial ul li.multiLine {
  height: 3rem;
}

.deliveray-desc {
  background: #fff;
  line-height: 1rem;
  margin-bottom: 0.5rem;
  color: #f00;
}

.bottom-space {
  height: 2rem;
}
</style>
