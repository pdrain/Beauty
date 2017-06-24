
import Vue from 'vue'
import Vuex from 'vuex'

import * as types from './types'

import login from './modules/login'
import subscrbers from './modules/subscribers'
import sales from './modules/sales'

import project from './modules/project'
import product from './modules/product'


Vue.use(Vuex);


export default new Vuex.Store({
    modules:{ login,subscrbers,sales,project,product}
})