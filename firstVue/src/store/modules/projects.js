import * as types from '../types'
import axios from '../../http'
import * as api from '../../api'
import util from 'util'

const state = {
    currentCat: 0,//默认项目分类
    cats: [],//项目分类
    list: [],//项目列表
    detail: null
}

const getters = {
    ProjectCurrentCat: state => state.currentCat,//获取当前分类
    ProjectCats: state => state.cats,
    ProjectList: state => state.list,
    ProjectDetail: state => state.detail
}


const actions = {
    quereProjectCats({ commit, state }) {
        commit(types.QUEREY_PROJECT_CATS);
    },
    chooseProjectCat({ commit, state }, catId) {
        commit(types.QUEREY_PROJECT_LIST, catId);
    },
    queryProjectsDetail({ commit, state }, projectId) {
        commit(types.QUEREY_PROJECT_DETAIL, projectId);
    }
}

const mutations = {
    [types.QUEREY_PROJECT_CATS](state) {

        axios.get(api.PROJECT_CAT).then(response => {debugger
            if (response.data.Code == 0) {
                state.cats = response.data.Result;
                state.currentCat = state.cats[0].ID;
            }
            else {
                alert(response.data.Message);
            }
        });
    },
    [types.QUEREY_PROJECT_LIST](state, catId) {

        state.currentCat = catId;
        let _url_project_list = util.format(api.PROJECT_LIST, state.currentCat);
        axios.get(_url_project_list).then(response => {

            if (response.data.Code == 0) {
                let result = response.data.Result;
                state.list = result;
            }
            else {
                alert(response.data.Message);
            }
        })
    },
    [types.QUEREY_PROJECT_DETAIL](state, projectId) {
        //获取项目明细        
        let _url_project_detail = util.format(api.PROJECT_DETAIL, projectId);

        axios.get(_url_project_detail).then(response => {
            if (response.data.Code == 0) {
                state.detail = response.data.Result;
            }
            else {
                alert(response.data.Message);
            }
        })
    }
}



export default {
    state,
    getters,
    actions,
    mutations
}