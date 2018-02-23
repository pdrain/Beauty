<template>
    <div class="project-detail" v-title="'项目明细'">
      <img class="banner" src="../assets/banner-1.jpg" />
        <header class=" bd1">
            
             <h1>{{detail ==null?'': detail.Name}}</h1>
            <div class="title">
                <span class="fl">项目：{{detail ==null?'': detail.ParentName}}</span>
                <span class="fr">{{detail ==null?'': detail.BookNum}}人预定</span>
            </div>
        </header>
        <div class="content">
          <div class="desc bd1">
              <h2>介绍</h2>
              <p v-html="detail==null?'':formatHtml(detail.Description)"></p>
              <section class="archive">
                <div class="title">XXX小档案</div>
                <ul class="items">
                  <li>
                    <label for="">1</label>
                    <span>2222</span>
                  </li>
                  <li>
                    <label for="">1</label>
                    <span>3333</span>
                  </li>
                </ul>
              </section>

          </div>
          <section>
              
              <h2>预约须知</h2>
              <div>
                <p>预约需要支付98元的定金</p>
                <p>预约成功后，客服将在24小时内联系您确认预约事项</p>
                <p>预约消费后，定金将从订单费用中抵扣</p>
                <br>
              </div>
          </section>
          <section v-if="hospital">
              
              <h2>医院介绍</h2>
              <div>
                {{hospital.Name}}
                <br>
              </div>
          </section>
        </div>
        <div class="comments">
            <h1>评论({{commentsCount}})</h1>
            <div v-if="comments.length==0" class="msg">暂无评论</div>
            <div v-if="comments.length>0">
                <div class="item"></div>
                <div class="more">查看更多评论</div>
            </div>
        </div>
        <div class="related">
            <h1>相关美丽项目</h1>
            <div class="item"></div>
        </div>
        <footer>
            <router-link class="menu" :to="{ path: '/home'}">首页</router-link>
            <router-link class="subscriber" :to="{path:'/submitorder',query:{projectId:projectId}}">马上预约</router-link>
        </footer>
    </div>
</template>



<script>
import { mapGetters } from "vuex";

export default {
  data() {
    return {
      projectId: 0,
      commentsCount: 100,
      comments: []
    };
  },
  computed: mapGetters({
    detail: "ProjectDetail",
    hospital:"HospitalDetail"
  }),
  created() {
    //检查参数是否完整
    let projectId = this.$route.query.id;
    if (!projectId && typeof projectId != "number") {
      let msg = encodeURI("抱歉！您访问的页面走丢了。");
      this.$router.replace("error/" + msg + "");
    } else {
      this.$set(this.$data, "projectId", projectId);
      this.$store.dispatch("queryProjectsDetail", projectId);
      //let hospitalId = this.$route.query.hospitalId;
      //this.$store.dispatch("queryHospitalDetail",hospitalId)
    }
  },
  mounted(){
    
  },
  methods: {
    formatHtml: function(html) {
      return unescape(html);
    }
  }
};
</script>


<style scoped lang="less">
@import "../assets/index.less";

.project-detail {
  width: 100%;
  height: 100%;
  
}

.project-detail header {
  height: 4.5rem;
   margin-bottom:.5rem;
   margin-top: -.3rem;
   padding-left: .6rem;
  padding-right: .6rem;
  padding-top:1rem;
  background: #fff;
}

.project-detail  img.banner {
  width: 100%;
  height: 8rem;
  
}

.project-detail h1,.project-detail h2 {
  margin: 0px;
  padding: 0px;
  line-height: 35px;
  font-size: @h1-font-size;
  color: @h1-font-color;
  font-family: "Microsoft Yahei";
  font-weight: normal;
  text-align: left;
}

.project-detail h2{
    font-size: @h2-font-size;
    color: @h2-font-color;
    border-bottom: 1px #ccc dashed;
    margin-bottom:1rem;
}

.project-detail .title {
  height: 2.2rem;
  line-height: 2.2rem;
  
  box-sizing: border-box;
 
}

.project-detail .content,.project-detail .comments,.project-detail .related{
  padding-left: .6rem;
  padding-right: .6rem;
  line-height: 1.5rem;
  text-align: left;
  margin-bottom:.8rem;
  background: #fff;
}

.project-detail .desc{
  margin-bottom: .6rem;
  padding-bottom: 1rem;
}
.project-detail .desc .archive{
  width: 100%;
  margin-top:2rem;
}
.project-detail .desc .archive .title{
  height: 2rem;
  line-height: 2rem;
  text-align: center;
}
.project-detail .desc .archive li{
  height: 2rem;
  line-height: 2rem;
  display:flex;
  border-bottom:1px @border-normal-color solid;
}
.project-detail .desc .archive li:first-child{
  border-top:1px @border-normal-color solid;
}
.project-detail .desc .archive li label{
  border-right:1px @border-normal-color solid;
  width: 5rem;
  height: 100%;
  text-align: right;
  padding:0rem .5rem;
}

.project-detail .desc .archive li span{
  height: 100%;
  text-align: left;
  padding:0rem .5rem;
}
.project-detail .related{
  margin-bottom: 4rem;
}

.project-detail footer {
  width: 100%;
  height: @footer-height;
  line-height: @footer-height;
  background: @project-detail-footer-bg;
  position: fixed;
  bottom: 0px;
  border-top: 1px @project-detail-footer-border-color solid;
}

.project-detail footer a {
  height: 100%;
  min-width: 80px;
  display: inline-block;
  text-decoration: none;
}

.project-detail footer a.menu {
  color: @project-detail-menu-fontcolor;
  float: left;
}

.project-detail footer a.subscriber {
  background: @project-detail-button-bgcolor;
  color: @project-detail-button-fontcolor;
  float: right;
}
</style>





