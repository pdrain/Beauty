/**
 * Created by superman on 17/2/16.
 */
import Vuex from 'vuex'
import Vue from 'vue'
import * as types from './types'

import loading from './modules/loading'
import login from './modules/login'
import projects from './modules/projects'
import product from './modules/product'
import submitorder from './modules/submitorder'
import dictionary from './modules/dictionary'
import user from './modules/user'
import home from './modules/home'
import order from './modules/order'

import hospital from './modules/hospital'

import news from './modules/news'

Vue.use(Vuex);
export default new Vuex.Store({
    modules: { loading, login,home, projects,product,submitorder ,dictionary,user,hospital,order,news}
})