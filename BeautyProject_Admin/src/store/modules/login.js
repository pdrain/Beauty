import axios from '../../http'
import * as types from '../types'
import * as api from '../../api'
import cookieHelper from '../../utils/cookiehekper'

const state = {
    token: null
}


const getters = {
    Token: state => state.token
}

const actions = {
    doLogin ({ commit, state }, params) {
        return new Promise(function (res, rej) {
            let  data  = {
                "Account": params.account,
                "Password": params.password
              }
            axios.post(api.DO_ADMIN_LOGIN, data).then(function (result) {
                debugger
                cookieHelper.setCookie({
                    name:'token',
                    value:'hello----world'
                })

                res.call(this,true)
            })
        })
        
    },
    doLogout ({ commit }) {
        commit(types.LOGOUT);
    }
}

const mutations = {
    [types.LOGIN]: (state, params) => {
        state.token = params.token;
        params.cb.call(this, true);

    },
    [types.LOGOUT]: (state) => {
        state.token = null;
        state.user = null;
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}