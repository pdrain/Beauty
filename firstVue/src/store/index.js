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

Vue.use(Vuex);
export default new Vuex.Store({
    modules: { loading, login,projects,product,submitorder ,dictionary}
})