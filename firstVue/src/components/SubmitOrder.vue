<template>
    <div v-title="'提交订单'" class="submitorder">
        <header class="bd1">美丽预约</header>
       <div class="contact-info">
           <ul>
               <li>
                   <label for="">联系人</label>
                   <input type="text" placeholder="请输入联系人" v-model="contactInfo.contactor" /></li>
               <li>
                   <label for="">联系电话</label>
                   <input type="text" placeholder="请输入联系电话" v-model="contactInfo.phoneNum" /></li>               
           </ul>
           <div class="calendar" v-if="calendar">
               <div class="header">{{calendar.year}}年{{calendar.month}}月 <a class="next-month" @click="chooseNextMonth()">下个月></a></div>
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
                       <span :class="{'active':selectedDate==day}" v-for="(day,index) in calendar.days" :key="day" v-html="day" @click="chooseDate(day)"></span>
                   </div>
               </div>
           </div>
       </div>
        <footer>
            <span class="price">支付定金：<span>￥&nbsp;</span><span>{{contactInfo.bookFee}}</span>&nbsp;&nbsp;元</span>
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
          contactInfo:{contactor:'',phoneNum:'',bookDate:'',bookFee:0}
      }
  },
    computed: {
        ...mapGetters({
            detail: 'SubmitProjectDetail',
            user:'UserInfo'
        }),
        selectedDate:function() {
            let day = new Date().getDate();
            if(!this.contactInfo.bookDate){
                return day;
            }
            return new Date(this.contactInfo.bookDate).getDate()
        }
    },
  created(){
      this.initCalendar();
     
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
    },
    initCalendar:function() {
        let date = new Date();
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
        
    },
    // 选择日期
    chooseDate:function(day) {
        if(day=='&nbsp;') return;
        let selectDate = this.calendar.year+'-'+this.calendar.month+'-'+day;
        this.contactInfo.bookDate=selectDate;
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
  margin-bottom: .5rem;
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
.submitorder .contact-info ul li  label{
    width: 6rem;
    text-align: left;
    text-indent: .6rem;
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
  text-align: left;
  text-indent: 10px;
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
  width: 14.56%;
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
  height: @submitorder-lineheight;
  line-height: @submitorder-lineheight;
  display: block;
  float: left;
  font-size: @submitorder-font-content;
  margin-left: 10px;
}
</style>



