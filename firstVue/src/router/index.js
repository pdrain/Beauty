import Vue from 'vue'
import VueRouter from 'vue-router'

import store from '../store'
import axios from '../http'
import * as api from '../api'
import querystring from 'querystring'


import WX from '../config/WeXin'
import { mapGetters } from 'vuex'

import utils from "../utils";


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
const Home = resolve => require(['../components/Home'], resolve)
const Login = resolve => require(['../components/Login'], resolve)
const Projects = resolve => require(['../components/Projects'], resolve)
const ProjectsDetail = resolve => require(['../components/ProjectDetail'], resolve)
const Shop = resolve => require(['../components/Shop'], resolve)
const ProductExchange = resolve => require(['../components/product-exchange'], resolve)
const ProductDetail = resolve => require(['../components/product-detail'], resolve)

const User = resolve => require(['../components/User'], resolve)
const UserInfo = resolve => require(['../components/UserInfo'], resolve)
const MyPoints = resolve => require(['../components/MyPoints'], resolve)
const MySubscribers = resolve => require(['../components/MySubscribers'], resolve)
const MyOrders = resolve => require(['../components/MyOrders'], resolve)
const Coupon = resolve => require(['../components/Coupon'], resolve)
const Setting = resolve => require(['../components/setting'], resolve)
const ErrorPage = resolve => require(['../components/Error'], resolve)
const SubmitOrder = resolve => require(['../components/SubmitOrder'], resolve)
const Dictionray = resolve => require(['../components/Dictionary'], resolve)
const DictionrayArticle = resolve => require(['../components/Article'], resolve)

const AboutUs = resolve => require(['../components/AboutUs'], resolve)
const UserSerivce = resolve => require(['../components/user-service'], resolve)
const UserRights = resolve => require(['../components/user-rights'], resolve)
const UserUpgrade = resolve => require(['../components/UserUpgrade'], resolve)
const UserClient = resolve => require(['../components/MyClient'], resolve)
const UserAchievement = resolve => require(['../components/MyAchievement'], resolve)
const Placard = resolve => require(['../components/placard'], resolve)
const PlacardDetail = resolve => require(['../components/placard-detail'], resolve)

const partnerlogin = resolve => require(['../components/partners/login'], resolve)
const partnerreg = resolve => require(['../components/partners/reg'], resolve)
const partnersHospitals = resolve => require(['../components/partners/hospitals'], resolve)
const joinAgreement = resolve => require(['../components/partners/agreement'], resolve)
const UpgradAgreement = resolve => require(['../components/UpgradAgreement'], resolve)

const PartnerHospital = resolve => require(['../components/partner-hospital'], resolve)
const PartnerHospitalDetail = resolve => require(['../components/partner-hospital-detail'], resolve)

const News = resolve => require(['../components/News'], resolve)
const NewsDetail = resolve => require(['../components/NewsDetail'], resolve)

const WelCome = resolve => require(['../components/welcome'], resolve)

const NotFontPage = resolve => require(['../components/404'], resolve)

const ucp = resolve => require(['../components/ucp'], resolve)

Vue.use(VueRouter)


const router = new VueRouter({
    hashbang: true,
    history: true,
    mode: 'history',
    saveScrollPosition: false,
    routes: [
        { path: '/', component: Home },
        { path: '/login', component: Login },
        { path: '/projects', component: Projects },
        { path: '/projects-detail', component: ProjectsDetail },
        { path: '/submitorder', component: SubmitOrder },
        { path: '/shop', component: Shop },
        { path: '/shop/product-exchange', component: ProductExchange },
        { path: '/shop/product-detail', component: ProductDetail },

        { path: '/user', component: User, meta: { requireAuth: true, } },// 添加该字段，表示进入这个路由是需要登录的
        { path: '/user/info', component: UserInfo },
        { path: '/user/mypoints', component: MyPoints },
        { path: '/user/mysubscribers', component: MySubscribers },
        { path: '/user/myorders', component: MyOrders },
        { path: '/user/aboutus', component: AboutUs },
        { path: '/user/coupon', component: Coupon },
        { path: '/user/setting', component: Setting },
        { path: '/user/servicecenter', component: UserSerivce },
        { path: '/user/userrights', component: UserRights },
        { path: '/user/upgrade', component: UserUpgrade },
        { path: '/user/client', component: UserClient },
        { path: '/user/achievement', component: UserAchievement },
        { path: '/user/agreement', component: joinAgreement },
        { path: '/user/upgrade-agreement', component: UpgradAgreement },
        { path: '/user/placard', component: Placard },
        { path: '/user/placard/detail', component: PlacardDetail },

        { path: '/partners/login', component: partnerlogin },
        { path: '/partners/reg', component: partnerreg },
        { path: '/partners/hospitals', component: partnersHospitals },

        { path: '/partner-hospital', component: PartnerHospital },
        { path: '/partner-hospital-detail', component: PartnerHospitalDetail },

        { path: '/news', component: News },
        { path: '/news/detail', component: NewsDetail },

        { path: '/welcome', component: WelCome },


        { path: '/dict', component: Dictionray },
        { path: '/dict/article', component: DictionrayArticle },
        { path: '/error/:msg', component: ErrorPage },
        { path: '/404', component: NotFontPage },
        { path: '/', redirect: '/404' },
        { path: '/ucp', component: ucp }
    ],

});
//获取Parent OpenID
var getQueryParam = function (name) {
    var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
    var r = window.location.search.substr(1).match(reg);
    console.log(JSON.stringify(r))
    if (r != null) {
        console.log(JSON.stringify(r[2]))
        return unescape(r[2]);
    }
    return '';
}

router.beforeEach((to, from, next) => {
    //let isNative = utils.isNative()
    //if (!isNative) {
    //    wxAuthInit().then(() => {
    //        next();
    //    }, () => {
    //        doWXAuth(to)
    //        return;
    //    })
    //} else {
    //    next()
    //}
    let shuldAuth = to.meta.requireAuth == true
    let isLogin=true
    if (shuldAuth && !isLogin) {
        location.href = '/login/?target=' + to.fullPath
        return false;
    }
    next()
})

let getAuthUrl = function (to) {

    let wxAuthorizeUrl = location.origin + to.fullPath;

    return wxAuthorizeUrl
}

let doWXAuth = function (to) {
    let wxAuthorizeUrl = getAuthUrl(to)
    WX.doAuth(wxAuthorizeUrl)
}

let wxAuthInit = function () {
    let fn = (resolve, reject) => {

        //先判断用户是否已经授权
        let auth_code = getQueryParam('code');
        if (!auth_code) {
            reject()
        } else {
            //获取用户信息
            WX.getUserInfo(auth_code).then(function (userInfo) {
                console.log(userInfo)
                if (userInfo.errcode) {
                    reject()
                } else {
                    //设置用用户自动登录
                    let parentOpenId = getQueryParam('parent')
                    let url = api.DO_LOGIN + userInfo.openid + '&parent=' + parentOpenId + '&nickName=' + userInfo.nickname
                    axios.get(url).then(response => {
                        if (response.data.code == 0) {
                            //localStorage.setItem('userinfo', JSON.stringify(userInfo))
                            let _userInfo = response.data.data;
                            _userInfo.WX = userInfo;
                            localStorage.setItem('userinfo', JSON.stringify(_userInfo))
                        }
                    });
                    //初始化JSSDK
                    try {
                        //var signUrl = encodeURIComponent(location.href.split('#')[0])
                        var signUrl = encodeURIComponent(location.href)
                        WX.initJSSDK(userInfo.access_token, signUrl).then(function () { });
                    } catch (e) {
                        console.log(e)
                    }
                    resolve();
                }
            })
        }
    }

    return new Promise(fn)


}


export default router;
