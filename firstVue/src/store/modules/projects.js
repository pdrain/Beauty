import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'

const state = {
    currentCat: 0,//默认项目分类
    cats: [],//项目分类
    list: []//项目列表
}

const getters = {
    ProjectCurrentCat: state => state.currentCat,//获取当前分类
    ProjectCats: state => state.cats,
    ProjectList: state => state.list
}

const actions = {
    quereProjectCats({ commit, state }) {
        commit(types.QUEREY_PROJECT_CATS);
    },
    chooseProjectCat({ commit, state }, catId) {
        commit(types.CHOOSE_PROJECT_CAT, catId);
    },
    queryProjectsDetail({commit,state},projectId){
        commit(types.QUEREY_PROJECT_DETAIL,projectId);
    }
}

const mutations = {
    [types.QUEREY_PROJECT_CATS](state) {
        axios.get(api.PROJECT_CAT).then(response => {
            state.cats = response.data;
            state.currentCat = state.cats[0].ID;
            axios.get(api.PROJECT_LIST, { catId: state.currentCat }).then(response => {

                let result = response.data.filter(item => {
                    return item.CatID === state.currentCat;
                })

                state.list = result;
            })
        })
    },
    [types.CHOOSE_PROJECT_CAT](state, catId) {
        state.currentCat = catId;
        axios.get(api.PROJECT_LIST, { catId: state.currentCat }).then(response => {

            let result = response.data.filter(item => {
                return item.CatID === state.currentCat;
            })
            state.list = result;
        })
    },
    [types.QUEREY_PROJECT_DETAIL](state,projectId){
        //获取项目明细
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}