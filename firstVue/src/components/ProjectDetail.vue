<template>
    <div class="project-detail" v-title="'项目明细'">
      <img class="banner" src="../assets/banner-1.jpg" />
        <header class=" bd1">
            
             <h1>{{detail.categoryName}}</h1>
            <!-- <div class="title">
                <span class="fl">项目：{{ detail.ParentName}}</span>
                <span class="fr">200 人预定</span>
            </div> -->
            
             <p class="desc" v-html="formatHtml(detail.shortDesc)"></p>
           
            <div class="title price">
                <span class="fl">美丽价格：¥{{detail.minPrice}} - {{detail.maxPrice}}</span>
                <span class="fr">200 人预定</span>
            </div>
        </header>
        <div class="content">
          <div class="desc bd1">
              <h2>介绍</h2>
             <p v-html="formatHtml(detail.detail)"></p>
              <section class="archive">
                <div class="title">小档案</div>
                <ul class="items">
                  <li>
                    <label for="">安全等级：</label>
                    <span>2222</span>
                  </li>
                  <li>
                    <label for="">复杂度：</label>
                    <span>3333</span>
                  </li>
                  <li>
                    <label for="">手术：</label>
                    <span>
                      <a v-for="(item,index) in operation" :key="index">{{item.name}}：{{item.value}}</a>
                    </span>
                  </li>
                  <li>
                    <label for="">治疗：</label>
                    <span><a v-for="(item,index) in treatment" :key="index">{{item.name}}：{{item.value}}</a></span>
                  </li>
                  <li>
                    <label for="">康复：</label>
                    <span><a v-for="(item,index) in recure" :key="index">{{item.name}}：{{item.value}}</a></span>
                  </li>
                  <!-- <li>
                    <label for="">优点：</label>
                    <span><a v-for="(item,index) in advantage" :key="index">{{item.name}}</a></span>
                  </li>
                   <li>
                    <label for="">缺点：</label>
                    <span><a v-for="(item,index) in disadvantage" :key="index">{{item.name}}</a></span>
                  </li> -->
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
            <h2>评论({{commentsCount}})</h2>
            <div v-if="comments.length==0" class="msg">暂无评论</div>
            <div v-if="comments.length>0">
                <div class="item"></div>
                <div class="more">查看更多评论</div>
            </div>
        </div>
        <div class="related">
            <h2>相关美丽项目</h2>
            <div class="item"></div>
            <div class='items'>
              暂时无相关项目
            </div>
        </div>
        <footer>
            <router-link class="menu" :to="{ path: '/'}">首页</router-link>
            <a class="subscriber" @click="goSubscriber">马上预约</a>
        </footer>
    </div>
</template>



<script>
import { mapGetters } from "vuex";
import wx from  '../config/WeXin'

export default {
  data() {
    return {
      projectId: 0,
      commentsCount: 100,
      comments: [],
      detail: {},
      operation: {}, //手术
      treatment: {}, //治疗
      recure: {}, //康复
      advantage: {}, //优点
      disadvantage: {}, //缺点
      hospital: [] //合作医院
    };
  },
  created() {
    let _this = this;
    //检查参数是否完整
    let projectId = this.$route.query.id;
    this.projectId = projectId;
    if (!projectId && typeof projectId != "number") {
      let msg = encodeURI("抱歉！您访问的页面走丢了。");
      _this.$router.replace("error/" + msg + "");
    } else {
      _this.$store
        .dispatch("queryProjectsDetail", projectId)
        .then(function(data) {
          _this.detail = data;
          _this.operation = _this.extractItems(JSON.parse(data.operation)); //手术
          _this.treatment = _this.extractItems(JSON.parse(data.treatment)); //治疗
          _this.recure = _this.extractItems(JSON.parse(data.recure)); //康复
          _this.advantage = _this.extractItems(JSON.parse(data.advantage)); //优点
          _this.disadvantage = _this.extractItems(
            JSON.parse(data.disadvantage)
          ); //缺点
        });
    }

    _this.initShareInfo();
  },
  mounted() {},
  methods: {
    initShareInfo() {
      let shareOpt = {
        title: "医美改变人生",
        desc: "双眼皮、隆鼻、瘦脸、美胸一切就是那么简单"
      };
      wx.initShare(shareOpt);
    },
    formatHtml: function(html) {
      return unescape(html);
    },
    extractItems: function(items) {
      let list = [];
      if (!items) return list;
      items.forEach(function(item) {
        if (typeof item == "object") {
          for (var p in item) {
            list.push({ name: p, value: item[p] });
          }
        } else {
          list.push(item);
        }
      });
      return list;
    },
    goSubscriber: function() {
      this.$router.push("/submitorder/?projectId=" + this.projectId);
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
  min-height: 5.5rem;
  margin-bottom: 0.5rem;
  margin-top: -0.3rem;
  padding-left: 0.6rem;
  padding-right: 0.6rem;
  padding-top: 1rem;
  background: #fff;
  padding-bottom: 0.3rem;
}
.project-detail header .desc {
  padding-top: 0.3rem;
  padding-bottom: 0.3rem;
  text-align: left;
  text-indent: 1rem;
}

.project-detail img.banner {
  width: 100%;
  height: 6rem;
}

.project-detail h1,
.project-detail h2 {
  margin: 0px;
  padding: 0px;
  line-height: 35px;
  font-size: @h1-font-size;
  color: @h1-font-color;
  font-family: "Microsoft Yahei";
  font-weight: normal;
  text-align: left;
}

.project-detail h2 {
  font-size: @h2-font-size;
  color: @h2-font-color;
  border-bottom: 1px #ccc dashed;
  margin-bottom: 0.5rem;
  padding-bottom: 0.3rem;
  padding-top: 0.3rem;
}

.project-detail .title {
  height: 1.6rem;
  line-height: 1.6rem;

  box-sizing: border-box;
}

.project-detail .content,
.project-detail .comments,
.project-detail .related {
  padding-left: 0.6rem;
  padding-right: 0.6rem;
  line-height: 1.1rem;
  text-align: left;
  margin-bottom: 0.8rem;
  background: #fff;
}

.project-detail .desc {
  margin-bottom: 0.6rem;
  padding-bottom: 1rem;
}
.project-detail .desc .archive {
  width: 100%;
  margin-top: 2rem;
}
.project-detail .desc .archive .title {
  height: 2rem;
  line-height: 2rem;
  text-align: center;
}
.project-detail .desc .archive li {
  min-height: 1.5rem;
  line-height: 1.5rem;
  display: flex;
  border-bottom: 1px @border-normal-color solid;
}
.project-detail .desc .archive li:first-child {
  border-top: 1px @border-normal-color solid;
}
.project-detail .desc .archive li label {
  border-right: 1px @border-normal-color solid;
  width: 25%;
  // height: 100%;
  text-align: right;
  padding: 0rem 0.5rem;
}

.project-detail .desc .archive li span {
  width: 75%;
  // height: 100%;
  text-align: left;
  padding: 0rem 0.5rem;
}
.project-detail .desc .archive li span a {
  display: block;
}

.project-detail .related {
  margin-bottom: 4rem;
}
.project-detail .related .items {
  min-heitht: 1.5rem;
  line-height: 1.5rem;
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





