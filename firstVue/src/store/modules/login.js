import * as types from '../types'
import * as api from '../../api'
import axios from '../../http'

const state = {
    user: null,
    token: null
}

const getters = {
    token: state => state.token
}

const actions = {
    doLogin ({ commit }, { token, user }) {
        commit(types.LOGIN, { token, user })
    },
    doLogout ({ commit }) {
        commit(types.LOGOUT);
    },
    partnerLogin ({ commit }, account) {
        return new Promise(function (resolve) {
            let url = api.DO_LOGIN;
            let param = { phone: account.username, password: account.password }
            axios.post(url, param).then(response => {
                
                let data = {};
                if (response.status == 200) {
                    data = response.data;
                }
                resolve(data)
            }, err => {
                alert(err.errorMsg);
            });
        });
    },
    partnerReg ({ commit }, account) {
        return new Promise(function (resolve) {
            let url = api.REGISTER;
            axios.get(url, account).then(response => {
                let data = {};
                if (response.status == 200) {
                    data = response.data;
                }
                resolve(data)
            });
        });
    }
}

const mutations = {
    [types.LOGIN]: (state, token, user) => {
        state.token = token;
        state.user = user;
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