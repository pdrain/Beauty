import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'

const state = {
    order: null,
    projectItem: null,
    userInfo: null
}

const getters = {
    Order: state => state.order,
    ProjectItem: state => state.projectItem,
    UserInfo: state => state.userInfo
}

const actions = {
    queryProjectsDetail({ commit, state }, projectId) {
        commit(types.QUEREY_PROJECT_DETAIL, projectId);
    },
    saveOrder(commit, state) {
        commit(types.SUBMIT_ORDER);
    }

}

const mutations = {
    [types.QUEREY_PROJECT_DETAIL](state, projectId) {
        var result = getProject(state, projectId)
        result.then(() => {
            result = getUserInfo(state, 1);
        })


        
    },
    [types.SUBMIT_ORDER](state) {
        axios.post(api.SUBMIT_ORDER, state.order).then(response => {

        })
    }

}

const getProject = (state, id) => {

    let promise = axios.get(api.PROJECT_DETAIL).then(response => {
        state.projectItem = response.data;
    })
    return promise
}

const getUserInfo = (state, userId) => {

    let promise = axios.get(api.USER_INFO).then(response => {
        state.userInfo = response.data;
    });

    return promise;
}




export default {
    state,
    getters,
    actions,
    mutations

}