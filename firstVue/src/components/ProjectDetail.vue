<template>
    <div class="project-detail" v-title="'项目明细'">
        <header>
            <SearchBox></SearchBox>
        </header>
        <div class="content">
            <div class="left">
                <img src="../assets/none.jpg" />
            </div>
            <div class="right">
                <div class="title">{{detail==null?'':detail.Name}}</div>
                <div class="short-desc">{{detail==null?'':detail.ShorDesc}}</div>
                <div class="price">预付款：{{detail==null?'':detail.Imprest}}</div>
            </div>
           
            <div class="desc">
                <h2>介绍</h2>
                <p v-html="detail==null?'':formatHtml(detail.Description)"></p>
            </div>
             <div class="clr"></div>
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
import SearchBox from './SearchBox';
import { mapGetters } from 'vuex'

export default {
    data() {
        return {
            projectId:0,
            commentsCount: 100,
            comments: []
        }
    },
    computed: mapGetters({
        detail: 'ProjectDetail'
    }),
    components: { SearchBox },
    created() {

        //检查参数是否完整
        let projectId = this.$route.query.id;
        if (!projectId && typeof projectId != 'number') {
            let msg = encodeURI('抱歉！您访问的页面走丢了。');
            this.$router.replace('error/' + msg + '');

        }
        else{
            this.$set(this.$data,'projectId',projectId);
            this.$store.dispatch('queryProjectsDetail',projectId);
        }

    },
    methods:{
        formatHtml:function(html){

            return unescape(html);
        }

    }
}
</script>


<style scoped lang="less">
@import '../assets/index.less';

.project-detail {
    width: 100%;
    height: 100%;
    background: #fff;
}

.project-detail h1 {
    margin: 0px;
    padding: 0px;
    line-height: 35px;
    font-size: @h1-font-size;
    color: @h1-font-color;
    font-family: 'Microsoft Yahei';
    font-weight: normal;
    text-align: left;
    text-indent: 10px;
    border-bottom: 1px @project-detail-border-color solid;
}

.project-detail .content,
.project-detail .comments,
.project-detail .related {
    background: @project-detail-bg;
    border-bottom: 1px @project-detail-border-color solid;
    margin-top: 8px;
    clear: both;
}

.project-detail .content {height: auto;}
.project-detail .content .left{width: 35%; float: left; padding-top: 10px;}
.project-detail .content .left img{width: 90%; margin: auto; }
.project-detail .content .right{width: 65%; float:left; padding-top: 10px; text-align: left;}
.project-detail .content .right .title{height: 25px;color:@project-detail-content-title;}
.project-detail .content .right .short-desc{height: 40px; color:@project-detail-content-subtitle;}
.project-detail .content .right .price{height: 25px; color: @project-detail-content-hot;}
.project-detail .content .desc{width: 95%; margin-top: 10px; margin: auto;}
.project-detail .content .desc h2{font-weight: normal; font-size: 14px; border-bottom:1px  @project-detail-border-color dashed; margin: 0px; padding: 0px; clear: both; line-height: 35px; text-align: left}
.project-detail .content .desc p{text-align: left; line-height: 25px; font-size: 12px; color :#666;}

.project-detail .comments .more {
    height: @project-detail-row-height;
    line-height: @project-detail-row-height;
    text-align: center;
    border-top: 1px @project-detail-border-color solid;
    color: @font-hot-color;
}

.project-detail .comments .msg {
    line-height: @project-detail-row-height;
}

.project-detail header {
    width: 100%;
    height: @project-detail-header-height;
}

.project-detail footer {
    width: 100%;
    height: @project-detail-footer-height;
    line-height: @project-detail-footer-height;
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





