<template>
  <div>
    <vue-dialog  ref="dialog" ></vue-dialog>
    <h1 class='content-title'>客户预约</h1>
    <div class="content-aciton-bar">
      <button @click="getNewSubscribers">新预约</button>
      <button @click="getSuccessSubscribers">预约成功</button>
      <button @click="getFailSubscribers">已完成</button>
    </div>
    <table class="content-datagrid">
      <colgroup>
        <col style='width:35px;' />
        <col style='width:200px;' />
        <col style='width:80px;' />
        <col style='width:80px;' />
        <col style='width:80px;' />
        <col style='width:175px;' />
        <col style='width:auto;' />
      </colgroup>
      <thead>
        <tr>
          <th>序号</th>
          <th>客户</th>
          <th>提交日期</th>
          <th>预约日期</th>
          <th>预付款</th>
          <th>操作</th>
          <th>&nbsp;</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for='(item,i) in list' :key="item">
          <td>{{i+1}}</td>
          <td>{{item.Name}}</td>
          <td>提交日期</td>
          <td>预约日期</td>
          <td>预付款</td>
          <td class="buttons">
            <a @click="acceptOrder">受理</a>
            <a @click="cancelOrder">取消</a>
            <a @click="refuseOrder">拒绝</a>
            <a @click="payOrder">付款</a>
          </td>
          <td>&nbsp;</td>
        </tr>
      </tbody>
      <tfoot>
        <tr>
          <td colspan="7">
            <a>上一页</a>
            <a>下一页</a>
            <span>第1页</span>
            <span>共10页</span>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>


<script>
import * as constant from '../store/constant'
import { mapGetters } from 'vuex'
import VueDialog from './Common/dialog'
export default {
  data() {
    return {
      
    }
  },
  components: { VueDialog },
  computed: mapGetters({
    list: 'SubscribersList'
  }),
  mounted() {
    this.$store.dispatch('getSubscribers', constant.SubscriberStatus.All);
  },
  methods: {
    getNewSubscribers: function () {
      this.$store.dispatch('getSubscribers', constant.SubscriberStatus.New);
    },
    getSuccessSubscribers: function () {
      this.$store.dispatch('getSubscribers', constant.SubscriberStatus.SubscriberSuccess);
    },
    getFailSubscribers: function () {
      this.$store.dispatch('getSubscribers', constant.SubscriberStatus.SubscriberFail);
    },
    showDialog(option){
      this.$refs.dialog.show(option);
    },
    acceptOrder(){
      let _this = this;
      let option={
        title:'预约受理',
        message:'是否确认受理预约',
        buttons:[
          {name:'确认',
            callback:function(){
             //TODO
            }},
          {name:'取消',
            callback:function(){
               _this.$refs.dialog.close();
            }}
        ]
      }   
      this.showDialog(option)  
    },
    cancelOrder(){
      let _this = this;
      let option={
        title:'取消预约',
        message:'是否确认取消预约',
        buttons:[
          {name:'确认',
            callback:function(){
             //TODO
            }},
          {name:'取消',
            callback:function(){
               _this.$refs.dialog.close();
            }}
        ]
      }
      this.showDialog(option)  
    },
    refuseOrder(){
      let _this = this;
      let option={
        title:'拒绝预约',
        message:'是否确认拒绝预约',
        buttons:[
          {name:'确认',
            callback:function(){
             //TODO
            }},
          {name:'取消',
            callback:function(){
               _this.$refs.dialog.close();
            }}
        ]
      }
      this.showDialog(option)  
    },
    payOrder(){
      
    }
  }
}
</script>


<style scoped>
.buttons a{display:inline-block; min-width: 35px; cursor: pointer;background: #f5b9f5;border-radius: 3px; border: 1px #f5b9f5 solid; color:#fff;}
.buttons a:hover{background: #f5b9f5;border-radius: 3px; border: 1px #f00 solid; color:#fff;}
</style>

