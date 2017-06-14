import Vue from 'vue'
import Router from 'vue-router'


import Hello from '@/components/Hello'

const Login = resolve => require(['../components/Login'], resolve)
const Home = resolve => require(['../components/Home'], resolve)

Vue.use(Router)

const router = new Router({
  routes: [
    { path: '/', name: 'Home', component: Home, meta: { requireAuth: true } },
    { path: '/login', name: 'Login', component: Login },
    { path: '/test', name: 'Hello', component: Hello }
  ]
})

router.beforeEach((to, from, next) => {




  let ua = window.navigator.userAgent.toLowerCase();


  //非微信中
  if (to.meta.requireAuth) {  // 判断该路由是否需要登录权限

    if (store.state.token) {  // 通过vuex state获取当前的token是否存在
      next();
    }
    else {
      next({
        path: '/login',
        query: { redirect: to.fullPath }  // 将跳转的路由path作为参数，登录成功后跳转到该路由
      })
    }
  }
  else {
    next();
  }

})

export default router