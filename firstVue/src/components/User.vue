<template>
    <div v-title="'用户中心'" class="usercenter">
        <header>
            <div class="nick">张三</div>
            <div class="icon">
                <img src="" />
            </div>
        </header>
        <table>
            <tr>
                <td>评论</td>
                <td>赞</td>
                <td>私信</td>
                <td>通知</td>
            </tr>
        </table>
        <table>
            <tr>
                <td>我的订单</td>
                <td>我的预约</td>
                <td>我的积分</td>
                <td>优惠券</td>
            </tr>
            <tr>
                <td>用户保障</td>
                <td>客服中心</td>
                <td>关于我们</td>
                <td>我要升级</td>
            </tr>
        </table>

        <div class="adv">
            广告
        </div>

        <div class="bottom-menu">
            <a>发现</a>
            <a>项目</a>
            <a>商城</a>
            <a>我</a>
        </div>
    </div>
    
    <!--           
               </div>
            
                    <ul>
                        <li class="mypoint">
                            <router-link v-bind:to="'/user/info'">基本资料</router-link>
                        </li>
                        <li class="vip">
                            <router-link v-bind:to="'/user/mypoints'">我的积分</router-link>
                        </li>
                        <li class="subscriber">
                            <router-link v-bind:to="'/user/mysubscribers'">我的预约</router-link>
                        </li>
                    </ul>
                </div>-->
</template>



<script  type="application/ecmascript">

import * as types from '../store/types'
import UserHeader from './UserHeader'


export default {
    components: { UserHeader },
    data() {
        return {
            msg: 'Welcome to User Center!'

        }

    },
    mounted() {
    },
    methods: {
    }

}

</script>


<style scoped lang="less">
@import '../assets/index.less';

header {
    height: 120px;
    width: 100%;
    text-align: center;
    border-bottom: @user-border-color;
    background: @user-header-bg;
}

header .nick {
    width: 100%;
    height: 35px;
    line-height: 35px;
}

header .img {
    width: 40px;
    height: 40px;
    vertical-align: middle;
}

.usercenter {
    width: 100%;
    height: 100%;
  
}

.usercenter table {
    background: @user-border-color;
    width: 100%;
    border-spacing: 1px;
    border-collapse: separate;
    margin-bottom: 8px;
}

.usercenter table td {
    width: @user-item-width;
    vertical-align: top;
    background: @user-bg;
    height: 80px;
}




.usercenter ul li a {
    text-decoration: none;
    color: @font-normal-color;
    width: 100%;
    text-align: left;
    display: inline-block;
}

.usercenter .adv{width: 100%; height: 100px; background: @user-bg;}

.bottom-menu{width: 100%; height: @bottom-menu-height; line-height: @bottom-menu-height;  border-top:1px solid @bottom-menu-border;background: @bottom-menu-bg; color:@bottom-menu-normalcolor; position: fixed; bottom:0px}
.bottom-menu a{display: block; float: left; width:@bottom-menu-item-width; text-align: center;}
</style>