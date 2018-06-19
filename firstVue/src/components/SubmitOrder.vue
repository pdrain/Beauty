<template>
    <div v-title="'提交订单'" class="submitorder">
        <header class="bd1">美丽预约</header>
       <div class="contact-info">
           <ul>
               <li>
                   <label for="">联系人</label>
                   <input type="text" placeholder="请输入联系人" v-model="order.userName" /></li>
               <li>
                   <label for="">联系电话</label>
                   <input type="text" placeholder="请输入联系电话" v-model="order.phone" /></li>    
                   <li>
                   <label for="">预约日期</label>
                   <input type="text" placeholder="请选择联系电话" v-model="order.subscribeDate" readonly/></li>            
           </ul>
           <div class="calendar" v-if="calendar">
               <div class="header"> <a class="pre-month" @click="choosePreMonth()">&lt;上个月</a>{{calendar.year}}年{{calendar.month}}月 <a class="next-month" @click="chooseNextMonth()">下个月&gt;</a></div>
               <div class="date">
                  <div class="title">
                       <span>日</span>
                       <span>一</span>
                       <span>二</span>
                       <span>三</span>
                       <span>四</span>
                       <span>五</span>
                       <span>六</span>
                  </div>
                  
                   <div class="days" >
                       <span :class="{'active':selectedDate==day}" v-for="(day,index) in calendar.days" :key="index" v-html="day" @click="chooseDate(day)"></span>
                   </div>
               </div>
           </div>
       </div>
        <footer>
            <!-- <span class="price">支付定金：<span>￥&nbsp;</span><span>{{contactInfo.bookFee}}</span>&nbsp;&nbsp;元</span> -->
            <router-link class="menu" :to="{ path: '/'}">首页</router-link>
            <span  class="price">预约后，我们将尽快联系您！</span>
            <button @click="submitOrder">提交订单</button>
        </footer>
    </div>
</template>

<<script>
import { mapGetters } from 'vuex'

export default {
  data(){
      return {
         
          projectId:0,
          calendar:{year:'',month:'',days:[ ]},
          order : {
            openId:'',
            parentOpenId:'',
            projectId:'',
            userName:'',
            projectName:'',
            phone:'',
            subscribeDate:''
        }
      }
  },
    computed: {
        ...mapGetters({
            detail: 'SubmitProjectDetail'
        }),
        selectedDate:function() {
            let _date = new Date();
            let day = _date.getDate();
            if(!_date){
                return day;
            }
            return new Date(this.order.subscribeDate).getDate()
        }
    },
  created(){
      let _this = this;

      _this.initCalendar();
     
     //检查参数是否完整
      _this.projectId   =this.$route.query.projectId;
      
      if(!_this.projectId && typeof _this.projectId !='number'){  
            let msg=encodeURI('抱歉！您访问的页面走丢了。');
            _this.$router.replace('error/'+msg+'');
      }
      else{
           _this.$store.dispatch('querySubmitProjectsDetail',_this.projectId).then(function(data){
                _this.order.projectId  = data.projectId;
                _this.order.projectName  = data.categoryName;
           });
      }

    
  },
  mounted(){
    //   let  user = JSON.parse(localStorage.getItem('userinfo'));
    //   this.order.openId=user.openid;
    //   this.order.userName=user.nickname,
  },
  methods:{
    submitOrder:function () {
        let _this = this;
        if(_this.order.subscribeDate==''){
            alert('预约日期不能为空。');
            return false;
        }
         if(_this.order.userName==''){
            alert('请填写预约联系人');
            return false;
        }
         if(_this.order.phone==''){
            alert('请填写预约联系电话。');
            return false;
        }
          let  user = JSON.parse(localStorage.getItem('userinfo'));
        _this.order.openId = user.openId;
        _this.order.parentOpenId = user.parent;
        //_this.order.userName = user.nickname;

         _this.$store.dispatch('submitOrder',_this.order).then(function (res) {
             alert('预约成功，即将返回首页。');
             _this.$router.push('/')
         });
    },
    initCalendar:function(datetime) {
        let date = new Date();
        if(datetime){
            date=datetime;
        }
        this.calendar.year = date.getFullYear()
        this.calendar.month = date.getMonth()+1;

        let firstDay = new Date(this.calendar.year,this.calendar.month,1)
        let lastDay = new Date(firstDay.getTime()-1000*60*60*24).getDate()

       
        for(let i=1; i<=lastDay;i++){
            if(i==1){
                let today = new Date().getDay()
                for(let d=1;d<today;d++ ){
                    this.calendar.days.push('&nbsp;')
                }
            }
            this.calendar.days.push(i)
        }
        let lastweekDay = new Date(this.calendar.year+'-'+this.calendar.month+'-'+lastDay).getDay();
        
        for(let d=lastweekDay;d<6;d++){
            this.calendar.days.push('&nbsp;')
        }
    },
    // 选择下个月
    chooseNextMonth:function() {
        var nextMonth=null;
        if(this.calendar.month===12){
            console.log(1)
            nextMonth = new Date((this.calendar.year+1)+'-01-01');
        }else{
            console.log(2)
             nextMonth = new Date(this.calendar.year+'-'+(this.calendar.month+1)+'-01');
        }
        console.log(this.calendar.month===12);
        
        this.calendar={year:'',month:'',days:[ ]};
        this.initCalendar(nextMonth);
        this.chooseDate(1);
    },
    // 选择上个月
    choosePreMonth:function() {
        var nextMonth=null;
        if(this.calendar.month===1){
            console.log(1)
            nextMonth = new Date((this.calendar.year-1)+'-12-01');
        }else{
            console.log(2)
             nextMonth = new Date(this.calendar.year+'-'+(this.calendar.month-1)+'-01');
        }
        console.log(this.calendar.month===12);
        
        this.calendar={year:'',month:'',days:[ ]};
        this.initCalendar(nextMonth);
        this.chooseDate(1);
    },
    // 选择日期
    chooseDate:function(day) {
        
        if(day=='&nbsp;') return;
        let selectDate = this.calendar.year+'-'+this.calendar.month+'-'+day;
        
        this.order.subscribeDate=selectDate;
        console.log(this.order.subscribeDate);
    }
  }
}
</script>



<style lang="less">
@import "../assets/index.less";

.submitorder {
  width: 100%;
  height: 100%;
}
.submitorder header {
  height: 4rem;
  line-height: 4rem;
  font-size: 2rem;
  background: #fff;
  margin-bottom: 0.5rem;
}
.submitorder .contact-info ul {
  width: 100%;
}
.submitorder .contact-info ul li {
  height: 35px;
  line-height: 35px;

  border-top: 1px #dad7d7 solid;
  background: #fff;
  display: flex;
}
.submitorder .contact-info ul li label {
  width: 6rem;
  text-align: left;
  text-indent: 0.6rem;
}

.submitorder .contact-info ul li:last-child {
  border-bottom: 1px #dad7d7 solid;
}
.submitorder .contact-info ul li input {
  width: 100%;
  box-sizing: border-box;
  height: 343x;
  line-height: 33px;
  text-indent: 10px;
  border: none;
}

.submitorder .calendar {
  width: 100%;
  background: #fff;
}
.submitorder .calendar .header {
  height: 35px;
  line-height: 35px;
  text-align: center;
  text-indent: 10px;
}
.submitorder .calendar .header .pre-month {
  float: left;
  margin-right: 8px;
}
.submitorder .calendar .header .next-month {
  float: right;
  margin-right: 8px;
}
.submitorder .calendar .date {
  width: 100%;
  border-spacing: 1px;
  background: #ccc;
}
.submitorder .calendar .date .title,
.submitorder .calendar .date .days {
  background: #fff;
  line-height: 35px;
}
.submitorder .calendar .date span {
  width: 14.54%;
  float: left;
  border: 1px #ccc solid;
  box-sizing: border-box;
  margin-left: -1px;
}

.submitorder .calendar .date .days span {
  background: #fff;
  margin-top: -1px;
}
.submitorder .calendar .date .days span.active {
  background: #fdaefc;
  color: #fff;
}

footer {
  width: 100%;
  border-top: 1px solid @submitorder-border;
  background: @submitorder-bg;
  height: @footer-height;
  line-height: @footer-height;
  position: fixed;
  bottom: 0px;
}
footer button {
  width: 100px;
  float: right;
  line-height: @submitorder-lineheight;
  border: 0px;
  background: @submitorder-button-bgcolor;
  color: @submitorder-button-color;
  border-radius: 0;
}
footer .price {
  height: 40px;
  line-height: 40px;
  display: block;
  float: left;
  font-size: @submitorder-font-content;
  margin-left: 10px;
}

footer a.menu {
  float: left;
  text-decoration: none;
  margin-left: 5px;
  color: #ff00fb;
  cursor: pointer;
}
</style>



