/**
 * Created by superman on 17/2/16.
 */
import Vuex from 'vuex'
import Vue from 'vue'
import * as types from './types'

import loading from './modules/loading'
import login from './modules/login'
import projects from './modules/projects'
import submitorder from './modules/submitorder'

Vue.use(Vuex);
export default new Vuex.Store({
    modules: { loading, login,projects,submitorder }
})