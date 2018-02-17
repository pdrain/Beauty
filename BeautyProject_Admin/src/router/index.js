import Vue from 'vue'
import VueRouter from 'vue-router'
import store from '../store'
import { mapGetters } from 'vuex'
import cookieHelper from '../utils/cookiehekper'

const Hello = resolve => require(['../components/Hello'], resolve)
const Login = resolve => require(['../components/Login'], resolve)
const Home = resolve => require(['../components/Home'], resolve)

const Subscribers = resolve => require(['../components/Subscribers'], resolve)
const Achievement = resolve => require(['../components/Achievement'], resolve)
const Sales = resolve => require(['../components/Sales'], resolve)
const SalesApply = resolve => require(['../components/SalesApply'], resolve)

const ProjectCat = resolve => require(['../components/ProjectCat'], resolve)
const ProjectList = resolve => require(['../components/ProjectList'], resolve)
const ProductCat = resolve => require(['../components/ProductCat'], resolve)
const ProductList = resolve => require(['../components/ProductList'], resolve)



Vue.use(VueRouter)

const router = new VueRouter({
  hashbang: true,
  hsitory: true,
  mode:'history',
  routes: [
    { path: '/', name: 'Home', component: Home, meta: { requireAuth: true } },
    { path: '/login', name: 'Login', component: Login },
    { path: '/subscribers', name: 'Subscribers', component: Subscribers, meta: { requireAuth: true } },
    { path: '/achievement', name: 'Achievement', component: Achievement, meta: { requireAuth: true } },
    { path: '/sales', name: 'Sales', component: Sales, meta: { requireAuth: true } },
    { path: '/sales-apply', name: 'salesapply', component: SalesApply, meta: { requireAuth: true } },
    { path: '/project-cat', name: 'ProjectCat', component: ProjectCat },
    { path: '/project-list', name: 'ProjectList', component: ProjectList },
    { path: '/product-cat', name: 'ProductCat', component: ProductCat },
    { path: '/product-list', name: 'ProductList', component: ProductList }
  ]
})



router.beforeEach((to, from, next) => {

  let ua = window.navigator.userAgent.toLowerCase();

  console.log(store.getters.Token);

  //非微信中
  if (to.meta.requireAuth) {  // 判断该路由是否需要登录权限
    let tooken_cookie = cookieHelper.getCookie('token')
    if (tooken_cookie) {  // 通过vuex state获取当前的token是否存在
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

export default router;