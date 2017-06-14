import Vue from 'vue'
import Router from './router'
import Axios from './http'
import Store from "./store"  
import VueResource from 'vue-resource'
import VueMaterial from 'vue-material'

import App from './App'

Vue.use(VueResource);
Vue.use(VueMaterial);



Vue.directive('title', {
  inserted: function (el, binding) {;
    document.title = binding.value;;
  }
})

new Vue({
  el: '#app',
  axios:Axios,
  router:Router,
  store:Store,
  render:h=>h(App)
})
