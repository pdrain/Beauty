import * as types from '../types'

const state = {
    user: null,
    token: null
}

const getters = {
    token: state => state.token
}

const actions = {
    doLogin({ commit }, { token, user }) {
        commit(types.LOGIN, { token, user })
    },
    doLogout({ commit }) {
        commit(types.LOGOUT);
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