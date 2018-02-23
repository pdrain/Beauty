import Vue from 'vue'
import VueRouter from 'vue-router'

import store from '../store'
import axios from '../http'

import WX from '../config/WeXin'

/*
import Login from '../components/Login'
import Projects from '../components/Projects'
import ProjectsDetail from '../components/ProjectDetail'
import Shop from '../components/Shop'
import User from '../components/User'
import UserInfo from '../components/UserInfo'
import MyPoints from '../components/MyPoints'
import MySubscribers from '../components/MySubscribers'
import ErrorPage from '../components/Error'
import SubmitOrder from '../components/SubmitOrder'
*/

//异步组件
const Login = resolve => require(['../components/Login'], resolve)
const Projects = resolve => require(['../components/Projects'], resolve)
const ProjectsDetail = resolve => require(['../components/ProjectDetail'], resolve)
const Shop = resolve => require(['../components/Shop'], resolve)
const User = resolve => require(['../components/User'], resolve)
const UserInfo = resolve => require(['../components/UserInfo'], resolve)
const MyPoints = resolve => require(['../components/MyPoints'], resolve)
const MySubscribers = resolve => require(['../components/MySubscribers'], resolve)
const MyOrders = resolve => require(['../components/MyOrders'], resolve)
const Coupon = resolve => require(['../components/Coupon'], resolve)
const ErrorPage = resolve => require(['../components/Error'], resolve)
const SubmitOrder = resolve => require(['../components/SubmitOrder'], resolve)
const Dictionray = resolve => require(['../components/Dictionary'], resolve)
const DictionrayArticle = resolve => require(['../components/Article'], resolve)

const AboutUs = resolve => require(['../components/AboutUs'], resolve)
const Upgrade = resolve => require(['../components/Upgrade'], resolve)

const PartnerHospital = resolve => require(['../components/partner-hospital'], resolve)
const PartnerHospitalDetail = resolve => require(['../components/partner-hospital-detail'], resolve)


const NotFontPage = resolve => require(['../components/404'], resolve)



Vue.use(VueRouter)


const router = new VueRouter({
    hashbang: true,
    history: true,
    //mode:'history',
    saveScrollPosition: false,
    routes: [
        { path: '/login', component: Login },
        { path: '/projects', component: Projects },
        { path: '/projects-detail', component: ProjectsDetail },
        { path: '/submitorder', component: SubmitOrder },
        { path: '/shop', component: Shop },

        { path: '/user', component: User, meta: { requireAuth: true, } },// 添加该字段，表示进入这个路由是需要登录的
        { path: '/user/info', component: UserInfo },
        { path: '/user/mypoints', component: MyPoints },
        { path: '/user/mysubscribers', component: MySubscribers },
        { path: '/user/myorders', component: MyOrders },
        { path: '/user/aboutus', component: AboutUs },
        { path: '/user/upgrade', component: Upgrade },
        { path: '/user/coupon', component: Coupon },
        { path:'/partner-hospital',component:PartnerHospital},
        { path:'/partner-hospital-detail',component:PartnerHospitalDetail},
        

        { path: '/dict', component: Dictionray },
        { path: '/dict/article', component: DictionrayArticle },
        { path: '/error/:msg', component: ErrorPage },
        { path: '/404', component: NotFontPage },
        { path: '/', redirect: '/404' }

    ],

});


router.beforeEach((to, from, next) => {
    next()
    return

    let ua = window.navigator.userAgent.toLowerCase();
    if (ua.indexOf('micromessenger') == -1) {
        location.href = 'https://open.weixin.qq.com/connect/oauth2/authorize?appid=APPID&redirect_uri=REDIRECT_URI&response_type=code&scope=SCOPE&state=STATE#wechat_redirect'
    }

    console.log(to.meta.requireAuth)
    if (to.meta.requireAuth) {  // 判断该路由是否需要登录权限)
        console.log(2)
        let token_code = from.query.code;
        if (token_code) {
            to.query.code = token_code
            next()
        } else {
            new WX('http://www.meilituibian.cn/#/user').doAuth()
        }
    }
    next();

})



export default router;
