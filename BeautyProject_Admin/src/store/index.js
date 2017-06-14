import Vuex from 'vuex'
import Vue from 'vue'
import * as types from './types'

import login from './modules/login'

Vue.use(Vuex);
export default new Vuex.Store({
    modules: { login }
})