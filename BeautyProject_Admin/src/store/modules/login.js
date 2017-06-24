import * as types from '../types'

const state = {
    token: null
}


const getters = {
    Token: state => state.token
}

const actions = {
    doLogin({ commit,state }, params) {
        commit(types.LOGIN, params)
    },
    doLogout({ commit }) {
        commit(types.LOGOUT);
    }
}

const mutations  = {
    [types.LOGIN]: (state, params) => {
        state.token = params.token;
      params.cb.call(this,true);
        
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