import axios from '../../http'
import * as types from '../types'
import * as api from '../../api'

const state = {
    projectCat: {},
    projectList: []
}

const getters = {
    ProjectCat: state => state.projectCat,
    ProjectList: state => state.projectList
}

const actions = {
    getProjectCats({ commit, state }) {
        return new Promise(function (res, rej) {
            axios.get(api.GET_PROJECT_CAT_LIST).then(function (res) {
debugger
                commit(types.GET_PROJECT_CAT_LIST, res)

                res.call();
            }, function (err) {
                debugger
                console.log(err);
            });
        });

    },
    editProjectCat({ commit, state }, catId) {
        return new Promise(function (res, rej) {
            let url = api.GET_PROJECT_CAT + '/' + catId;
            axios.get(url).then(function (res) {
                commit(types.GET_PRODUCT_CAT, res)

                res.call();
            }, function (err) {
                console.log(err);
            });
        });

    },
    deleteProjectCat({ commit, state }, catId) {
        return new Promise(function (res, rej) {
            axios.get(api.GET_PROJECT_CAT_LIST).then(function (res) {
                res.call();
            }, function (err) {
                console.log(err);
            });
        });
    },
    saveProjectCat({ commit, state }) {
        return new Promise(function (res, rej) {
            axios.get(api.SAVE_PROJECT_CAT).then(function (res) {
                res.call();
            }, function (err) {
                console.log(err);
            });
        });

    }

}

const mutations = {
    [types.GET_PROJECT_CAT_LIST](state, data) {
        state.projectList = data;

    },
    [types.GET_PROJECT_CAT](state, data) {
        state.projectCat = data;
    }

}

export default {

    state,
    getters,
    actions,
    mutations
}