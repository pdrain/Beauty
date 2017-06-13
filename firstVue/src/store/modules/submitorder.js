import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'

const state = {
    order: null,
    userInfo: null
}

const getters = {
    Order: state => state.order,
    UserInfo: state => state.userInfo

}

const actions = {
    getUserInfo({ commit, state }, userId) {
        commit(types.GET_USER_INFO, userId);
    },
    submitOrder(commit, state) {
        commit(types.SUBMIT_ORDER);
    }

}

const mutations = {

    [types.SUBMIT_ORDER](state) {
        axios.post(api.SUBMIT_ORDER, state.order).then(response => {

        })
    },
    [types.GET_USER_INFO](state, userId) {
      //  getUserInfo(state, userId);
    }

}


const getUserInfo = (state, userId) => {

    axios.get(api.USER_INFO).then(response => {
        state.userInfo = response.data;
    });
}




export default {
    state,
    getters,
    actions,
    mutations

}