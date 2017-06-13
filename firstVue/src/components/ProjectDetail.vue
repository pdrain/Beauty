<template>
    <div class="project-detail" v-title="'项目明细'">
        <header>
            <SearchBox></SearchBox>
        </header>
        <div class="content"></div>
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
import SearchBox from './SearchBox';

export default {
    data() {
        return {
            projectId:0,
            commentsCount: 100,
            comments: []
        }
    },
    components: { SearchBox },
    created(){
      //检查参数是否完整
      let projectId=this.$route.query.id;
      if(!projectId && typeof projectId !='number'){
         
            //this.$router.go({ name: 'error', params: { msg: 'ssssss' }})
            let msg=encodeURI('抱歉！您访问的页面走丢了。');
            this.$router.replace('error/'+msg+'');
           
      }
      else{
          this.$set(this.$data,'projectId',projectId);
      }
  },
}
</script>


<style scoped lang="less">
@import '../assets/index.less';

.project-detail{width: 100%; height: 100%; background: #fff;}
.project-detail h1{margin: 0px; padding: 0px; line-height: 35px;font-size: @h1-font-size; color:@h1-font-color; font-family: 'Microsoft Yahei'; font-weight: normal; text-align: left;text-indent: 10px; border-bottom:1px @project-detail-border-color solid;}
.project-detail .content,.project-detail .comments,.project-detail  .related{background: @project-detail-bg; border-bottom: 1px  @project-detail-border-color solid; margin-top: 8px;}
.project-detail .comments .more{ height: @project-detail-row-height;line-height: @project-detail-row-height; text-align: center; border-top: 1px @project-detail-border-color solid; color:@font-hot-color;}
.project-detail .comments .msg{line-height: @project-detail-row-height;}
.project-detail header{width: 100%; height: @project-detail-header-height; }
.project-detail footer{width: 100%; height: @project-detail-footer-height; line-height: @project-detail-footer-height;  background: @project-detail-footer-bg; position: fixed;bottom: 0px; border-top:1px @project-detail-footer-border-color solid;}
.project-detail footer a{height: 100%; min-width: 80px; display: inline-block; text-decoration: none;}
.project-detail footer a.menu{color:@project-detail-menu-fontcolor; float: left;}
.project-detail footer a.subscriber{background: @project-detail-button-bgcolor; color:@project-detail-button-fontcolor; float: right;}
</style>





