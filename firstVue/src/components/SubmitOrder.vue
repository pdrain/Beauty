<template>
    <div v-title="'提交订单'" class="submitorder">
        <div class="content">
            <div class="left">
                <img src="../assets/none.jpg" />
            </div>
            <div class="right">
                <div class="title">{{detail==null?'':detail.Name}}</div>
                <div class="desc">{{detail==null?'':detail.ShorDesc}}</div>
                <div class="price">预付款：￥{{detail==null?'':detail.Imprest}}</div>
            </div>
        </div>
        <div class="service-package"><label class="title">服务包</label><span class="info">暂无其他服务</span></div>
        <div class="split-pay"><label class="title">尾款分期付款</label><span class="info">暂不支持分期</span></div>
        <div class="salesoff">
            <ul>
                <li><label class="title">美容券</label><span class="info">暂无优惠券</span></li>
            </ul>
        </div>
        <div class="contact">
            <ul>                
                <li><label class="title">联系人</label><input type="text" v-model="user.contactor"/></li>
                <li><label class="title">联系手机</label><input type="text" v-model="user.mobile"/></li>
                <li><label class="title">介绍人手机</label><input type="text" v-model="user.intrudcer"/></li>
            </ul>
        </div>
        <div class="remark">*请填写正确的介绍人手机，可以获取介绍人专属优惠。</div>
        <footer>
            <span class="price">预付款：￥{{detail==null?'':detail.Imprest}}</span>
            <button @click="submitOrder">提交订单</button>
        </footer>
    </div>
</template>

<<script>
import { mapGetters } from 'vuex'

export default {
  data(){
      return {
          projectId:0
      }
  },
    computed: mapGetters({
        detail: 'SubmitProjectDetail',
        user:'UserInfo'
  }),
  created(){
     
     //检查参数是否完整
      let projectId=this.$route.query.projectId;
      if(!projectId && typeof projectId !='number'){  
            let msg=encodeURI('抱歉！您访问的页面走丢了。');
            this.$router.replace('error/'+msg+'');
           
      }
      else{
          this.$set(this.$data,'projectId',projectId);
           this.$store.dispatch('querySubmitProjectsDetail',projectId);
           this.$store.dispatch('getUserInfo',1);
        
      }

    
  },
  methods:{
    submitOrder:function () {
         this.$store.dispatch('submitOrder');
    }

  }
}
</script>



<style lang="less">
@import '../assets/index.less';

.submitorder{width: 100%;height: 100%; }
.submitorder .content{height: 110px; border-bottom:1px @submitorder-border solid; background: @submitorder-bg;}
.submitorder .left{width: 35%; height: 100%; float: left;}
.submitorder .left img{width: 90%; margin: auto; height: auto; padding-top: 10px;}
.submitorder .right{width: 65%; height: 100%; float: left; padding-top: 10px; text-align: left; line-height: @submitorder-small-lineheight;}
.submitorder .right .title{ font-size: @submitorder-titlefont; color:@submitorder-font-title-color}
.submitorder .right .desc{height: 45px; font-size: @submitorder-contentfont; color:@submitorder-font-content-color}
.submitorder .right .price{ font-size: @submitorder-contentfont;color:@submitorder-hotfont-color;}
.submitorder .service-package,.submitorder .split-pay,.submitorder .contact,.submitorder .salesoff{line-height: @submitorder-lineheight; text-align: left;  background: @submitorder-bg; margin-bottom: 10px; min-height: @submitorder-lineheight}
.submitorder .ervice-package{border-top:1px @submitorder-border solid;}
.submitorder label.title{color:@submitorder-font-title-color; font-size: @submitorder-font-title; margin-left: 10px;}
.submitorder span.info{float:right;color:@submitorder-font-content-color; font-size: @submitorder-font-content; margin-right: 10px;}
.submitorder .contact input[type='text']{float: right; width: 120px; height: 20px; line-height: 20px; margin-top: 5px; margin-right: 5px; border-radius: 10px; border:1px solid @submitorder-border; text-indent: 10px;}
.submitorder .contact ul ,.submitorder .salesoff ul{margin: 0px;padding: 0px;}
.submitorder .remark{width: 100%;  text-align: center; color:@submitorder-font-title-color;font-size: @submitorder-contentfont}


footer{width: 100%; height: @submitorder-lineheight; border-top:1px solid @submitorder-border; background: @submitorder-bg; position: fixed;bottom:0px;}
footer button{width: 100px; float: right; line-height:  @submitorder-lineheight; border:0px; background: @submitorder-button-bgcolor; color:@submitorder-button-color;}
footer .price{height:@submitorder-lineheight; line-height:  @submitorder-lineheight;display: block; float: left;  font-size:  @submitorder-font-content; margin-left: 10px }
</style>



