

<template>
  <div class="dialog" v-if="isShow" >
    <div class="mask"></div>
    <div class="dialogbody">
        <div class="body" :style="{width:width}">
            <div class="title">
                <span>{{title}}</span>
                <a class="close" @click="close()">X</a>
            </div>
            <div class="content">
               {{message}}
            </div>
            <div class='footer'>
                <a  v-for="item in buttons" :key="item" @click="callback(item.callback)">{{item.name}}</a>
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import Vue from 'vue'
export default {
  props: {   
    width: {
      type: String,
      default: "350px"
    }
  },
  data() {
    return {
        title:'系统消息',
        isShow:false,
        message:'hello world',
        buttons:[]
    };
  },
  methods:{
      show(option){
          
          if(option){
             this.title = option.title
             this.message=option.message
          } 
           this.isShow=true;

      },
      confirm(){
        if(option){
             this.title = option.title
             this.message=option.message
             this.buttons = option.buttons
          } 
           this.isShow=true;
      },
      close(){          
           this.isShow=false;
      },
      callback(call){
          if(call && typeof(call)=='function'){
              call();
          }
      }
  }

};
</script>



<style scoped>
.dialog {
  width: 100%;
  height: 100%;
  margin: 0px;
  padding: 0px;
  position: absolute;
  left: 0px;
  top: 0px;
}

.dialog .mask {
  width: 100%;
  height: 100%;
  background: #666;
  opacity: 0.5;
}
.dialog .dialogbody {
  position: absolute;
  left: 0px;
  top: 0px;
  width: 100%;
  height: 100%;
}
.dialog .dialogbody .body {
  border: 1px #ccc solid;
  border-radius: 5px;
  background: #fff;
  margin: auto;
  margin-top: 15%;
  min-width: 350px;
  min-height: 100px;
  height: auto;
}
.dialog .dialogbody .body .title {
  height: 30px;
  border-bottom: 1px #ccc solid;
  text-align: left;
  text-indent: 15px;
  background: #f0f0f0;
  line-height: 30px;
  display: block;
}
.dialog .dialogbody .body .title .close {
  float: right;
  display: block;
  width: 20px;
  height: 20px;
  margin: 5px;
  text-align: center;
  line-height: 20px;
  text-indent: 0px;
  cursor: pointer;
  color: #999;
}
.dialog .dialogbody .body .title .close:hover{
    color:#f60;
}
.dialog .dialogbody .body .content{
    width: 100%;
    line-height: 30px;
    min-height: 90px;
    height: auto;
    display: block;
}
.dialog .dialogbody .body .footer{
    width: 100%;
    line-height: 35px;
    border-top:1px #ccc solid;
    display: block;
    clear: both;
}
.dialog .dialogbody .body .footer a{
    display: inline-block;
    min-width: 45px;
    height: 20px;
    border:1px #f5b9f5 solid;
    border-radius: 3px;
    background: #f5b9f5;
    color: #fff;
    line-height: 20px;
    margin: 0px 8px;
    cursor: pointer;
}
</style>
