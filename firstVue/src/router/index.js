import Vue from 'vue'
import VueRouter from 'vue-router'

import store from '../store'
import axios from '../http'

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
const ErrorPage = resolve => require(['../components/Error'], resolve)
const SubmitOrder=resolve=>require(['../components/SubmitOrder'],resolve)

Vue.use(VueRouter)


const router = new VueRouter({
    hashbang: true, 
    history: true,
    routes:[
        {path:'/login',component:Login},        
        {path:'/projects',component:Projects},
        {path:'/projects-detail',component:ProjectsDetail},
        {path:'/submitorder',component:SubmitOrder},
        {path:'/shop',component:Shop},
        {path:'/user',component:User,meta:
            {
                requireAuth: true,  // 添加该字段，表示进入这个路由是需要登录的
            }
        },
        {path:'/user/info',component:UserInfo},
        {path:'/user/mypoints',component:MyPoints},
        {path:'/user/mysubscribers',component:MySubscribers},
        {path:'/error/:msg',component:ErrorPage},
        //{path:'*',redirect:'/Projects'},
        
    ],

});


router.beforeEach((to, from, next) => {
    
    
   

    let ua = window.navigator.userAgent.toLowerCase();
     if (ua.indexOf('micromessenger') > 1) {
        let wx_auth_code;
        
        if(to.query){
            wx_auth_code =to.query.code;
        }

        if(!wx_auth_code){
            //window.location.href="调用微信认证接口地址"
            console.log('调用微信认证接口')
        }

    //      //微信
    //      let authid = store.state.authId;
    //       if (authid) {

    //     axios.get(api.WEIXIN_AUTH, {authid: authid})
    //     .then(response => {
    //           let res = response.data
    //             if (res.code === '404') {                
                
    //             } else if (res.code === '01') {
    //             // store.dispatch('setUserInfo', res.userInfo)
    //                 next()
    //             }
    //     })

    //   } else {
    //     // 强制跳转，授权登录，并设置cookie
        
    //   }
     }
     else{

         
        // //非微信中
        // if (to.meta.requireAuth) {  // 判断该路由是否需要登录权限
            
        //         if (store.state.token) {  // 通过vuex state获取当前的token是否存在
        //             next();
        //         }
        //         else {
        //             next({
        //                 path: '/login',
        //                 query: {redirect: to.fullPath}  // 将跳转的路由path作为参数，登录成功后跳转到该路由
        //             })
        //         }
        //     }
        //     else {
        //         next();
        //     }
     }   
        
   
next();
      
})



export default router;
